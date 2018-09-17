using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shapes.Interfaces;

namespace Shapes.Classes
{
    public class Circle : IShape, IFileManager
    {   
        public Point center { get; set; }
        public int radius { get; set; }

        public Circle()
        {

        }

        public Circle(Point point, int radius)
        {
            this.center = point;
            this.radius = radius;
        }
        public double CalculateSquare()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return $"Circle:     ({this.center.x},{this.center.y})  radius: {this.radius} " +
                   $"square : {this.CalculateSquare().ToString("0.00")}  perimeter : {this.CalculatePerimeter().ToString("0.00")}";
        }

        public  IShape ReadFromFile(string dataString)
        {
                    var bufferObjectData = dataString.Split(' ');
                    var x = int.Parse((bufferObjectData[1]));
                    var y = int.Parse((bufferObjectData[2]));
                    var radius = int.Parse((bufferObjectData[3]));
                    return (new Circle(new Point(x,y),radius));
        }

        public void WriteToFile(string filePath)
        {

        }
    }
}