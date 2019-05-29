using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace preCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool exit = false;
            bool toContinue = true;
            while (toContinue)// = while (toCont==true)
            {
                MainMenu();
                Console.WriteLine("Press 'y' to return to the menu or any other key to exit");
                if (Console.ReadLine() != "y")
                {
                    toContinue = false;
                }
                else Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("\nHello and welcome to the calculator 3000 v0.9\nWhat would you like to do? \n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Type in a number and confirm it with ENTER key:\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Calculator SUM");
            Console.WriteLine("2) Calculator SUBSCTRACT");
            Console.WriteLine("3) Calculator MULTIPLY");
            Console.WriteLine("4) Calculator DIVISION");
            Console.WriteLine("5) Matrix multiplication");
            string result = Console.ReadLine();
            if (result == "1")
            {
                CalculatorSum();
                return true;
            }
            else if (result == "2")
            {
                CalculatorSubstract();
                return true;
            }
            else if (result == "3")
            {
                CalculatorMultiply();
                return true;
            }
            else if (result == "4")
            {
                CalculatorDivision();
                return true;
            }
            else if (result == "5")
            {
                matrixMultiply();
                return true;
            }
            else
            {
                return false;
            }
        }
        static double inputNumber1()
        {
            double a = 0;
            Console.WriteLine("Input A, positive number, decimals and 0 are allowed");
            var number = Console.ReadLine();
            while (!isValidNumber(number))
            {
                number = Console.ReadLine();
            }
            a = double.Parse(number);
            return a;
        }
        static double inputNumber2()
        {
            double b = 0;
            Console.WriteLine("Input B, positive number, decimals and 0 are allowed");
            var number = Console.ReadLine();
            while (!isValidNumber(number))
            {
                number = Console.ReadLine();
            }
            b = double.Parse(number);
            return b;
        }
        static double CalculatorSum()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You've selected SUM operation");
            double a = inputNumber1();
            double b = inputNumber2();
            double result = a + b;
            Console.WriteLine("{0}+{1}={2}", a, b, result);
            return result;
        }
        static double CalculatorSubstract()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You've selected SUBSTRACT operation");
            double a = inputNumber1();
            double b = inputNumber2();
            double result = a - b;
            Console.WriteLine("{0}-{1}={2}", a, b, result);
            return result;
        }
        static double CalculatorMultiply()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You've selected MULTIPLY operation");
            double a = inputNumber1();
            double b = inputNumber2();
            double result = a * b;
            Console.WriteLine("{0}*{1}={2}", a, b, result);
            return result;
        }
        static double CalculatorDivision()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You've selected DIVISION operation");
            double a = inputNumber1();
            double b = inputNumber2();
            double result = a / b;
            Console.WriteLine("{0}/{1}={2}", a, b, result);
            return result;
        }
        static bool isValidNumber(string input)//=if(!isValid); ==if (!int.TryParse(Console.ReadLine(), out int resultA))
        {
            double temp2;
            while (!double.TryParse(input, out temp2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input needs to be a number, try again");
                Console.ForegroundColor = ConsoleColor.Green;
                //input = Console.ReadLine();
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return true;
        }

        static bool matrixMultiply()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string number; // Needed to work with isValidNumberMethod;
            Console.WriteLine("Please define how many rows and columns your matrices have.\nOnly numbers >0 are allowed"); 
            // to add validation on <=0
            string presize = Console.ReadLine();
            while (!isValidNumber(presize))
            {
                presize = Console.ReadLine();
            }
            int n = Convert.ToInt32(presize);
            //Console displays the size of matrix;

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] matrixMultiplyResult = new int[n, n];
            
            Console.Write("Enter elements of the first matrix, separated by ENTER\n");
            Console.WriteLine("Only whole numbers (0 included) are allowed:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                    number = Console.ReadLine();
                    while (!isValidNumber(number))
                    {
                        number = Console.ReadLine();
                    }
                    matrix1[i, j] = Convert.ToInt32(number);

                }
            }
            Console.Write("Enter elements of the second matrix, separated by ENTER:\n");
            Console.WriteLine("Only whole numbers (0 included) are allowed:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    number = Console.ReadLine();
                    while (!isValidNumber(number))
                    {
                        number = Console.ReadLine();
                        //matrix1[i, j] = number;
                    }
                    matrix2[i, j] = Convert.ToInt32(number);
                }
            }
            Console.Write("\nFirst matrix is:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", matrix1[i, j]);
            }
            Console.Write("\nSecond matrix is:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", matrix2[i, j]);
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrixMultiplyResult[i, j] = matrix1[i, j] * matrix2[i, j];
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\nResult of matrix multiplication: \n");
            for (int i = 0; i < n; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", matrixMultiplyResult[i, j]);
            }
            Console.Write("\n\n");
            return true;
        }
    }
}

