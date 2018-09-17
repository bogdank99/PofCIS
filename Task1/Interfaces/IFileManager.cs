using System.Collections.Generic;
using System.IO;

namespace Shapes.Interfaces
{
    public interface IFileManager
    {
        void WriteToFile(string FilePath);
        IShape ReadFromFile(string dataString);
    }
}
