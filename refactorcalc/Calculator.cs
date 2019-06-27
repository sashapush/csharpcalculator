using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorcalc
{
    class Calculator
    {
        public static BasicOperation startCalculator()
        {
            Calculator calculator = new Calculator();
            BasicOperation operation = MainMenu.startMenu();
            //Calculator.SetInputsForMathOperation(operation);
            BasicOperation.SetInputsForMathOperation(operation);
            operation.Calculate();   //беру объект, считаю результат
            operation.LastResult = operation.Result;
            return operation;
        }



    }
}
