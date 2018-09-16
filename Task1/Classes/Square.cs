using System;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public class Square:IShape
    {
        public Point UpperLeft { get; set; }
        public Point LowerRight { get; set; }

        Square(Point upperLeft, Point lowerRight)
        {
            this.UpperLeft = upperLeft;
            this.LowerRight = lowerRight;
        }
        /// <summary>
        /// We have upperLeft Point and lowerRight
        /// Distance between them is diagonal of our square
        /// From geometry we know that side of square  = diagonal/sqrt(2)
        /// Then perimeter = 4*side
        /// </summary>
        /// <returns>
        /// returns perimeter of square
        /// </returns>
        public double CalculatePerimeter()
        {
            var squareSide = Math.Sqrt(2) * Point.CalculateDistanseBetweenPoints(UpperLeft, LowerRight);
            return 4 * squareSide;
        }

        /// <summary>
        /// Same as for previous example
        /// We will calculate side of square
        /// and return square of side 
        /// </summary>
        /// <returns>
        /// side^2
        /// </returns>
        public double CalculateSquare()
        {
            var squareSide = Math.Sqrt(2) * Point.CalculateDistanseBetweenPoints(UpperLeft, LowerRight);
            return Math.Pow(squareSide, 2);
        }
    }
}