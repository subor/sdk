using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    internal class Vector : Matrix
    {
        public Vector(IList<double> vectorValues)
            : base(vectorValues.Count, 1, new IEnumerable<double>[] { vectorValues })
        {
        }
    }
}
