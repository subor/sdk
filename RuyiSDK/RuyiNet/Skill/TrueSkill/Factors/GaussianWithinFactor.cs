using System;

namespace Ruyi
{
    public class GaussianWithinFactor : GaussianFactor
    {
        public GaussianWithinFactor(double epsilon, Variable<GaussianDistribution> variable)
            : base(string.Format("{0} ,= {1:0.000}", variable, epsilon))
        {
            mEpsilon = epsilon;
            CreateVariableToMessageBinding(variable);
        }

        public override double LogNormalization
        {
            get
            {
                var marginal = Variables[0].Value;
                var message = Messages[0].Value;
                var messageFromVariable = marginal / message;
                var mean = messageFromVariable.Mean;
                var std = messageFromVariable.StandardDeviation;
                var z = GaussianDistribution.CumulativeTo((mEpsilon - mean) / std) -
                    GaussianDistribution.CumulativeTo((-mEpsilon - mean) / std);

                return -GaussianDistribution.LogProductNormalization(messageFromVariable, message) + Math.Log(z);
            }
        }

        protected override double UpdateMessage(Message<GaussianDistribution> message, Variable<GaussianDistribution> variable)
        {
            var oldMarginal = variable.Value.Clone();
            var oldMessage = message.Value.Clone();
            var messageFromVariable = oldMarginal / oldMessage;

            var c = messageFromVariable.Precision;
            var d = messageFromVariable.PrecisionMean;

            var sqrtC = Math.Sqrt(c);
            var dOnSqrtC = d / sqrtC;

            var epsilonTimesSqrtC = mEpsilon * sqrtC;
            d = messageFromVariable.PrecisionMean;

            var denominator = 1.0 - TruncatedGaussianCorrectionFunctions.WWithinMargin(dOnSqrtC, epsilonTimesSqrtC);
            var newPrecision = c / denominator;
            var newPrecisionMean = (d + sqrtC * TruncatedGaussianCorrectionFunctions.VWithinMargin(dOnSqrtC, epsilonTimesSqrtC)) / denominator;

            var newMarginal = GaussianDistribution.FromPrecisionMean(newPrecisionMean, newPrecision);
            var newMessage = oldMessage * newMarginal / oldMarginal;

            message.Value = newMessage;
            variable.Value = newMarginal;

            return newMarginal - oldMarginal;
        }

        private readonly double mEpsilon;
    }
}
