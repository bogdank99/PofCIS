using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Shapes.Classes;
using Shapes.Interfaces;

namespace Task1.BL
{
    /// <summary>
    /// class created for doing all given tasks
    /// containing logic and doing actions much better here than in main() method
    /// </summary>
    public class Logic
    {
        public List<IShape> listOfShapes = new List<IShape>();
        public Logic()
        {
            listOfShapes = parseDataFromString();
            writeSortedCollectionToFile();
            writeFiguresFromThirdQuarterToFile();
        }
        static List<string> getDataFromFile()
        {
            StreamReader sr = new StreamReader("C://Users//Bohdan//Desktop//PofCIS//Task1//Data//data.txt");
            //Contains list of "raw" strings that have data about figures
            List<string> dataList = new List<string>();
            while (!sr.EndOfStream)
            {
                dataList.Add(sr.ReadLine());
            }
           return dataList;
        }

        static List<IShape> parseDataFromString()
        {
            Circle bufferCircle = new Circle();
            Square bufferSquare = new Square();
            Triangle bufferTriangle = new Triangle();
            List<IShape> bufferShapesList = new List<IShape>();
            foreach (var line in getDataFromFile())
            {
                //spliting each line to get separate values
                var dataFromLine = line.Split(' ');
                string typeOfShape = dataFromLine[0];
                
                switch (typeOfShape)
                {
                    case "Circle":
                        bufferShapesList.Add(bufferCircle.ReadFromFile(line));
                        break;
                    case "Square":
                        bufferShapesList.Add(bufferSquare.ReadFromFile((line)));
                        break;
                    case "Triangle":
                        bufferShapesList.Add(bufferTriangle.ReadFromFile(line));
                        break;
                    default:
                        break;
                }
            }
            return bufferShapesList;
        }

        void writeSortedCollectionToFile()
        {
            var sortedList = listOfShapes.OrderByDescending(shape => shape.CalculatePerimeter());
            var list = sortedList.Reverse();
            StreamWriter sw = new StreamWriter("C://Users//Bohdan//Desktop//PofCIS//Task1//Data//file1.txt", false,System.Text.Encoding.Default);
            sw.WriteLineAsync("Shapes sorted by perimeter(Ascending):");
            foreach (var shape in list)
            {
                sw.WriteLineAsync(shape.ToString());
            }
            sw.Close();
        }

        static bool isInThirdQuarter(IShape shape)
        {
            bool result = true;
            foreach (var point in shape.GetPointsList())
            {
                result = result && ((point.x < 0) && (point.y < 0));
            }
            return result;
        }

        List<IShape> getFiguresFromThirdQuarter()
        {
            List<IShape> figuresFromThirdQuarter = new List<IShape>();
            foreach (var figure in listOfShapes)
            {
                if (isInThirdQuarter(figure))
                {
                    figuresFromThirdQuarter.Add(figure);
                }
                else continue;
            }
            return figuresFromThirdQuarter;
        }

        void writeFiguresFromThirdQuarterToFile()
        {
            StreamWriter sw = new StreamWriter("C://Users//Bohdan//Desktop//PofCIS//Task1//Data//file2.txt", false, System.Text.Encoding.Default);
            sw.WriteLineAsync("Figures from 3rd quarter sorted by perimeter(Descending):");
            var shapesFromThirdQuarter = getFiguresFromThirdQuarter();
            var sortedShapes = shapesFromThirdQuarter.OrderByDescending(shape => shape.CalculatePerimeter());
            foreach (var shape in sortedShapes)
            {
                sw.WriteLineAsync(shape.ToString());
            }
            sw.Close();
        }
    }
}