namespace Shapes.Interfaces
{
    interface IFileManager
    {
        void WriteToFile(string FilePath);
        bool ReadFromFile(string FilePath);
    }
}
