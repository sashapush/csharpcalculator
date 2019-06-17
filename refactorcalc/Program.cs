﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.displayMenu();
        }
    }
    abstract class BasicOperation
    {
        public static List<History> log = new List<History>();
        public static List<History> matrixLog = new List<History>();
        public static double a;
        public static double b;
        public static double result;

        public virtual void Result()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            a = inputNumber();
            Console.ForegroundColor = ConsoleColor.Magenta;
            b = inputNumber();
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        public static void operationsHistory()
        {
            if (log.Count == 0)
            {
                Console.WriteLine("\nYou have no data in history");
            }
            else foreach (History entry in log)
                {
                    Console.WriteLine("{0}{1}{2}={3}", entry.A, entry.Operand, entry.B, entry.Result);
                }
        }
        public static bool closeApp(string a)
        {
            if (a == "q")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exit command recognized, are you sure you want to Exit?\nPress \"y\" to confirm");
                if (Console.ReadLine() == "y")
                {
                    Environment.Exit(0);
                    return true;
                }
                else Console.WriteLine("Exit command suspended. Please proceed with entering the data.");
            }
            return false;
        }
        public static bool isValidNumberWhole(string input)  //whole numbers validator to be used in matrix size input;
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
        public virtual double inputNumber()
        {
            double a;
            Console.WriteLine("Please enter a number, decimals and 0 are allowed\nOr type \"q\" to exit");
            var number = Console.ReadLine();
            if (!closeApp(number))
            {
                while (!isValidNumber(number))
                {
                    number = Console.ReadLine();
                    closeApp(number);
                }
            }
            a = double.Parse(number);
            return a;
        }
        public static double inputNumber1()
        {
            double a;
            Console.WriteLine("Please enter a number, decimals and 0 are allowed\nOr type \"q\" to exit");
            var number = Console.ReadLine();
            if (!closeApp(number))
            {
                while (!isValidNumber(number))
                {
                    number = Console.ReadLine();
                    closeApp(number);
                }
            }
            a = double.Parse(number);
            return a;
        }
        public static bool isValidNumber(string input)//=if(!isValid); ==if (!int.TryParse(Console.ReadLine(), out int resultA))
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
    }
    class CalculatorSum : BasicOperation
    {
        protected void DisplayResultAndLogHistory(double a, double b)
        {
            result = a + b;
            Console.WriteLine("{0}+{1}={2}\n", a, b, result);
            log.Add(new History(a, "+", b, result));
        }

        private void useLastResult()
        {
            a = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing SUM operation with the following value: {0}", a);
            b = inputNumber();
            DisplayResultAndLogHistory(a, b);
        }
        public override void Result()
        {
            if (log.Count > 0)
            {
                Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    useLastResult();
                }
                else
                {
                    base.Result();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                base.Result();
                DisplayResultAndLogHistory(a, b);
            }
        }
    }
    class CalculatorSub : BasicOperation
    {
        private void useLastResult()
        {
            a = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing SUBSTRACT operation with the following value: {0}", a);
            b = inputNumber();
            DisplayResultAndLogHistory(a, b);
        }
        protected void DisplayResultAndLogHistory(double a, double b)
        {
            result = a - b;
            Console.WriteLine("{0}-{1}={2}\n", a, b, result);
            log.Add(new History(a, "-", b, result));
        }
        public override void Result()
        {
            if (log.Count > 0)
            {
                Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    useLastResult();
                }
                else
                {
                    base.Result();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                base.Result();
                DisplayResultAndLogHistory(a, b);
            }
        }
    }
    class CalculatorMultiply : BasicOperation
    {
        private void useLastResult()
        {
            a = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing MULTIPLY operation with the following value: {0}", a);
            b = inputNumber();
            DisplayResultAndLogHistory(a, b);
        }
        protected void DisplayResultAndLogHistory(double a, double b)
        {
            result = a * b;
            Console.WriteLine("{0}*{1}={2}\n", a, b, result);
            log.Add(new History(a, "*", b, result));
        }
        public override void Result()
        {
            if (log.Count > 0)
            {
                Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    useLastResult();
                }
                else
                {
                    base.Result();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                base.Result();
                DisplayResultAndLogHistory(a, b);
            }
        }
    }
    class CalculatorDivision : BasicOperation
    {
        private void useLastResult()
        {
            a = log.Select(l => l.Result).ToList().Last();  // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing DIVISION operation with the following value: {0}", a);
            b = inputNumber();
            DisplayResultAndLogHistory(a, b);
        }

        protected void DisplayResultAndLogHistory(double a, double b)
        {
            result = a / b;
            Console.WriteLine("{0}/{1}={2}\n", a, b, result);
            log.Add(new History(a, "/", b, result));
        }
        public override double inputNumber()
        {
            double b;
            Console.WriteLine("Input second number, decimals are allowed, 0 is forbidden");
            var number = Console.ReadLine();
            while (!isValidNumber(number) || double.Parse(number) == 0)
            {
                if (double.TryParse(number, out b))
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
        public override void Result()
        {
            if (log.Count > 0)
            {
                Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
                var answer = Console.ReadLine();
                if (answer == "y")
                {
                    useLastResult();
                }
                else
                {
                    base.Result();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                a = base.inputNumber();
                b = inputNumber();
                DisplayResultAndLogHistory(a, b);
            }
        }
    }
    class MatrixMultiply : BasicOperation
    {
        private static int defineMatrixSize()
        {
            string presize = Console.ReadLine();
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
        private static void fillMatrixWithInput(int n, int m, Matrix[,] matrix)
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
                    matrix[i, j] = number.ToString;
                }
            }
        }
        //private static void displayInputedMatrix(int n, int m, Matrix[,] matrix)
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        Console.Write("\n");
        //        for (int j = 0; j < m; j++)
        //        {
        //            Console.Write("{0}\t", matrix[i, j]);
        //        }
        //    }

        //}
        //private static void calcualteMatrixMultiplicationResult(int n, int m, Matrix[,] matrix1, Matrix[,] matrix2, Matrix[,] resultingMatrix)
        //{
        //    for (int i = 0; i < n; i++)
        //        for (int j = 0; j < m; j++)
        //            resultingMatrix[i, j] = matrix1[i, j] * matrix2[i, j];
        //    Console.ForegroundColor = ConsoleColor.DarkGreen;
        //}
        //private static void displayMultiplicationResult(int n, int m, Matrix[,] resultingMatrix)
        //{
        //    Console.Write("\nResult of matrix multiplication: \n");
        //    for (int i = 0; i < n; i++)
        //    {
        //        Console.Write("\n");
        //        for (int j = 0; j < m; j++)
        //        {
        //            //log.Add(new History(resultingMatrix[i, j]));
        //            Console.Write("{0}\t", resultingMatrix[i, j]);
        //        }

        //    }
        //    Console.Write("\n\n");
        //}
        public static void matrixMultiply()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please define how many rows your matrices have.\nOnly whole numbers >0 are allowed");
            int n = defineMatrixSize();
            Console.WriteLine("Please define how many columns your matrices have.\nOnly whole numbers >0 are allowed");
            int m = defineMatrixSize();
            Matrix[,] matrix1 = new Matrix[n, m];// { { 1, 2 } };
            matrix1.SetValue(2,0,0);
            Matrix[,] matrix2 = new Matrix[n, m];
            Matrix[,] matrixMultiplyResult = new Matrix[n, m];
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write("Enter {0} elements of the first matrix, separated by ENTER\n", n * m);
            //fillMatrixWithInput(n, m, matrix1);
            //Console.Write("Enter {0} elements of the second matrix, separated by ENTER:\n", n * m);
            //fillMatrixWithInput(n, m, matrix2);
            //Console.Write("\nFirst matrix is:");
            //displayInputedMatrix(n, m, matrix1);
            //Console.Write("\nSecond matrix is:");
            //displayInputedMatrix(n, m, matrix2);
            //calcualteMatrixMultiplicationResult(n, m, matrix1, matrix2, matrixMultiplyResult);
            //displayMultiplicationResult(n, m, matrixMultiplyResult);
        }
    }
    public class Matrix
    {
        public double v { get; set; }
        public int n { get; set; }
        public int m { get; set; }
    }
    class History
    {
        public double A;// { get; set; }
        public string Operand;
        public double B;// { get; set; }
        public double Result;
        public History(double a, string operand, double b, double result) //конструктор
        {
            A = a;
            Operand = operand;
            B = b;
            Result = result;
        }
        public History(double a)
        {
            A = a;
        }
    }
    class MainMenu
    {
        public static void displayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Hello there. Type in operation symbol to calculate,\n\"m\" to multiply matrixes,\n\"b\" to calculate body-mass index(BMI)\n\"h\" to view BMI calculations history\n\"H\" to view mathematical operations history \nor 'q' to exit");
                string operation = Console.ReadLine();
                if (operation == "q")
                {
                    Environment.Exit(0);
                }
                else if (operation == "+")
                {
                    var result = new CalculatorSum();
                    result.Result();
                }
                else if (operation == "-")
                {
                    var result = new CalculatorSub();
                    result.Result();
                }
                else if (operation == "*")
                {
                    var result = new CalculatorMultiply();
                    result.Result();
                }
                else if (operation == "/")
                {
                    var result = new CalculatorDivision();
                    result.Result();
                }
                else if (operation == "m")
                {
                    MatrixMultiply.matrixMultiply();
                }
                else if (operation == "b")
                {
                    User.BMI();
                }
                else if (operation == "h")
                {
                    User.bmiHistory();
                }
                else if (operation == "H")
                {
                    BasicOperation.operationsHistory();
                }
            }
        }
    }
    class User
    {
        public int id { private get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public double bmi { get; set; }
        static List<User> users = new List<User>();
        public User()
        {
            // to do incremential ID           id++;
        }

        public static void BMI()//(string weight, string height, string name)
        {
            bool toStop = true;
            while (toStop)
            {
                var user1 = new User();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Hi and welcome to BMI calculator.\nPlease provide you info.\nName:");
                user1.name = Console.ReadLine();
                Console.WriteLine("Height, in cm");
                user1.height = BasicOperation.inputNumber1();
                Console.WriteLine("Weight, in kg");
                user1.weight = BasicOperation.inputNumber1();
                user1.bmi = user1.weight / ((user1.height / 100) * (user1.height / 100));
                Console.WriteLine("Name {0}\nWeight {1}\nHeight {2}\nBMI {3:N02}\n", user1.name, user1.weight, user1.height, user1.bmi);
                users.Add(user1);
                Console.WriteLine("Would you like to calculate BMI for another user?\nType 'y' and ENTER to confirm or any other key to ESC/ return to Menu;");
                //ESCape from the app/return to menu;
                string reply = Console.ReadLine();
                if (reply == "y") continue;
                else toStop = false;
            }
        }
        public static void bmiHistory()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nYou have no data in history");
            }
            else Console.WriteLine("Here are the results of BMI calculations:");
            {
                foreach (var user in users)
                {
                    Console.WriteLine("{0}\t Height {1}\t Weight {2}\t BMI {3}", user.name, user.height, user.weight, user.bmi);
                }
                Console.WriteLine("\n");
            }
        }
    }
}

