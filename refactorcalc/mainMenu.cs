﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorcalc
{
    class MainMenu
    {
        public static void calculateObjectFromMenu(BasicOperation result)
        {
            result.SetInputsForMathOperation(result);
            result.Calculate();
        }
        public static BasicOperation startMenu()
        {
            BasicOperation result = null;
            Console.WriteLine("Hello there. Type in operation '+', '-', '*', '/',  to calculate,\n\"m\" to multiply matrixes,\n\"b\" to calculate body-mass index(BMI)\n\"h\" to view BMI calculations history\n\"H\" to view mathematical operations history \nor 'q' to exit");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case ("+"):
                    result = new CalculatorSum();
                    //calculateObjectFromMenu(result);
                    return result;
                case ("-"):
                    result = new CalculatorSub();
                    //result.SetInputsForMathOperation(result);
                    //calculateObjectFromMenu(result);
                    return result;
                case ("*"):
                    result = new CalculatorMultiply();
                    //calculateObjectFromMenu(result);
                    return result;
                case ("/"):
                    result = new CalculatorDivision();
                    //calculateObjectFromMenu(result);
                    return result;
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
            }return null;
        }
    }
}


