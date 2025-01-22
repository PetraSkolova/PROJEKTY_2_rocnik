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

            Random r = new Random();
            int random = r.Next(1, 4);

            char priradenie;

            switch (random)
            {
                case 1:
                    priradenie = 'a';
                    break;
                case 2:
                    priradenie = 'b';
                    break;
                case 3:
                    priradenie = 'c';
                    break;
                default:
                    priradenie= '?'; // Bezpečnostné opatrenie, ktoré by sa nemalo nikdy spustiť
                    break;
            }

            Console.WriteLine($"Vygenerované číslo: {random}, priradené písmeno: {priradenie}");
        }
    }
}