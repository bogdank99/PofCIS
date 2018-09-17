using System.Collections.Generic;
using System.IO;

namespace Shapes.Interfaces
{
    public interface IFileManager
    {
        void WriteToFile(StreamWriter sw);
        IShape ReadFromFile(string path);
    }
}
