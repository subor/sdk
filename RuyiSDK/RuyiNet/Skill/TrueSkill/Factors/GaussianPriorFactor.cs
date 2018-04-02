using System;

namespace Ruyi
{
    public class GaussianPriorFactor : GaussianFactor
    {
        public GaussianPriorFactor(double mean, double variance, Variable<GaussianDistribution> variable)
            : base(string.Format("Prior value going to {0}", variable))
        {
            mNewMessage = new GaussianDistribution(mean, Math.Sqrt(variance));
            CreateVariableToMessageBinding(variable,
                new Message<GaussianDistribution>(GaussianDistribution.FromPrecisionMean(0, 0), "message from {0} to {1}", this, variable));
        }

        protected override double UpdateMessage(Message<GaussianDistribution> message, Variable<GaussianDistribution> variable)
        {
            var oldMarginal = variable.Value.Clone();
            var oldMessage = message;
            var newMarginal = GaussianDistribution.FromPrecisionMean(
                oldMarginal.PrecisionMean + mNewMessage.PrecisionMean - oldMessage.Value.PrecisionMean,
                oldMarginal.Precision + mNewMessage.Precision - oldMessage.Value.Precision);
            variable.Value = newMarginal;
            message.Value = mNewMessage;
            return oldMarginal - newMarginal;
        }

        private readonly GaussianDistribution mNewMessage;
    }
}
