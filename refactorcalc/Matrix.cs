using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorcalc
{
    class MatrixMultiply : BasicOperation
    {
        public static List<double[,]> matrixResults = new List<double[,]>();
        public static int defineMatrixSize(string presize=null)
        {
            if (presize==null)
            { presize = Console.ReadLine(); }
            int x;  // Needed to work with int.TryParse
            while (!isValidNumberWhole(presize) || Convert.ToInt32(presize) < 1)
            {
                if (int.TryParse(presize, out x))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Matrix Size can't be less or equal to 0");
                    presize = Console.ReadLine();
                }
                else
                    presize = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            int n = Convert.ToInt32(presize);
            return n;
        }
        private static void fillMatrixWithInput(int n, int m, double[,] matrix)
        {
            Console.WriteLine("Only whole numbers (0 included) are allowed:\n");
            string number;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    number = Console.ReadLine();
                    while (!isValidNumber(number))
                    {
                        number = Console.ReadLine();
                    }
                    matrix[i, j] = Convert.ToDouble(number); //https://stackoverflow.com/questions/11184534/how-to-initialize-an-array-of-custom-type // уточнить у Игоря, корректно ли заполнен объект.
                }
            }
        }
        private static void displayMatrix(int n, int m, double[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
            }
            Console.WriteLine("\n");
        }
        private static void calcualteMatrixMultiplicationResult(int n, int y, int m, double[,] matrix1, double[,] matrix2, double[,] resultingMatrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    resultingMatrix[i, j] = 0;
                    for (int k = 0; k < m; k++)
                    {
                        resultingMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                        //https://ru.stackoverflow.com/questions/304351/%D0%92%D1%81%D0%B5-%D0%B8%D0%BD%D0%B8%D1%86%D0%B8%D0%B0%D0%BB%D0%B8%D0%B7%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BB-%D0%B2%D0%BE%D0%B7%D0%BD%D0%B8%D0%BA%D0%B0%D0%B5%D1%82-%D0%BE%D1%88%D0%B8%D0%B1%D0%BA%D0%B0%D0%A1%D1%81%D1%8B%D0%BB%D0%BA%D0%B0-%D0%BD%D0%B0-%D0%BE%D0%B1%D1%8A%D0%B5%D0%BA%D1%82-%D0%BD%D0%B5-%D1%83%D0%BA%D0%B0%D0%B7%D1%8B%D0%B2%D0%B0%D0%B5%D1%82-%D0%BD%D0%B0-%D1%8D%D0%BA%D0%B7%D0%B5%D0%BC%D0%BF%D0%BB%D1%8F%D1%80}
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
            }
        }

        private static void inputMatrix(ref int n, ref int m, ref double [,] matrix1)
        {
            Console.WriteLine("Please define how many rows your 1st matrix has.\nOnly whole numbers >0 are allowed");
            n = defineMatrixSize();
            Console.WriteLine("Please define how many columns your 1st matrix has.\nOnly whole numbers >0 are allowed");
            m = defineMatrixSize();
            matrix1 = new double[n, m];
            Console.Write("Enter {0} elements of the first matrix, separated by ENTER\n", n * m);
            fillMatrixWithInput(n, m, matrix1);
            //return matrix1;
        }
        public static void matrixMultiply()
        {
            int n = 0;  //first matrix rows #
            int m = 0;  //first matrix columns #
            double[,] matrix1=null;
            Console.ForegroundColor = ConsoleColor.Green;
            if (matrixResults.Count > 0)
            {
                Console.WriteLine("Press \"y\" to use result of previous matrix caclulation");
                var input = Console.ReadLine();
                switch (input) {
                    case "y":
                        matrix1 = matrixResults[matrixResults.Count - 1];
                        n = matrix1.GetLength(0);
                        //matrix4.Rank;
                        m = matrix1.GetLength(1);
                        Console.WriteLine("Using the following matrix:");
                        displayMatrix(n, m, matrix1);
                        break;
                    default:
                        inputMatrix(ref n, ref m, ref matrix1);
                        break;
                }
            }
            else {
                inputMatrix(ref n, ref m, ref matrix1);
            }
            int x = matrix1.GetLength(1);
            Console.WriteLine("Your 2nd matrix has *{0}* rows for valid multiplication", m);
            Console.WriteLine("Please define how many columns your 2nd matrix has.\nOnly whole numbers >0 are allowed");
            int y = defineMatrixSize();
            double[,] matrix2 = new double[x, y];
            double[,] matrixMultiplyResult = new double[n, y];
            Console.Write("Enter {0} elements of the second matrix, separated by ENTER:\n", x * y);
            fillMatrixWithInput(x, y, matrix2);
            Console.Write("\nFirst matrix is:");
            displayMatrix(n,m,matrix1);
            Console.Write("\nSecond matrix is:");
            displayMatrix(x,y,matrix2);
            calcualteMatrixMultiplicationResult(n, y, m, matrix1, matrix2, matrixMultiplyResult); ////////https://www.tutorialspoint.com/chash-program-to-multiply-two-matrices
            Console.Write("\nMatrixes multiplication result is: ");
            displayMatrix(n, y, matrixMultiplyResult);
            matrixResults.Add(matrixMultiplyResult);
            }
    }
    class Matrix
    {
        public double[,] matrix { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }


        public Matrix(double[,] v)
        {
            this.matrix = v;
        }
    }
}
