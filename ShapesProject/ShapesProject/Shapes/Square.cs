using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class Square : IShape
    {
        public Square(double width)
        {
            this.Width = width;
        }
        public double Width { get; set; }

        public double GetArae()
        {
            if (Width != 0)
            {
                return Width * Width;
            }
            return 0;
        }

        public double GetCircumference()
        {
            if (Width != 0)
            {
                return Width * 4;
            }
            return 0;
        }
    }
}
