using System;
using System.Collections.Generic;
using System.Linq;


namespace refactorcalc
{
    abstract class BasicOperation
    {
        public static List<double[,]> matrixResults = new List<double[,]>();
        public static List<History> log = new List<History>();
        public  double a;
        public static string operand;
        public static double b;
        public static double result;
        public bool useLastResultCalc;
        public BasicOperation basicOperation;
        public double LastResult { get; set; }

        public virtual void Calculate()
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
        }
        private void checkIfUseLastResult(BasicOperation basicOperation=null)
        {
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
                    a = basicOperation.a;
                    break;
                case (false):
                    a = inputNumber();
                    break;
            }
            b = inputNumber();

        }
        public override void Calculate()
        {
            checkIfUseLastResult();
            DisplayResultAndLogHistory(a, b);
            //return basicOperation;
        }
        private void useLastResult()
        {
            a = log.Select(l => l.Result).ToList().Last();   // https://stackoverflow.com/questions/8587872/how-to-get-only-specific-field-from-the-list 
            Console.WriteLine("You're performing SUM operation with the following value: {0}", a);
            b = inputNumber();
            DisplayResultAndLogHistory(a, b);
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
        public override void Calculate()
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
                    base.Calculate();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                base.Calculate();
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
        public override void Calculate()
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
                    base.Calculate();
                    DisplayResultAndLogHistory(a, b);
                }
            }
            else if (log.Count == 0)
            {
                base.Calculate();
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
        public override void Calculate()
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
                    base.Calculate();
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
   
    class History
    {
        public double A;// { get; set; }
        public string Operand;
        public double B;// { get; set; }
        public double Result;
        public List <History> history;
        public History(double a, string operand, double b, double result) //конструктор
        {
            A = a;
            Operand = operand;
            B = b;
            Result = result;
        }
        
        public void addLog(BasicOperation basicOperation)
        {
          //  history.Add(basicOperation);
        }
    }
    class MainMenu
    {
        public static BasicOperation displayMenu()
        {
            bool exit = false;
            BasicOperation result = null;
            while (!exit)
            {
                Console.WriteLine("Hello there. Type in operation '+', '-', '*', '/',  to calculate,\n\"m\" to multiply matrixes,\n\"b\" to calculate body-mass index(BMI)\n\"h\" to view BMI calculations history\n\"H\" to view mathematical operations history \nor 'q' to exit");
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case ("q"):
                        Environment.Exit(0);
                        break;
                    case ("+"):
                        result = new CalculatorSum();
                        //result.Calculate();
                        break;
                    case ("-"):
                        result = new CalculatorSub();
                        //result.Calculate();
                        break;
                    case ("*"):
                        result = new CalculatorMultiply();
                        //result.Calculate();
                        break;
                    case ("/"):
                        result = new CalculatorDivision();
                        //result.Calculate();
                        break;
                    case ("m"):
                        MatrixMultiply.matrixMultiply();
                        break;
                    case ("b"):
                        User.BMI();
                        break;
                    case ("h"):
                        User.bmiHistory();
                        break;
                    case ("H"):
                        BasicOperation.operationsHistory();
                        break;
                    default:
                        Console.WriteLine("Please input one of the following symbols: q + - * / m b h H\n");
                        break;
                }
                return result;
            }
            return result;
        }
    }




}