using System;
using System.Collections.Generic;
using System.IO;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public class Square: IShape,IFileManager
    {
        public Point UpperLeft { get; set; }
        public Point LowerRight { get; set; }
        private List<Point> pointsList = new List<Point>();

        public Square()
        {

        }
        public Square(Point upperLeft, Point lowerRight)
        {
            this.UpperLeft = upperLeft;
            this.LowerRight = lowerRight;
        }

        public override string ToString()
        {
            return $"Square:     ({this.UpperLeft.x},{this.UpperLeft.y})  " +
                   $"({this.LowerRight.x},{this.LowerRight.y}) " +
                   $"square : {this.CalculateSquare().ToString("0.00")}  " +
                   $"perimeter : {this.CalculatePerimeter().ToString("0.00")}";
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

        public List<Point> GetPointsList()
        {
            return this.pointsList;
        }


        public IShape ReadFromFile(string dataLine)
        {
             var bufferObjectData = dataLine.Split(' ');
             var x1 = int.Parse((bufferObjectData[1]));
             var y1 = int.Parse((bufferObjectData[2]));
             var x2 = int.Parse((bufferObjectData[3]));
             var y2 = int.Parse((bufferObjectData[4]));

             Point p1 = new Point(x1,y1);
             Point p2 = new Point(x2,y2);


             Square square = new Square(p1,p2);
             square.pointsList.Add(p1);
             square.pointsList.Add(p2);

            return square;
        }

        public void WriteToFile(StreamWriter sw)
        {
            sw.WriteLineAsync(this.ToString());
            sw.Close();
        }

        }
    }