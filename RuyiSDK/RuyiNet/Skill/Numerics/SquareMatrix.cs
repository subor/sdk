using System;

namespace Ruyi.SDK.Online
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(params double[] allValues)
        {
            Rows = (int)Math.Sqrt(allValues.Length);
            Columns = Rows;

            var allValuesIndex = 0;

            _MatrixRowValues = new double[Rows][];
            for (var currentRow = 0; currentRow < Rows; ++currentRow)
            {
                var currentRowValues = new double[Columns];
                _MatrixRowValues[currentRow] = currentRowValues;

                for (int currentColumn = 0; currentColumn < Columns; ++currentColumn)
                {
                    currentRowValues[currentColumn] = allValues[allValuesIndex++];
                }
            }
        }

        protected override bool IsSquareMatrix()
        {
            return Rows > 0;
        }
    }
}
