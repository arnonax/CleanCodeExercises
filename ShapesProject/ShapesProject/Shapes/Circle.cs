using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double GetArae()
        {
            if (Radius != 0)
            {
                return Radius * 3.141 * 2; 
            }
            return 0;
        }

        public double GetCircumference()
        {
            if (Radius != 0)
            {
                return 3.141 * Radius * Radius; 
            }
            return 0;
        }
    }
}
