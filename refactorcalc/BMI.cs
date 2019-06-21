using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactorcalc

{
    class User
    {
        public int Id { private get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        static List<User> Users = new List<User>();
        public User()
        {
            Id++;
        }
        private static double calculateBMI(double weight, double height)
        {
            var Bmi = weight / ((height / 100) * (height / 100));
            return Bmi;
        }
        private static void addToHistory(User user)
        {
            Users.Add(user);
        }
        private static User inputNewUserData(string name)
        {
            var user1 = new User();
            user1.Name = name;
            Console.WriteLine("Height, in cm");
            user1.Height = BasicOperation.inputNumber1();
            Console.WriteLine("Weight, in kg");
            user1.Weight = BasicOperation.inputNumber1();
            user1.Bmi = calculateBMI(user1.Weight, user1.Height);
            Console.WriteLine("Name {0}\nWeight {1}\nHeight {2}\nBMI {3:N02}\n", user1.Name, user1.Weight, user1.Height, user1.Bmi);
            return user1;
        }
        private static User checkIfUserExists(string name)
        {
            User search = Users.Find(r => r.Name == name);
            if (search != null)
            {
                return search;
            }
            else return null;
        }
        public static void BMI()//(string weight, string height, string name)
        {
            bool toStop = true;
            while (toStop)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Hi and welcome to BMI calculator.");
                bmiHistory();
                Console.WriteLine("Please provide you info.\nName:");
                string checkName = Console.ReadLine();
                User test = checkIfUserExists(checkName);
                if (test != null)
                {
                    Console.WriteLine("User found. Please enter your new weight:");
                    test.Weight = BasicOperation.inputNumber1();
                    test.Bmi = calculateBMI(test.Weight, test.Height);
                    Console.WriteLine("Name {0}\nWeight {1}\nHeight {2}\nBMI {3:N02}\n", test.Name, test.Weight, test.Height, test.Bmi);
                }
                else
                {
                    addToHistory(inputNewUserData(checkName));
                }
                Console.WriteLine("Would you like to calculate BMI for another user?\nType 'y' and ENTER to confirm or any other key to ESC/ return to Menu;");
                //ESCape from the app/return to menu;
                string reply = Console.ReadLine();
                if (reply == "y") continue;
                else toStop = false;
            }
        }
        public static void bmiHistory()
        {
            if (Users.Count == 0)
            {
                Console.WriteLine("\nCurrently You have no data in history");
            }
            else Console.WriteLine("Here are the results of BMI calculations(you can update your BMI by typing the your name from the list below):");
            {
                foreach (var user in Users)
                {
                    Console.WriteLine("{0}\t Height {1}\t Weight {2}\t BMI {3}", user.Name, user.Height, user.Weight, user.Bmi);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
