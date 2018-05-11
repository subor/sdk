using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ruyi.SDK.Online
{
    public class GaussianWeightedSumFactor : GaussianFactor
    {
        public GaussianWeightedSumFactor(Variable<GaussianDistribution> sumVariable,
            Variable<GaussianDistribution>[] variablesToSum)
            : this(sumVariable, variablesToSum, variablesToSum.Select(v => 1.0).ToArray())
        {
        }

        public GaussianWeightedSumFactor(Variable<GaussianDistribution> sumVariable,
            Variable<GaussianDistribution>[] variablesToSum, double[] variableWeights)
            : base(CreateName(sumVariable, variablesToSum, variableWeights))
        {
            mWeights = new double[variableWeights.Length + 1][];
            mWeightsSquared = new double[mWeights.Length][];

            mWeights[0] = new double[variableWeights.Length];
            Array.Copy(variableWeights, mWeights[0], variableWeights.Length);
            mWeightsSquared[0] = mWeights[0].Select(w => w * w).ToArray();

            mVariableIndexOrdersForWeights.Add(Enumerable.Range(0, 1 + variablesToSum.Length).ToArray());

            for (var weightsIndex = 1; weightsIndex < mWeights.Length; ++weightsIndex)
            {
                var currentWeights = new double[variableWeights.Length];
                mWeights[weightsIndex] = currentWeights;

                var variableIndices = new int[variableWeights.Length + 1];
                variableIndices[0] = weightsIndex;

                var currentWeightsSquared = new double[variableWeights.Length];
                mWeightsSquared[weightsIndex] = currentWeightsSquared;

                var currentDestinationWeightIndex = 0;

                for (var currentWeightSourceIndex = 0;
                    currentWeightSourceIndex < variableWeights.Length;
                    ++currentWeightSourceIndex)
                {
                    if (currentWeightSourceIndex == (weightsIndex - 1))
                    {
                        continue;
                    }

                    var currentWeight = -variableWeights[currentWeightSourceIndex] / variableWeights[weightsIndex - 1];
                    if (variableWeights[weightsIndex - 1] == 0)
                    {
                        currentWeight = 0;
                    }

                    currentWeights[currentDestinationWeightIndex] = currentWeight;
                    currentWeightsSquared[currentDestinationWeightIndex] = currentWeight * currentWeight;

                    variableIndices[currentDestinationWeightIndex + 1] = currentWeightSourceIndex + 1;
                    ++currentDestinationWeightIndex;
                }

                var finalWeight = 1.0 / variableWeights[weightsIndex - 1];

                if (variableWeights[weightsIndex - 1] == 0)
                {
                    finalWeight = 0;
                }

                currentWeights[currentDestinationWeightIndex] = finalWeight;
                currentWeightsSquared[currentDestinationWeightIndex] = finalWeight * finalWeight;
                variableIndices[variableIndices.Length - 1] = 0;
                mVariableIndexOrdersForWeights.Add(variableIndices);
            }

            CreateVariableToMessageBinding(sumVariable);

            foreach (var currentVariable in variablesToSum)
            {
                CreateVariableToMessageBinding(currentVariable);
            }
        }

        public override double LogNormalization
        {
            get
            {
                var vars = Variables;
                var messages = Messages;

                var result = 0.0;
                for (var i = 1; i < vars.Count; ++i)
                {
                    result += GaussianDistribution.LogRatioNormalization(vars[i].Value, messages[i].Value);
                }

                return result;
            }
        }

        public override double UpdateMessage(int messageIndex)
        {
            var allMessages = Messages;
            var allVariables = Variables;

            Guard.ArgumentIsValidIndex(messageIndex, allMessages.Count, "messageIndex");

            var updatedMessages = new List<Message<GaussianDistribution>>();
            var updatedVariables = new List<Variable<GaussianDistribution>>();

            var indicesToUse = mVariableIndexOrdersForWeights[messageIndex];

            for (var i = 0; i < allMessages.Count; ++i)
            {
                updatedMessages.Add(allMessages[indicesToUse[i]]);
                updatedVariables.Add(allVariables[indicesToUse[i]]);
            }

            return UpdateHelper(mWeights[messageIndex], mWeightsSquared[messageIndex], updatedMessages, updatedVariables);
        }

        private double UpdateHelper(double[] weights, double[] weightsSquared,
            IList<Message<GaussianDistribution>> messages,
            IList<Variable<GaussianDistribution>> variables)
        {
            var message0 = messages[0].Value.Clone();
            var marginal0 = variables[0].Value.Clone();

            var inverseOfNewPrecisionSum = 0.0;
            var anotherInverseOfNewPrecisionSum = 0.0;
            var weightedMeanSum = 0.0;
            var anotherWeightedMeanSum = 0.0;

            for (var i = 0; i < weightsSquared.Length; ++i)
            {
                inverseOfNewPrecisionSum += weightsSquared[i] /
                    (variables[i + 1].Value.Precision - messages[i + 1].Value.Precision);

                var diff = (variables[i + 1].Value / messages[i + 1].Value);
                anotherInverseOfNewPrecisionSum += weightsSquared[i] / diff.Precision;

                weightedMeanSum += weights[i] *
                    (variables[i + 1].Value.PrecisionMean - messages[i + 1].Value.PrecisionMean) /
                    (variables[i + 1].Value.Precision - messages[i + 1].Value.Precision);

                anotherWeightedMeanSum += weights[i] * diff.PrecisionMean / diff.Precision;
            }

            var newPrecision = 1.0 / inverseOfNewPrecisionSum;
            var anotherNewPrecision = 1.0 / anotherInverseOfNewPrecisionSum;

            var newPrecisionMean = newPrecision * weightedMeanSum;
            var anotherNewPrecisionMean = anotherNewPrecision * anotherWeightedMeanSum;

            var newMessage = GaussianDistribution.FromPrecisionMean(newPrecisionMean, newPrecision);
            var oldMarginalWithoutMessage = marginal0 / message0;
            var newMarginal = oldMarginalWithoutMessage * newMessage;

            messages[0].Value = newMessage;
            variables[0].Value = newMarginal;

            return newMarginal - marginal0;
        }

        private static string CreateName(Variable<GaussianDistribution> sumVariable,
            IList<Variable<GaussianDistribution>> variablesToSum, double[] weights)
        {
            var sb = new StringBuilder();
            sb.Append(sumVariable.ToString());
            sb.Append(" = ");
            for (var i = 0; i < variablesToSum.Count; ++i)
            {
                var isFirst = (i == 0);
                if (isFirst && (weights[i] < 0))
                {
                    sb.Append("-");
                }

                sb.Append(Math.Abs(weights[i]).ToString("0.00"));
                sb.Append("*[");
                sb.Append(variablesToSum[i]);
                sb.Append("]");

                var isLast = (i == variablesToSum.Count - 1);

                if (!isLast)
                {
                    if (weights[i + 1] >= 0)
                    {
                        sb.Append(" + ");
                    }
                    else
                    {
                        sb.Append(" - ");
                    }
                }
            }

            return sb.ToString();
        }

        private readonly List<int[]> mVariableIndexOrdersForWeights = new List<int[]>();

        private readonly double[][] mWeights;
        private readonly double[][] mWeightsSquared;
    }
}
