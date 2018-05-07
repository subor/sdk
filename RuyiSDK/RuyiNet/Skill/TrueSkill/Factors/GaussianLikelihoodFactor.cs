using System;

namespace Ruyi.SDK.Online
{
    public class GaussianLikelihoodFactor : GaussianFactor
    {
        public GaussianLikelihoodFactor(double betaSquared,
            Variable<GaussianDistribution> variable1, Variable<GaussianDistribution> variable2)
            : base(string.Format("Likelihood of {0} going to {1}", variable2, variable1))
        {
            mPrecision = 1.0 / betaSquared;
            CreateVariableToMessageBinding(variable1);
            CreateVariableToMessageBinding(variable2);
        }

        public override double LogNormalization
        {
            get
            {
                return GaussianDistribution.LogRatioNormalization(Variables[0].Value, Variables[1].Value);
            }
        }

        public override double UpdateMessage(int messageIndex)
        {
            switch (messageIndex)
            {
                case 0:
                    return UpdateHelper(Messages[0], Messages[1],
                        Variables[0], Variables[1]);

                case 1:
                    return UpdateHelper(Messages[1], Messages[0],
                        Variables[1], Variables[0]);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double UpdateHelper(Message<GaussianDistribution> message1, Message<GaussianDistribution> message2,
            Variable<GaussianDistribution> variable1, Variable<GaussianDistribution> variable2)
        {
            var message1Value = message1.Value.Clone();
            var message2Value = message2.Value.Clone();

            var marginal1 = variable1.Value.Clone();
            var marginal2 = variable2.Value.Clone();

            var a = mPrecision / (mPrecision + marginal2.Precision - message2Value.Precision);

            var newMessage = GaussianDistribution.FromPrecisionMean(
                a * (marginal2.PrecisionMean - message2Value.PrecisionMean),
                a * (marginal2.Precision - message2Value.Precision));

            var oldMarginalWithoutMessage = marginal1 / message1Value;
            var newMarginal = oldMarginalWithoutMessage * newMessage;

            message1.Value = newMessage;
            variable1.Value = newMarginal;

            return newMarginal - marginal1;
        }

        private readonly double mPrecision;
    }
}
