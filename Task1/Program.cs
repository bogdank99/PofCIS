using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Shapes.Classes;
using Shapes.Interfaces;
using Task1.BL;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine("Program worked well.Press any key to exit");
            Console.ReadKey();
        }
    }
}
