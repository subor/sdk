using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruyi.SDK.Online
{
    public class Matrix
    {
        private const int FractionalDigitsToRoundTo = 9;
        public static readonly double ErrorTolerance = Math.Pow(0.1, FractionalDigitsToRoundTo);

        protected double[][] _MatrixRowValues;

        protected Matrix()
        {
        }

        public Matrix(int rows, int columns, params double[] allRowValues)
        {
            Rows = rows;
            Columns = columns;

            _MatrixRowValues = new double[rows][];

            int currentIndex = 0;
            for (int currentRow = 0; currentRow < Rows; ++currentRow)
            {
                _MatrixRowValues[currentRow] = new double[Columns];

                for (int currentColumn = 0; currentColumn < Columns; ++currentColumn)
                {
                    if ((allRowValues != null) &&
                        (currentIndex < allRowValues.Length))
                    {
                        _MatrixRowValues[currentRow][currentColumn] = allRowValues[currentIndex++];
                    }
                }
            }
        }

        public Matrix(double[][] rowValues)
        {
            if (!rowValues.All(row => row.Length == rowValues[0].Length))
            {
                throw new ArgumentException("All rows must be the same length!");
            }

            Rows = rowValues.Length;
            Columns = rowValues[0].Length;
            _MatrixRowValues = rowValues;
        }

        protected Matrix(int rows, int columns, double[][] matrixRowValues)
        {
            Rows = rows;
            Columns = columns;
            _MatrixRowValues = matrixRowValues;
        }

        public Matrix(int rows, int columns, IEnumerable<IEnumerable<double>> columnValues)
            : this(rows, columns)
        {
            int columnIndex = 0;
            foreach (var currentColumn in columnValues)
            {
                int rowIndex = 0;
                foreach (var currentColumnValue in currentColumn)
                {
                    _MatrixRowValues[rowIndex++][columnIndex] = currentColumnValue;
                }

                columnIndex++;
            }
        }

        public int Rows { get; protected set; }
        public int Columns { get; protected set; }

        public double this[int row, int column]
        {
            get { return _MatrixRowValues[row][column]; }
            private set { _MatrixRowValues[row][column] = value; }
        }

        public Matrix Transpose
        {
            get
            {
                var transposeMatrix = new double[Columns][];
                for (var currentRowTransposeMatrix = 0; currentRowTransposeMatrix < Columns; ++currentRowTransposeMatrix)
                {
                    var transposeMatrixCurrentRowColumnValues = new double[Rows];
                    transposeMatrix[currentRowTransposeMatrix] = transposeMatrixCurrentRowColumnValues;

                    for (var currentColumnTransposeMatrix = 0; currentColumnTransposeMatrix < Rows; ++currentColumnTransposeMatrix)
                    {
                        transposeMatrixCurrentRowColumnValues[currentColumnTransposeMatrix] = _MatrixRowValues[currentColumnTransposeMatrix][currentRowTransposeMatrix];
                    }
                }

                return new Matrix(Columns, Rows, transposeMatrix);
            }
        }

        private bool IsSquare
        {
            get { return IsSquareMatrix(); }
        }

        protected virtual bool IsSquareMatrix()
        {
            return Rows == Columns && Rows > 0;
        } 

        public Matrix Adjugate
        {
            get
            {
                if (!IsSquare)
                {
                    throw new NotSupportedException("Matrix must be square!");
                }

                if (Rows == 2)
                {
                    double a = _MatrixRowValues[0][0];
                    var b = _MatrixRowValues[0][1];
                    var c = _MatrixRowValues[1][0];
                    var d = _MatrixRowValues[1][1];

                    return new SquareMatrix(d, -b, -c, a);
                }

                var result = new double[Columns][];

                for (var currentColumn = 0; currentColumn < Columns; ++currentColumn)
                {
                    result[currentColumn] = new double[Rows];

                    for (var currentRow = 0; currentRow < Rows; ++currentRow)
                    {
                        result[currentColumn][currentRow] = GetCofactor(currentRow, currentColumn);
                    }
                }

                return new Matrix(result);
            }
        }

        public static Matrix operator *(double scalarValue, Matrix matrix)
        {
            var rows = matrix.Rows;
            var columns = matrix.Columns;
            var newValues = new double[rows][];

            for (var currentRow = 0; currentRow < rows; ++currentRow)
            {
                var newRowColumnValues = new double[columns];
                newValues[currentRow] = newRowColumnValues;

                for (var currentColumn = 0; currentColumn < columns; ++currentColumn)
                {
                    newRowColumnValues[currentColumn] = scalarValue * matrix._MatrixRowValues[currentRow][currentColumn];
                }
            }

            return new Matrix(rows, columns, newValues);
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if ((left.Rows != right.Rows) ||
                (left.Columns != right.Columns))
            {
                throw new ArgumentException("Matrices must be of the same size");
            }

            var resultMatrix = new double[left.Rows][];

            for (int currentRow = 0; currentRow < left.Rows; ++currentRow)
            {
                var rowColumnValues = new double[right.Columns];
                resultMatrix[currentRow] = rowColumnValues;
                for (int currentColumn = 0; currentColumn < right.Columns; ++currentColumn)
                {
                    rowColumnValues[currentColumn] = left._MatrixRowValues[currentRow][currentColumn] +
                                                     right._MatrixRowValues[currentRow][currentColumn];
                }
            }

            return new Matrix(left.Rows, right.Columns, resultMatrix);
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Columns != right.Rows)
            {
                throw new ArgumentException("The width of the left matrix must match the height of the right matrix",
                                            "right");
            }

            int resultRows = left.Rows;
            int resultColumns = right.Columns;

            var resultMatrix = new double[resultRows][];

            for (int currentRow = 0; currentRow < resultRows; ++currentRow)
            {
                resultMatrix[currentRow] = new double[resultColumns];

                for (int currentColumn = 0; currentColumn < resultColumns; ++currentColumn)
                {
                    double productValue = 0;

                    for (int vectorIndex = 0; vectorIndex < left.Columns; ++vectorIndex)
                    {
                        double leftValue = left._MatrixRowValues[currentRow][vectorIndex];
                        double rightValue = right._MatrixRowValues[vectorIndex][currentColumn];
                        double vectorIndexProduct = leftValue * rightValue;
                        productValue += vectorIndexProduct;
                    }

                    resultMatrix[currentRow][currentColumn] = productValue;
                }
            }

            return new Matrix(resultRows, resultColumns, resultMatrix);
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            if ((a.Rows != b.Rows) || (a.Columns != b.Columns))
            {
                return false;
            }

            for (int currentRow = 0; currentRow < a.Rows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < a.Columns; ++currentColumn)
                {
                    double delta =
                        Math.Abs(a._MatrixRowValues[currentRow][currentColumn] -
                                 b._MatrixRowValues[currentRow][currentColumn]);

                    if (delta > ErrorTolerance)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            double result = Rows;
            result += 2 * Columns;

            unchecked
            {
                for (int currentRow = 0; currentRow < Rows; ++currentRow)
                {
                    bool eventRow = (currentRow % 2) == 0;
                    double multiplier = eventRow ? 1.0 : 2.0;

                    for (int currentColumn = 0; currentColumn < Columns; ++currentColumn)
                    {
                        double cellValue = _MatrixRowValues[currentRow][currentColumn];
                        double roundedValue = Math.Round(cellValue, FractionalDigitsToRoundTo);
                        result += multiplier * roundedValue;
                    }
                }
            }

            byte[] resultBytes = BitConverter.GetBytes(result);

            var finalBytes = new byte[4];
            for (int i = 0; i < 4; ++i)
            {
                finalBytes[i] = (byte)(resultBytes[i] ^ resultBytes[i + 4]);
            }

            int hashCode = BitConverter.ToInt32(finalBytes, 0);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Matrix;
            if (other == null)
            {
                return base.Equals(obj);
            }

            return this == other;
        }

        private Matrix Duplicate()
        {
            var newRowValues = new double[Rows][];
            for (var i = 0; i < Rows; ++i)
            {
                newRowValues[i] = new double[Columns];
                for (var j = 0; j < Columns; ++j)
                {
                    newRowValues[i][j] = _MatrixRowValues[i][j];
                }
            }

            return new Matrix(Rows, Columns, newRowValues);
        }

        private static Matrix ZeroMatrix(int rows, int columns)
        {
            var values = new double[rows][];
            for (int i = 0; i < rows; ++i)
            {
                values[i] = new double[columns];
                for (int j = 0; j < columns; ++j)
                {
                    values[i][j] = 0.0;
                }
            }

            return new Matrix(rows, columns, values);
        }

        //------------------------------------------------------------------------------
        //  Determinant
        //------------------------------------------------------------------------------

        public double Determinant
        {
            get
            {
                if (!IsSquare)
                {
                    throw new NotSupportedException("Matrix must be square!");
                }

                if (Rows == 1)
                {
                    return _MatrixRowValues[0][0];
                }

                if (Rows == 2)
                {
                    var a = _MatrixRowValues[0][0];
                    var b = _MatrixRowValues[0][1];
                    var c = _MatrixRowValues[1][0];
                    var d = _MatrixRowValues[1][1];

                    return a * d - b * c;
                }

                var result = GetDeterminantByLUDecomposition();
                if (Math.Abs(result) <= ErrorTolerance)
                {
                    result = 0.0;
                }

                return result;
            }
        }

        //------------------------------------------------------------------------------
        //  Inverse
        //------------------------------------------------------------------------------

        public Matrix Inverse
        {
            get
            {
                if ((Rows == 1) &&
                    (Columns == 1))
                {
                    return new SquareMatrix(1.0 / _MatrixRowValues[0][0]);
                }

                return GetInverseByLUDecomposition();
            }
        }

        //------------------------------------------------------------------------------
        //  Adjugate Method
        //------------------------------------------------------------------------------

        public Matrix GetInverseByAdjugate()
        {
            return (1.0 / Determinant) * Adjugate;
        }

        //------------------------------------------------------------------------------
        //  Brute Force Method
        //------------------------------------------------------------------------------

        private double GetDeterminantByBruteForce()
        {
            var result = 0.0;

            for (int currentColumn = 0; currentColumn < Columns; ++currentColumn)
            {
                var firstRowColValue = _MatrixRowValues[0][currentColumn];
                if (firstRowColValue != 0.0)
                {
                    result += firstRowColValue * GetCofactor(0, currentColumn);
                }
            }

            return result;
        }

        private double GetCofactor(int rowToRemove, int columnToRemove)
        {
            int sum = rowToRemove + columnToRemove;
            bool isEven = (sum % 2 == 0);

            if (isEven)
            {
                return GetMinorMatrix(rowToRemove, columnToRemove).Determinant;
            }
            else
            {
                return -1.0 * GetMinorMatrix(rowToRemove, columnToRemove).Determinant;
            }
        }

        private Matrix GetMinorMatrix(int rowToRemove, int columnToRemove)
        {
            var result = new double[Rows - 1][];
            var resultRow = Rows - 2;

            for (var currentRow = Rows - 1; currentRow >= 0; --currentRow)
            {
                if (currentRow == rowToRemove)
                {
                    continue;
                }

                result[resultRow] = new double[Columns - 1];

                var resultColumn = Rows - 2;

                for (var currentColumn = Columns - 1; currentColumn >= 0; --currentColumn)
                {
                    if (currentColumn == columnToRemove)
                    {
                        continue;
                    }

                    result[resultRow][resultColumn] = _MatrixRowValues[currentRow][currentColumn];
                    --resultColumn;
                }

                --resultRow;
            }

            return new Matrix(Rows - 1, Columns - 1, result);
        }

        //------------------------------------------------------------------------------
        //  LU Decomposition
        //------------------------------------------------------------------------------

        private double GetDeterminantByLUDecomposition()
        {
            if (L == null)
            {
                MakeLU();
            }

            var result = detOfP;
            for (int i = 0; i < Rows; ++i)
            {
                result *= U[i, i];
            }

            return result;
        }

        private Matrix GetInverseByLUDecomposition()
        {
            if (L == null)
            {
                MakeLU();
            }

            Matrix inv = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                Matrix Ei = Matrix.ZeroMatrix(Rows, 1);
                Ei[i, 0] = 1;
                Matrix col = SolveWith(Ei);

                for (int j = 0; j < Rows; j++)
                {
                    inv[j, i] = col[j, 0];
                }
            }

            return inv;
        }

        private Matrix SolveWith(Matrix v) 
        {
            if (Rows != v.Rows)
            {
                throw new ArgumentException("Wrong number of results in solution vector!");
            }

            if (L == null)
            {
                MakeLU();
            }

            Matrix b = new Matrix(Rows, 1);
            for (int i = 0; i < Rows; i++)
            {
                b[i, 0] = v[pi[i], 0];
            }

            Matrix z = SubsForth(L, b);
            Matrix x = SubsBack(U, z);

            return x;
        }

        private static Matrix SubsForth(Matrix A, Matrix b)
        {
            if (A.L == null) A.MakeLU();
            int n = A.Rows;
            Matrix x = new Matrix(n, 1);

            for (int i = 0; i < n; i++)
            {
                x[i, 0] = b[i, 0];
                for (int j = 0; j < i; j++)
                {
                    x[i, 0] -= A[i, j] * x[j, 0];
                }

                x[i, 0] = x[i, 0] / A[i, i];
            }

            return x;
        }

        private static Matrix SubsBack(Matrix A, Matrix b)   
        {
            if (A.L == null) A.MakeLU();
            int n = A.Rows;
            Matrix x = new Matrix(n, 1);

            for (int i = n - 1; i > -1; i--)
            {
                x[i, 0] = b[i, 0];
                for (int j = n - 1; j > i; j--)
                {
                    x[i, 0] -= A[i, j] * x[j, 0];
                }

                x[i, 0] = x[i, 0] / A[i, i];
            }

            return x;
        }

        private Matrix L;
        private Matrix U;
        private int[] pi;
        private double detOfP = 1;

        public void MakeLU()
        {
            if (!IsSquare)
            {
                throw new NotSupportedException("Matrix must be square!");
            }

            L = new IdentityMatrix(Rows);
            U = Duplicate();

            pi = new int[Rows];
            for (var i = 0; i < Rows; ++i)
            {
                pi[i] = i;
            }

            var p = 0.0;
            double pom2;
            var k0 = 0;
            var pom1 = 0;

            for (var k = 0; k < Columns - 1; ++k)
            {
                p = 0;
                for (var i = k; i < Rows; ++i)
                {
                    if (Math.Abs(U[i, k]) > p)
                    {
                        p = Math.Abs(U[i, k]);
                        k0 = i;
                    }
                }

                if (p == 0)
                {
                    throw new NotSupportedException("The matrix is singular!");
                }

                pom1 = pi[k];
                pi[k] = pi[k0];
                pi[k0] = pom1;

                for (var i = 0; i < k; ++i)
                {
                    pom2 = L[k, i];
                    L[k, i] = L[k0, i];
                    L[k0, i] = pom2;
                }

                if (k != k0)
                {
                    detOfP *= -1;
                }

                for (var i = 0; i < Columns; ++i)
                {
                    pom2 = U[k, i];
                    U[k, i] = U[k0, i];
                    U[k0, i] = pom2;
                }

                for (var i = k + 1; i < Rows; ++i)
                {
                    L[i, k] = U[i, k] / U[k, k];
                    for (var j = k; j < Columns; ++j)
                    {
                        U[i, j] = U[i, j] - L[i, k] * U[k, j];
                    }
                }
            }
        }
    }
}
