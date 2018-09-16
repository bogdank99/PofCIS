using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Classes
{
    class Circle : Interfaces.IShape
    {
        public Point centerCoordinates { get; set; }
        public int radius { get; set; }

        public double CalculateSquare()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}