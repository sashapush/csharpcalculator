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
                Console.WriteLine("Press 'y' to continue or any other key to exit");
                if (Console.ReadLine() != "y")
                {
                    toContinue = false;
                }
                else Console.ForegroundColor = ConsoleColor.White;

            }
        }
        /*static (double, double) inputNumbers() {
            double a=0,b = 0;
            Console.WriteLine("Input A");
            var number = Console.ReadLine();
            if (isValidNumber(number))
            {
                a = int.Parse(number);
            }
            //else continue;//добавить доп запрос на повторный инпут
            Console.WriteLine("a={0}", a);
            Console.WriteLine("Input B");
            number = Console.ReadLine();
            if (isValidNumber(number))
            {
                b = int.Parse(number);
            } //else continue;//добавить доп запрос на повторный инпут
            Console.WriteLine("b={0}", b);
            return (a,b);
        }*/  //получение двух переменных.,
        static double inputNumber1()
        {
            double a = 0;
            Console.WriteLine("Input A");
            var number = Console.ReadLine();
            if (isValidNumber(number))
            {
                a = int.Parse(number);
            }
            //else continue;//добавить доп запрос на повторный инпут
            //Console.WriteLine("a={0}", a);
            return a;
        }
        static double inputNumber2()
        {
            double b = 0;
            Console.WriteLine("Input B");
            var number = Console.ReadLine();
            if (isValidNumber(number))
            {
                b = int.Parse(number);
            }
            //else continue;//добавить доп запрос на повторный инпут
           // Console.WriteLine("b={0}", b);
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
        static bool isValidNumber(string input) // = if (!isValid); ==if (!int.TryParse(Console.ReadLine(), out int resultA))
        {
            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("input needs to be a whole number");
                return false;
            }
            else if (result < 0)
            {
                Console.WriteLine("input needs to be a positive or 0");
                return false;
            }
            else return true;
        }
        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Calculator SUM");
            Console.WriteLine("2) Calculator SUBSCTRACT");
            Console.WriteLine("3) Calculator MULTIPLY");
            Console.WriteLine("4) Calculator DIVISION");
            Console.WriteLine("5) Matrix sum");
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
                //CalculatorMatrix();
                return true;
            }
            else
            {
                return false;
            }
        }
        /* static int Result(int a, int b, string input)
         {
             if (input == "+")
             {
                 return a + b;
             }
             else if (input == "-")
             {
                 return a - b;
             }
             else if (input == "*")
             {
                 return a * b;
             }
             else if (input == "/")
             {
                 return a / b;
             }
             else return 0;
             Console.WriteLine("operator not valid");
             */
    }
}
/*   int[] matrix1 = new int[2];
                  int[] matrix2 = new int[2];
                  //заполнение Матрицы циклом
                  for (int i = 0; i < matrix1.Length; i++)
                  {
                      Console.WriteLine("Input {0} element of the {1} matrix", i, matrix1);
                      matrix1[i] = int.Parse(Console.ReadLine());
                      //matrix1[i] = input;
                  }
                  Console.Write("Matrix 1 is:[");
                  for (int i = 0; i < matrix1.Length; i++)
                  {
                      Console.Write("{0} ", matrix1[i]);
                      //matrix1[i] = input;
                  }
                  Console.Write("]");
                  //вывод заполненного массива1
                 */
