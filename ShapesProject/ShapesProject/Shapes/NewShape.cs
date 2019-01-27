using ShapesProject.Enums;
using ShapesProject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class NewShape
    {
        public NewShape()
        {

        }

        public static Dictionary<IShape, ShapeObject> shapesDic = new Dictionary<IShape, ShapeObject>();
        public static Dictionary<eShapes, Action> ADD_SHAPE = new Dictionary<eShapes, Action>()
        {
            { eShapes.Circle, Circle },
            { eShapes.Rectangle, Rectangle },
            { eShapes.RightTriangle, RightTriangle},
            { eShapes.Square, Square }
        };

        private static void Circle()
        {
            double radius = 0;
            Console.WriteLine("Please enter width");

            while(!double.TryParse(Console.ReadLine(),out radius))
            {
                Console.WriteLine("Invalid, Please enter radius again!!");
            }

            Circle circle = new Shapes.Circle(radius);

            shapesDic.Add(circle, new ShapeObject(
                                    circle.GetCircumference(), 
                                    circle.GetArae(),
                                    "radius=" + circle.Radius.ToString()));

            Console.WriteLine("Circle added successfuly");
            Console.WriteLine();
        }

        private static void Rectangle()
        {
            double width = 0;
            double height = 0;

            Console.WriteLine("Please enter width");
            while (!double.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Invalid, Please enter width again!!");
            }

            Console.WriteLine("Please enter height");
            while (!double.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Invalid, Please enter height again!!");
            }

            Rectangle rectangle = new Shapes.Rectangle(width, height);

            shapesDic.Add(rectangle, new ShapeObject(
                                   rectangle.GetCircumference(),
                                   rectangle.GetArae(),
                                   "width=" + rectangle.Width.ToString() + ", height=" + rectangle.Height.ToString()));

            Console.WriteLine("Rectangle added successfuly");
            Console.WriteLine();
        }

        private static void RightTriangle()
        {
            double width = 0;
            double height = 0;

            Console.WriteLine("Please enter width");
            while (!double.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Invalid, Please enter width again!!");
            }

            Console.WriteLine("Please enter height");
            while (!double.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Invalid, Please enter height again!!");
            }

            RightTriangle rightTriangle = new Shapes.RightTriangle(width, height);

            shapesDic.Add(rightTriangle, new ShapeObject(
                                   rightTriangle.GetCircumference(),
                                   rightTriangle.GetArae(),
                                   "width=" + rightTriangle.Width.ToString() + ", height=" + rightTriangle.Height.ToString()));

            Console.WriteLine("Right Triangle added successfuly");
            Console.WriteLine();
        }

        private static void Square()
        {
            double width = 0;
            Console.WriteLine("Please enter width");

            while (!double.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Invalid, Please enter width again!!");
            }

            Square square = new Shapes.Square(width);

            shapesDic.Add(square, new ShapeObject(
                                    square.GetCircumference(),
                                    square.GetArae(),
                                    "width=" + square.Width.ToString()));

            Console.WriteLine("Square added successfuly");
            Console.WriteLine();
        }
    }
}
