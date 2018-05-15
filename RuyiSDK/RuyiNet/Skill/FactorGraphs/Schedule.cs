using System;
using System.Collections.Generic;

namespace Ruyi
{
    public abstract class Schedule<T>
    {
        public double Visit()
        {
            return Visit(-1, 0);
        }

        public override string ToString()
        {
            return mName;
        }

        public abstract double Visit(int depth, int maxDepth);

        protected Schedule(string name)
        {
            mName = name;
        }

        private readonly string mName;
    }

    public class ScheduleStep<T> : Schedule<T>
    {
        public ScheduleStep(string name, Factor<T> factor, int index)
            : base(name)
        {
            mFactor = factor;
            mIndex = index;
        }
        public override double Visit(int depth, int maxDepth)
        {
            var delta = mFactor.UpdateMessage(mIndex);
            return delta;
        }

        private readonly Factor<T> mFactor;
        private readonly int mIndex;
    }

    public class ScheduleSequence<TValue> : ScheduleSequence<TValue, Schedule<TValue>>
    {
        public ScheduleSequence(string name, IEnumerable<Schedule<TValue>> schedules)
            : base(name, schedules)
        {
        }
    }

    public class ScheduleSequence<TValue, TSchedule> : Schedule<TValue>
        where TSchedule : Schedule<TValue>
    {
        public ScheduleSequence(string name, IEnumerable<TSchedule> schedules)
            : base(name)
        {
            mSchedules = schedules;
        }

        public override double Visit(int depth, int maxDepth)
        {
            var maxDelta = 0.0;
            foreach (TSchedule currentSchedule in mSchedules)
            {
                maxDelta = Math.Max(currentSchedule.Visit(depth + 1, maxDepth), maxDelta);
            }

            return maxDelta;
        }

        private readonly IEnumerable<TSchedule> mSchedules;
    }

    public class ScheduleLoop<T> : Schedule<T>
    {
        public ScheduleLoop(string name, Schedule<T> scheduleToLoop, double maxDelta)
            : base(name)
        {
            mScheduleToLoop = scheduleToLoop;
            mMaxDelta = maxDelta;
        }

        public override double Visit(int depth, int maxDepth)
        {
            int totalIterations = 1;
            var delta = mScheduleToLoop.Visit(depth + 1, maxDepth);
            while (delta > mMaxDelta)
            {
                delta = mScheduleToLoop.Visit(depth + 1, maxDepth);
                totalIterations++;
            }

            return delta;
        }

        private readonly double mMaxDelta;
        private readonly Schedule<T> mScheduleToLoop;
    }
}
