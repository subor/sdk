namespace Ruyi
{
    public class IdentityMatrix : DiagonalMatrix
    {
        public IdentityMatrix(int rows)
            : base(CreateDiagonal(rows))
        {
        }

        private static double[] CreateDiagonal(int rows)
        {
            var result = new double[rows];
            for (var i = 0; i < rows; ++i)
            {
                result[i] = 1.0;
            }

            return result;
        }
    }
}
