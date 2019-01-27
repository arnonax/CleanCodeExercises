using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class RightTriangle : IShape
    {
        public RightTriangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
     
        public double Width { get; set; }
        public double Height { get; set; }

        public double GetArae()
        {
            if (Width != 0 && Height != 0)
            {
                return Width * Height;
            }
            return 0;
        }

        public double GetCircumference()
        {
            if (Width != 0 && Height != 0)
            {
                return Width + Height + (Width * Width + Height * Height);
            }
            return 0;
        }
    }
}
