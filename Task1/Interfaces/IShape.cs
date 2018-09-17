using Shapes.Classes;
using System.Collections.Generic;

namespace Shapes.Interfaces
{
    public interface IShape
    {
        double CalculateSquare();
        double CalculatePerimeter();
        List<Point> GetPointsList();
    }
}