using System;
using System.Collections.Generic;

namespace preCalc
{
    class Validators
    {
        static bool isValidNumber(string input)//=if(!isValid); ==if (!int.TryParse(Console.ReadLine(), out int resultA))
        {
            double temp2;
            while (!double.TryParse(input, out temp2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input needs to be a number, try again");
                return false;
            }
            return true;
        }
        static bool isValidNumberWhole(string input)  //whole numbers validator to be used in matrix size input;
        {
            int temp2;
            while (!int.TryParse(input, out temp2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input needs to be a whole number, try again");
                return false;
            }
            return true;
        }
    }

    class Program : User
    {
        public static List<History> log = new List<History>();
        static void Main(string[] args)
        {
            //bool exit = false;
            bool toContinue = true;
            while (toContinue)// = while (toCont==true)
            {
                MainMenu();
                Console.WriteLine("Press 'y' to return to the menu or any other key to exit\n <C> Alexander Pushkaryov 2019");
                if (Console.ReadLine() != "y")
                {
                    toContinue = false;
                }
                else Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void MainMenu()
        {
            Console.WriteLine("\nHello and welcome to the calculator 3000 v0.9\nWhat would you like to do? \n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Type in a number from 1 to 7 and confirm it with ENTER key:\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Calculator SUM");
            Console.WriteLine("2) Calculator SUBSCTRACT");
            Console.WriteLine("3) Calculator MULTIPLY");
            Console.WriteLine("4) Calculator DIVISION");
            Console.WriteLine("5) Matrix multiplication");
            Console.WriteLine("6) History of mathematical operations");
            Console.WriteLine("7) Body mass index calculator");
            string result = Console.ReadLine();
            if (result == "1")
            {
                CalculatorSum();
            }
            else if (result == "2")
            {
                CalculatorSubstract();
            }
            else if (result == "3")
            {
                CalculatorMultiply();
            }
            else if (result == "4")
            {
                CalculatorDivision();
            }
            else if (result == "5")
            {
                matrixMultiply();
            }
            else if (result == "6")
            {
                calculatorHistory();
            }
            else if (result == "7")
            {
                User.BMI();
            }
            else
            {
                /*Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter the numbers from 1 to 5");
                MainMenu();
                Console.ForegroundColor = ConsoleColor.White;
             To rework input validato   
             */

            }
        }
        static double inputNumber1()
        {
            double a;
            Console.WriteLine("Input A, decimals and 0 are allowed");
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
            double b;
            Console.WriteLine("Input B, decimals and 0 are allowed");
            var number = Console.ReadLine();
            while (!isValidNumber(number))
            {
                number = Console.ReadLine();
            }
            b = double.Parse(number);
            return b;
        }
        static double inputNumber3()
        {
            double b;
            Console.WriteLine("Input B, decimals are allowed");
            var number = Console.ReadLine();
            while (!isValidNumber(number) || double.Parse(number) == 0)
            {
                if (double.TryParse(number, out b))// && double.Parse(number) == 0)
                {
                    Console.WriteLine("Can't divide by 0,please provide other number");
                    number = Console.ReadLine();
                }
                else
                    number = Console.ReadLine();
            }
            b = double.Parse(number);
            return b;
        }
        static double CalculatorSum()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You've selected SUM operation");
            double a = inputNumber1();
            Console.ForegroundColor = ConsoleColor.Magenta;
            double b = inputNumber2();
            Console.ForegroundColor = ConsoleColor.Magenta;
            double result = a + b;
            Console.WriteLine("{0}+{1}={2}", a, b, result);
            log.Add(new History(a, "+", b, result));
            return result;
        }
        static double CalculatorSubstract()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You've selected SUBSTRACT operation");
            double a = inputNumber1();
            Console.ForegroundColor = ConsoleColor.Gray;
            double b = inputNumber2();
            Console.ForegroundColor = ConsoleColor.Gray;
            double result = a - b;
            Console.WriteLine("{0}-{1}={2}", a, b, result);
            log.Add(new History(a, "-", b, result));
            return result;
        }
        static double CalculatorMultiply()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You've selected MULTIPLY operation");
            double a = inputNumber1();
            Console.ForegroundColor = ConsoleColor.Cyan;
            double b = inputNumber2();
            Console.ForegroundColor = ConsoleColor.Cyan;
            double result = a * b;
            Console.WriteLine("{0}*{1}={2}", a, b, result);
            log.Add(new History(a, "*", b, result));
            return result;
        }
        static double CalculatorDivision()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You've selected DIVISION operation");
            double a = inputNumber1();
            Console.ForegroundColor = ConsoleColor.Yellow;
            double b = inputNumber3();/////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.Yellow;
            double result = a / b;
            Console.WriteLine("{0}/{1}={2}", a, b, result);
            log.Add(new History(a, "/", b, result));
            return result;
        }
        static void calculatorHistory()
        {
            if (log.Count == 0)
            {
                Console.WriteLine("\nYou have no data in history");
            }
            //else if users.Count>1 - output the information from log.
            foreach (History entry in log)
            {
                Console.WriteLine("{0}{1}{2}={3}", entry.A, entry.Operand, entry.B, entry.Result);
            }

        }
        static bool isValidNumber(string input)//=if(!isValid); ==if (!int.TryParse(Console.ReadLine(), out int resultA))
        {
            double temp2;
            while (!double.TryParse(input, out temp2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input needs to be a number, try again");
                return false;
            }
            return true;
        }
        static bool isValidNumberWhole(string input)  //whole numbers validator to be used in matrix size input;
        {
            int temp2;
            while (!int.TryParse(input, out temp2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("input needs to be a whole number, try again");
                return false;
            }
            return true;
        }
        static bool matrixMultiply()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string number; // Needed to work with isValidNumberMethod;
            Console.WriteLine("Please define how many rows and columns your matrices have.\nOnly whole numbers >0 are allowed");
            string presize = Console.ReadLine();
            int x;  // Needed to work with int.TryParse
            while (!isValidNumberWhole(presize) || Convert.ToInt32(presize) < 1)
            {
                if (int.TryParse(presize, out x))// && Convert.ToInt32(presize) <= 0)
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

            //Console displays the size of matrix;
            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] matrixMultiplyResult = new int[n, n];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter {0} elements of the first matrix, separated by ENTER\n", n * n);
            Console.WriteLine("Only whole numbers (0 included) are allowed:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    number = Console.ReadLine();
                    while (!isValidNumber(number))
                    {
                        number = Console.ReadLine();
                    }
                    matrix1[i, j] = Convert.ToInt32(number);
                    //possibly need additional validation on format (to prevent inserting double etc values);
                }
            }
            Console.Write("Enter {0} elements of the second matrix, separated by ENTER:\n", n * n);
            Console.WriteLine("Only whole numbers (0 included) are allowed:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    number = Console.ReadLine();
                    while (!isValidNumber(number))
                    {
                        number = Console.ReadLine();
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
        static void bmiHistory()
        {
            //users;
        }

    }
    class User
    {
        private int id { get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double bmi { get; set; }
        public User()
        {
            // to do incremential ID           id++;
        }
        protected static void BMI()//(string weight, string height, string name)
        {
            bool toStop = true;
            List<User> users = new List<User>();
            while (toStop)
            {
                var user1 = new User();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Hi and welcome to BMI calculator.\nPlease provide you info.\nName:");
                user1.name = Console.ReadLine();
                Console.WriteLine("Height, in cm");
                user1.height = double.Parse(Console.ReadLine());
                Console.WriteLine("Weight, in kg");
                user1.weight = double.Parse(Console.ReadLine());
                user1.bmi = user1.weight / ((user1.height / 100) * (user1.height / 100));
                Console.WriteLine("name {0}\nWeight {1}\nHeight {2}\nBMI {3:N02}\n", user1.name, user1.weight, user1.height, user1.bmi);
                users.Add(user1);
                Console.WriteLine("Would you like to calculate BMI for another user?\nType 'y' and ENTER to confirm or any other key to ESC/ return to Menu;");
                //ESCape from the app/return to menu;
                string reply = Console.ReadLine();
                if (reply == "y") continue;
                else toStop = false;
            }
        }
        /*public User(int id, string name, double weight, double height)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            id++;
        }*/
    }
    class History
    {
        public double Result;// { get; set; }
        public double A;// { get; set; }
        public string Operand;// { get; set; }
        public double B;// { get; set; }
        public History(double a, string operand, double b, double result) //конструктор
        {
            A = a;
            Operand = operand;
            B = b;
            Result = result;
        }
    }

}

