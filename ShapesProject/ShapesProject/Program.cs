using ShapesProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("Please choose action:");
            PrintToConsole();

            eActions action;
            int continuousErrors = 5;
            string validInput = string.Empty;

            for (int i = 0; i < continuousErrors; i++)
            {
                validInput = BusinessLogic.GetValidLetter();
                action = (eActions)Enum.Parse(typeof(eActions), validInput, ignoreCase: true);
                while (BusinessLogic.CheckInputData(action))
                {
                    i = 0;
                    BusinessLogic.FUNCPTR_DICT[action]();
                    Console.WriteLine();
                    Console.WriteLine("Please choose another action:");
                    PrintToConsole();

                    validInput = BusinessLogic.GetValidLetter();
                    action = (eActions)Enum.Parse(typeof(eActions), validInput, ignoreCase: true);
                }

                if (i >= 0)
                {
                    Console.WriteLine("Please enter again!!");
                }
            }
        }

        private static void PrintToConsole()
        {
            Console.WriteLine();
            Console.WriteLine("If you want to Add new shape click '1'");
            Console.WriteLine("If you want to Get all list shapes click '2'");
            Console.WriteLine("If you want to Get Sum All Circumferences click '3'");
            Console.WriteLine("If you want to Get Sum All Areas click '4'");
            Console.WriteLine("If you want to Find Biggest Circumference click '5'");
            Console.WriteLine("If you want to Find Biggest Area click '6'");
            Console.WriteLine("If you want to Exit '-1'");
        }
    }
}
