using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace zakopanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\textove subory\\bludisko.txt");

            while (true)
            {
                string obsah = sr.ReadLine();

                if (obsah == null)
                    break;

                Console.WriteLine(obsah);
            }
        }
    }
}
