using System;

namespace Ruyi
{
    public class GaussianGreaterThanFactor : GaussianFactor
    {
        public GaussianGreaterThanFactor(double epsilon, Variable<GaussianDistribution> variable)
            : base(String.Format("{0} > {1:0.000}", variable, epsilon))
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

                return -GaussianDistribution.LogProductNormalization(messageFromVariable, message) +
                    Math.Log(GaussianDistribution.CumulativeTo((messageFromVariable.Mean - mEpsilon) /
                    messageFromVariable.StandardDeviation));
            }
        }

        protected override double UpdateMessage(Message<GaussianDistribution> message, Variable<GaussianDistribution> variable)
        {
            var oldMarginal = variable.Value.Clone();
            var oldMessage = message.Value.Clone();
            var messageFromVar = oldMarginal / oldMessage;

            var c = messageFromVar.Precision;
            var d = messageFromVar.PrecisionMean;

            var sqrtC = Math.Sqrt(c);
            var dOnSqrtC = d / sqrtC;

            var epsilonTimesSqrtC = mEpsilon * sqrtC;
            d = messageFromVar.PrecisionMean;

            var denom = 1.0 - TruncatedGaussianCorrectionFunctions.WExceedsMargin(dOnSqrtC, epsilonTimesSqrtC);

            var newPrecision = c / denom;
            var newPrecisionMean = (d + sqrtC * TruncatedGaussianCorrectionFunctions.VExceedsMargin(dOnSqrtC, epsilonTimesSqrtC)) / denom;

            var newMarginal = GaussianDistribution.FromPrecisionMean(newPrecisionMean, newPrecision);
            var newMessage = oldMessage * newMarginal / oldMarginal;

            message.Value = newMessage;
            variable.Value = newMarginal;

            return newMarginal - oldMarginal;
        }

        private readonly double mEpsilon;
    }
}
