using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Shapes.Classes;
using Shapes.Interfaces;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("E://LNU//Proga//PofCIS//Task1//Task1//Data//data.txt");
            List<string> dataList = new List<string>();
            while (!sr.EndOfStream)
            {
                dataList.Add(sr.ReadLine());
            }
            List<IShape> shapesList = new List<IShape>();
            Circle bufferCircle = new Circle();
            Square bufferSquare = new Square();
            Triangle bufferTriangle = new Triangle();
            foreach (var line in dataList)
            {
                var dataFromLine = line.Split(' ');
                string typeOfShape = dataFromLine[0];
                switch (typeOfShape)
                {
                    case "Circle":
                        shapesList.Add(bufferCircle.ReadFromFile(line));
                        break;
                    case "Square":
                        shapesList.Add(bufferSquare.ReadFromFile((line)));
                        break;
                    case "Triangle":
                        shapesList.Add(bufferTriangle.ReadFromFile(line));
                        break;
                    default:
                        break;
                }
            }

            foreach (var shape in shapesList)
            {
                Console.WriteLine((shape.ToString()));
            }

            Console.ReadKey();
        }
    }
}
