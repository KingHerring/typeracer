using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TypeRacer
{
    class Program
    {

        static void Main(string[] args)
        {
            String key = null;
            do
            {
                Game g = new Game();
                Console.WriteLine("Enter 'y' to continue");
                key = Console.ReadLine();

            } while (key.Equals("y"));
        }

    }
}
