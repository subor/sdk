using System.Collections.Generic;

namespace Ruyi.SDK.Online
{
    public class DiagonalMatrix : Matrix
    {
        public DiagonalMatrix(IList<double> diagonalValues)
            : base(diagonalValues.Count, diagonalValues.Count)
        {
            for (var i = 0; i < diagonalValues.Count; ++i)
            {
                _MatrixRowValues[i][i] = diagonalValues[i];
            }
        }
    }
}
