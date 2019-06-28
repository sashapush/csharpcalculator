using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorcalc
{
    class Calculator
    {
        static BasicOperation result;
        public static void startCalculator()
        {
            while (!false)
            {
                result = MainMenu.startMenu();
                if (result != null)
                    MainMenu.calculateObjectFromMenu(result);
            }
            //Calculator.SetInputsForMathOperation(operation);
            //BasicOperation.SetInputsForMathOperation(operation);
            //operation.Calculate();   //беру объект, считаю результат
            //operation.LastResult = operation.Result;
            //return operation;
        }



    }
}
