using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Classes
{
    /// <summary>
    /// Basic class for working with
    /// geometric figures.
    //  Must define x and y dot's and calculate distanse between points
    /// </summary>
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

       public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static double CalculateDistanseBetweenPoints(Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.x - secondPoint.x, 2) + Math.Pow(firstPoint.y - secondPoint.y, 2));
        }
    }
}
