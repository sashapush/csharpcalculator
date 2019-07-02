using System;
using System.Collections.Generic;
using System.Linq;


namespace refactorcalc
{
    abstract class BasicOperation
    {
        public double LastResult { get; set; }
        public static List<double[,]> matrixResults = new List<double[,]>();
        public static List<History> log = new List<History>();
        public double A;
        public double B;
        public double Result;
        public bool useLastResultCalc;

        public virtual void Calculate()
        {
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //A = inputNumber();
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //B = inputNumber();
            //Console.ForegroundColor = ConsoleColor.Magenta;
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
        public void SetInputsForMathOperation(BasicOperation operation)
        {
            double input_1;
            double input_2;
            //if (UseLastValue)
                //operation.A = LastResult;
            //else
            
            input_1 = operation.inputNumber();
            operation.A = input_1;
            
            input_2 = operation.inputNumber();
            operation.B = input_2;
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
        public void DisplayResultAndLogHistory(double a, double b)
        {

        }
        public void checkIfUseLastResult(BasicOperation basicOperation = null)
        {
            //check if OperationsHistory is empty;
            Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
            var answer = Console.ReadLine();
            if (answer == "y")
            {
                useLastResultCalc = true;
            }
            else
            {
                Console.WriteLine("Using default calculator flow");
                useLastResultCalc = false;
            }
            switch (useLastResultCalc)
            {
                case (true):
                    A = basicOperation.A;
                    break;
                case (false):
                    A = inputNumber();
                    break;
            }
            B = inputNumber();

        }
        public override void Calculate()
        {
            //checkIfUseLastResult();
            Result = A + B;
            Console.WriteLine("{0}+{1}={2}\n", A, B, Result);
            //return basicOperation;
        }
        private void useLastResult()
        {
            A = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing SUM operation with the following value: {0}", A);
            B = inputNumber();
            DisplayResultAndLogHistory(A, B);
        }
        //public override void Result()
        //{
        //    if (log.Count > 0)
        //    {
        //        Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
        //        var answer = Console.ReadLine();
        //        if (answer == "y")
        //        {
        //            useLastResult(result);
        //        }
        //        else
        //        {
        //            base.Result();
        //            DisplayResultAndLogHistory(a, b);
        //        }
        //    }
        //    else if (log.Count == 0)
        //    {
        //        base.Result();
        //        DisplayResultAndLogHistory(a, b);
        //    }
        //}
    }
    class CalculatorSub : BasicOperation
    {
        private void useLastResult()
        {
            A = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing SUBSTRACT operation with the following value: {0}", A);
            B = inputNumber();
            
        }
        protected void DisplayResultAndLogHistory(double a, double b)
        {
            //Result = a - b;
            //Console.WriteLine("{0}-{1}={2}\n", a, b, Result);
            //log.Add(new History(a, "-", b, Result));
        }
        public override void Calculate()
        {
            //if (log.Count > 0)
            //{
            //    Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
            //    var answer = Console.ReadLine();
            //    if (answer == "y")
            //    {
            //        useLastResult();
            //    }
            //    else
            //    {
            //        base.Calculate();
            //        DisplayResultAndLogHistory(A, B);
            //    }
            //}
            //else if (log.Count == 0)
            //{
            //    base.Calculate();
            //    DisplayResultAndLogHistory(A, B);
            //}
            Result = A - B;
            Console.WriteLine("{0}-{1}={2}\n", A, B, Result);
        }
    }
    class CalculatorMultiply : BasicOperation
    {
        private void useLastResult()
        {
            A = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing MULTIPLY operation with the following value: {0}", A);
            B = inputNumber();
            DisplayResultAndLogHistory(A, B);
        }
        protected void DisplayResultAndLogHistory(double a, double b)
        {
            Result = a * b;
            Console.WriteLine("{0}*{1}={2}\n", a, b, Result);
            log.Add(new History(a,"*",b, Result));
        }
        public override void Calculate()
        {
            //if (log.Count > 0)
            //{
            //    Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
            //    var answer = Console.ReadLine();
            //    if (answer == "y")
            //    {
            //        useLastResult();
            //    }
            //    else
            //    {
            //        base.Calculate();
            //        DisplayResultAndLogHistory(A, B);
            //    }
            //}
            //else if (log.Count == 0)
            //{
            //    base.Calculate();
            //    DisplayResultAndLogHistory(A, B);
            //}
            Result = A * B;
            Console.WriteLine("{0}*{1}={2}\n", A, B, Result);
        }
    }
    class CalculatorDivision : BasicOperation
    {
        private void useLastResult()
        {
            A = log.Select(l => l.Result).ToList().Last();  // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing DIVISION operation with the following value: {0}", A);
            B = inputNumber();
            DisplayResultAndLogHistory(A, B);
        }

        protected void DisplayResultAndLogHistory(double a, double b)
        {
            Result = a / b;
            Console.WriteLine("{0}/{1}={2}\n", a, b, Result);
            log.Add(new History(a, "/", b, Result));
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
        public override void Calculate()
        {
            //if (log.Count > 0)
            //{
            //    Console.WriteLine("Would you like to use history?\nPress \"y\" to use last inputed value. Or any other key to continue the calculation");
            //    var answer = Console.ReadLine();
            //    if (answer == "y")
            //    {
            //        useLastResult();
            //    }
            //    else
            //    {
            //        base.Calculate();
            //        DisplayResultAndLogHistory(A, B);
            //    }
            //}
            //else if (log.Count == 0)
            //{
            //    A = base.inputNumber();
            //    B = inputNumber();
            //    DisplayResultAndLogHistory(A, B);
            //}
            Result = A / B;
            Console.WriteLine("{0}/{1}={2}\n", A, B, Result);
        }
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

        public void AddLog(string record)
        {
            //history.Add(record);
        }
    }





}