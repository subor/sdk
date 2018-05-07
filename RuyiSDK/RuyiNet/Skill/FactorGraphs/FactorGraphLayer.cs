using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    public abstract class FactorGraphLayerBase<TValue>
    {
        public virtual Schedule<TValue> CreatePriorSchedule()
        {
            return null;
        }

        public virtual Schedule<TValue> CreatePosteriorSchedule()
        {
            return null;
        }

        public abstract void SetRawInputVariablesGroups(object value);
        public abstract object GetRawOutputVariablesGroups();

        public abstract void BuildLayer();
        public abstract IEnumerable<Factor<TValue>> UntypedFactors { get; }
    }

    public abstract class FactorGraphLayer<TParentGraph, TValue, TBaseVariable, TInputVariable, TFactor, TOutputVariable>
        : FactorGraphLayerBase<TValue>
        where TParentGraph : FactorGraph<TParentGraph, TValue, TBaseVariable>
        where TBaseVariable : Variable<TValue>
        where TInputVariable : TBaseVariable
        where TFactor : Factor<TValue>
        where TOutputVariable : TBaseVariable
    {
        public override void SetRawInputVariablesGroups(object value)
        {
            var newList = value as IList<IList<TInputVariable>>;
            mInputVariablesGroups = newList ?? throw new ArgumentException();
        }

        public override object GetRawOutputVariablesGroups()
        {
            return mOutputVariablesGroups;
        }

        public TParentGraph ParentFactorGraph { get; private set; }
        public IList<IList<TOutputVariable>> OutputVariablesGroup { get { return mOutputVariablesGroups; } }
        public IList<TFactor> LocalFactors { get { return mLocalFactors; } }
        public override IEnumerable<Factor<TValue>> UntypedFactors { get { return mLocalFactors.Cast<Factor<TValue>>(); } }

        protected FactorGraphLayer(TParentGraph parentGraph)
        {
            ParentFactorGraph = parentGraph;
        }

        protected Schedule<TValue> ScheduleSequence<TSchedule>(IEnumerable<TSchedule> itemsToSequence, string nameFormat, params object[] args)
            where TSchedule : Schedule<TValue>
        {
            string formattedName = String.Format(nameFormat, args);
            return new ScheduleSequence<TValue, TSchedule>(formattedName, itemsToSequence);
        }

        protected void AddLayerFactor(TFactor factor)
        {
            mLocalFactors.Add(factor);
        }

        protected IList<IList<TInputVariable>> InputVariablesGroups { get { return mInputVariablesGroups; } }

        private readonly List<TFactor> mLocalFactors = new List<TFactor>();
        private readonly List<IList<TOutputVariable>> mOutputVariablesGroups = new List<IList<TOutputVariable>>();
        private IList<IList<TInputVariable>> mInputVariablesGroups = new List<IList<TInputVariable>>();
    }
}
