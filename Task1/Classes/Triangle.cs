using System;
using System.Collections.Generic;
using System.IO;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public class Triangle : IShape, IFileManager
    {
        public Point firstPoint { get; set; }
        public Point secondPoint { get; set; }
        public Point thirdPoint { get; set; }
        private List<Point> pointsList = new List<Point>();
        public double sideA;
        public double sideB;
        public double sideC;

        public Triangle()
        {

        }
        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
            this.sideA = Math.Abs(Point.CalculateDistanseBetweenPoints(firstPoint, secondPoint));
            this.sideB = Math.Abs(Point.CalculateDistanseBetweenPoints(secondPoint, thirdPoint));
            this.sideC = Math.Abs(Point.CalculateDistanseBetweenPoints(thirdPoint, firstPoint));

        }
        public override string ToString()
        {
            return $"Triangle:   ({this.firstPoint.x},{this.firstPoint.y})  " +
                   $"({this.secondPoint.x},{this.secondPoint.y}) " +
                   $"({this.thirdPoint.x},{this.thirdPoint.y}) " +
                   $"square : {this.CalculateSquare().ToString("0.00")}  perimeter : {this.CalculatePerimeter().ToString("0.00")}";

        }

        public List<Point> GetPointsList()
        {
            return this.pointsList;
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

        public IShape ReadFromFile(string dataLine)
        {
            var bufferObjectData = dataLine.Split(' ');
            var x1 = int.Parse((bufferObjectData[1]));
            var y1 = int.Parse((bufferObjectData[2]));
            var x2 = int.Parse((bufferObjectData[3]));
            var y2 = int.Parse((bufferObjectData[4]));
            var x3 = int.Parse((bufferObjectData[5]));
            var y3 = int.Parse((bufferObjectData[6]));


            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            Point p3 = new Point(x3, y3);

            Triangle triangle = new Triangle(p1, p2, p3);

            triangle.pointsList.Add(p1);
            triangle.pointsList.Add(p2);
            triangle.pointsList.Add(p3);

            return triangle;
        }

        public void WriteToFile(StreamWriter sw)
        {
            sw.WriteLineAsync(this.ToString());
            sw.Close();

        }
    }
}