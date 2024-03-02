namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = { { 3, 7 }, { 1, 9 } };
            int[,] array2 = { { 7, 4 }, { 3, 0 } };

            SquareMatrix matrix1 = new SquareMatrix(array1);
            SquareMatrix matrix2 = new SquareMatrix(array2);

            Console.WriteLine("Matrix 1:");
            matrix1.PrintMatrix();

            Console.WriteLine("\nMatrix 2:");
            matrix2.PrintMatrix();

            SquareMatrix sumMatrix = matrix1 + matrix2;
            SquareMatrix diffMatrix = matrix1 - matrix2;

            Console.WriteLine("\nSum:");
            sumMatrix.PrintMatrix();

            Console.WriteLine("\nDiff:");
            diffMatrix.PrintMatrix();
        }
    }
    public class SquareMatrix
    {
        private int[,] matrix;
        private int size;
        public SquareMatrix(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            size = rows;
            matrix = new int[size, size];
            Array.Copy(array, matrix, array.Length);
        }
        public static SquareMatrix operator +(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.size != matrix2.size)
            {
                throw new ArgumentException("They should be the same by size");
            }

            int[,] resultArray = new int[matrix1.size, matrix1.size];

            for (int i = 0; i < matrix1.size; i++)
            {
                for (int j = 0; j < matrix1.size; j++)
                {
                    resultArray[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
                }
            }

            return new SquareMatrix(resultArray);
        }
        public static SquareMatrix operator -(SquareMatrix matrix1, SquareMatrix matrix2)
        {
            if (matrix1.size != matrix2.size)
            {
                throw new ArgumentException("They should be the same by size");
            }

            int[,] resultArray = new int[matrix1.size, matrix1.size];

            for (int i = 0; i < matrix1.size; i++)
            {
                for (int j = 0; j < matrix1.size; j++)
                {
                    resultArray[i, j] = matrix1.matrix[i, j] - matrix2.matrix[i, j];
                }
            }

            return new SquareMatrix(resultArray);
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
