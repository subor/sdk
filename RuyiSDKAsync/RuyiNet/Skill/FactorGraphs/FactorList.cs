using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    public class FactorList<TValue>
    {
        public double LogNormalization
        {
            get
            {
                mList.ForEach(f => f.ResetMarginals());

                var sumLogZ = 0.0;

                for (var i = 0; i < mList.Count; ++i)
                {
                    var f = mList[i];
                    for (var j = 0; j < f.NumberOfMessages; ++j)
                    {
                        sumLogZ += f.SendMessage(j);
                    }
                }

                var sumLogs = mList.Aggregate(0.0, (acc, fac) => acc + fac.LogNormalization);
                return sumLogZ + sumLogs;
            }
        }

        public Factor<TValue> AddFactor(Factor<TValue> factor)
        {
            mList.Add(factor);
            return factor;
        }

        public int Count { get { return mList.Count; } }

        private readonly List<Factor<TValue>> mList = new List<Factor<TValue>>();
    }
}
