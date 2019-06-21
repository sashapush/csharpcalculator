using System;

namespace refactorcalc
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicOperation operation =  MainMenu.displayMenu();
            operation.Calculate();   //беру объект, считаю результат

            //добавить историю и проверку на наличие записей в ней.
            //использование результата.

            //вынести всё вышенаписанное в Calculator class,
            
            //to move to calculator class;
            //history add log
            //operation.Calculate(MainMenu.displayMenu()); 

        }
    }
}