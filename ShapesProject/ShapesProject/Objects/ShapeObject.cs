using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Objects
{
    public class ShapeObject
    {
        public ShapeObject(double area, double circumference, string properties)
        {
            this.Area = area;
            this.Circumference = circumference;
            this.Properties = properties;
        }

        public double Area { get; set; }
        public double Circumference { get; set; }
        public string Properties { get; set; }

    }
}
