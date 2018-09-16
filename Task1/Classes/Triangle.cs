using System;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public class Triangle : IShape
    {
        public Point firstPoint { get; set; }
        public Point secondPoint { get; set; }
        public Point thirdPoint { get; set; }
        public double sideA;
        public double sideB;
        public double sideC;

        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
            this.sideA = Math.Abs(Point.CalculateDistanseBetweenPoints(firstPoint, secondPoint));
            this.sideB = Math.Abs(Point.CalculateDistanseBetweenPoints(secondPoint, thirdPoint));
            this.sideC = Math.Abs(Point.CalculateDistanseBetweenPoints(thirdPoint, firstPoint));

        }
        /// <summary>
        /// We will use Heron formule
        /// S = √p(p - a)(p - b)(p - c)
        /// where p is half perimeter
        /// </summary>
        /// <returns>
        /// returns square value for Triangle;
        /// </returns>

        public double CalculateSquare()
        {
            var halfPerimeter = CalculatePerimeter() / 2;
            return Math.Sqrt(
                halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        }

        public double CalculatePerimeter()
        {
            return sideA + sideB + sideC;
        }
    }
}