using ShapesProject.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ShapesProject
{
    public class BusinessLogic
    {
        public BusinessLogic()
        {
           
        }

        
        public static Dictionary<eActions, Action> FUNCPTR_DICT = new Dictionary<eActions, Action>()
        {
            { eActions.AddNewShape, AddNewShape },
            { eActions.ListAllShapes, ListAllShapes },
            { eActions.SumAllCircumferences, SumAllCircumferences},
            { eActions.SumAllAreas, SumAllAreas },
            { eActions.FindBiggestCircumference, FindBiggestCircumference},
            { eActions.FindBiggestArea, FindBiggestArea},
            { eActions.Exit, Exit}
        };

        private static void AddNewShape()
        {
            PrintToConsole();

            eShapes action;
            string validInput = string.Empty;

            validInput = GetValidLetter();
            action = (eShapes)Enum.Parse(typeof(eShapes), validInput, ignoreCase: true);
            while (!CheckInputData(action))
            {
                Console.WriteLine("Please enter again!!");
                validInput = GetValidLetter();
                action = (eShapes)Enum.Parse(typeof(eShapes), validInput, ignoreCase: true);
            }

            Shapes.NewShape.ADD_SHAPE[action]();
        }

        private static void ListAllShapes()
        {
            Console.WriteLine();

            if (Shapes.NewShape.shapesDic.Count>0)
            {
                Console.WriteLine("All Shapes:");
                foreach (var item in Shapes.NewShape.shapesDic)
                {
                    Console.WriteLine(item.Key.ToString().Split('.').Last() + " : " + item.Value.Properties);
                } 
            }
            else
            {
                Console.WriteLine("There are no existing shapes, Please enter new shape");
            }
        }

        private static void SumAllCircumferences()
        {
            double sum = 0;

            foreach (var circumference in Shapes.NewShape.shapesDic)
            {
                sum = sum + circumference.Value.Circumference;
            }

            Console.WriteLine("Sum of all circumferences is: " + sum.ToString());
            Console.WriteLine();
        }

        private static void SumAllAreas()
        {
            double sum = 0;

            foreach (var area in Shapes.NewShape.shapesDic)
            {
                sum = sum + area.Value.Area;
            }

            Console.WriteLine("Sum of all areas is: " + sum.ToString());
            Console.WriteLine();
        }

        private static void FindBiggestCircumference()
        {
            double bigCircumference = 0;
            string shape = null;

            foreach (var circumference in Shapes.NewShape.shapesDic)
            {
                if (circumference.Value.Circumference > bigCircumference)
                {
                    bigCircumference = circumference.Value.Circumference;
                    shape = circumference.Key.ToString().Split('.').Last();
                }
            }

            if (Shapes.NewShape.shapesDic.Count > 0 )
            {
                Console.WriteLine("The big of all circumferences is: " + shape + " : Circumference=" + bigCircumference.ToString());
                Console.WriteLine(); 
            }
            else
            {
                Console.WriteLine("There are no existing shapes, Please enter new shape");
                Console.WriteLine();
            }
        }

        private static void FindBiggestArea()
        {
            double bigArea = 0;
            string shape = null;

            foreach (var area in Shapes.NewShape.shapesDic)
            {
                if (area.Value.Area > bigArea)
                {
                    bigArea = area.Value.Area;
                    shape = area.Key.ToString().Split('.').Last();
                }
            }

            if (Shapes.NewShape.shapesDic.Count > 0)
            {
                Console.WriteLine("The big of all areas is: " + shape + " : Area=" + bigArea.ToString());
                Console.WriteLine(); 
            }
            else
            {
                Console.WriteLine("There are no existing shapes, Please enter new shape");
                Console.WriteLine();
            }
        }

        private static void Exit()
        {
            Environment.Exit(1);
        }


        private static void PrintToConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose shape to add:");
            Console.WriteLine();
            Console.WriteLine("If you want to Add Circle click '1'");
            Console.WriteLine("If you want to Add Rectangle click '2'");
            Console.WriteLine("If you want to Add Right Triangle click '3'");
            Console.WriteLine("If you want to Add Square click '4'");
        }

        public static bool CheckInputData(eActions action)
        {
            if (action == eActions.AddNewShape ||
                action == eActions.Exit ||
                action == eActions.FindBiggestArea ||
                action == eActions.FindBiggestCircumference ||
                action == eActions.ListAllShapes ||
                action == eActions.SumAllAreas ||
                action == eActions.SumAllCircumferences)
            {
                return true;
            }
            return false;
        }

        public static bool CheckInputData(eShapes action)
        {
            if (action == eShapes.Circle ||
                action == eShapes.Rectangle ||
                action == eShapes.RightTriangle ||
                action == eShapes.Square)
            {
                return true;
            }
            return false;
        }

        public static string GetValidLetter()
        {
            string validInput = string.Empty;
            while (Regex.IsMatch(validInput = Console.ReadLine(), @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Please enter again!!");
            }

            return validInput;
        }
    }
}
