namespace Ruyi.SDK.Cloud
{
    public abstract class GaussianFactor : Factor<GaussianDistribution>
    {
        public override Message<GaussianDistribution> CreateVariableToMessageBinding(Variable<GaussianDistribution> variable)
        {
            return CreateVariableToMessageBinding(variable,
                new Message<GaussianDistribution>(GaussianDistribution.FromPrecisionMean(0, 0), "message from {0} to {1}", this, variable));
        }

        protected GaussianFactor(string name)
            : base(name)
        {
        }

        protected override double SendMessage(Message<GaussianDistribution> message, Variable<GaussianDistribution> variable)
        {
            var marginal = variable.Value;
            var messageValue = message.Value;
            var logZ = GaussianDistribution.LogProductNormalization(marginal, messageValue);
            variable.Value = marginal * messageValue;
            return logZ;
        }
    }
}
