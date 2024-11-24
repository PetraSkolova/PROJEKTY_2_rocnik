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
            StreamReader sr = new StreamReader("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\zakopanie.txt");

            string [,] pole = new string[4, 8];

            // nacita vsetky riadky do poli
            for (int i = 0; i < 4; i++) 
            {
                string riadok = sr.ReadLine();

                string[] tmp = riadok.Split(' ');

                int a = 0;

                // zapise data zo suboru do pola
                while (tmp.Length > 0)
                {
                    if (a == tmp.Length)
                    {
                        break;
                    }
                    pole[i, a] = tmp[a];
                    //Console.WriteLine(pole[i, a]); vypis riadkov pola
                    a++;
                }
            }
            sr.Close();

            // nahodne cisla, aby sa neopakovali
            Random r = new Random();
            string[] random = new string[32];
            List<int> cisla = new List<int>();

            foreach (var i in pole)
            {

                while (true)
                {
                    bool k = true;
                    int nahoda = r.Next(0, 32);

                    foreach (var j in cisla) // "j" je 1 hodnota z pola cisla
                    {
                        if (nahoda == j)
                        {
                            k = false; break;
                        }
                        
                    }
                    if (k) // ak nie je zhoda medzi vygenerovanymi cislami, tak sa to zapise do pola 
                    {
                        random[nahoda] = i;
                        cisla.Add(nahoda);
                        break;
                    }
                }  
            }

            // zapis 4*8
            string b = ""; //prazdny string
            StreamWriter sw = new StreamWriter("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\zakopanie.txt", false);

            for (int i = 0; i < random.Length; i++)
            {

                if ((i + 1) % 8 == 0)    // vypise po 8 cisel
                {
                    b = b + random[i]; // vsetko vypise do jedneho riadku 
                    Console.WriteLine(b);
                    sw.WriteLine(b);
                    b = "";
                }
                else
                {
                    b = b + random[i] + " "; // vsetko vypise do jedneho riadku 
                }
            }
            sw.Close();

            Console.WriteLine("\n========================\n");

            // vypisanie vo forme sedmovych kariet
            int[] karty = new int[32];

            for (int i = 0; i < random.Length; i++) 
            {
                karty[i] = Convert.ToInt32 (random[i]);
            }

            string c = "";

            for (int i = 0; i < karty.Length; i++)
            {
                string karta = "";

                // zada kartam ich farbu
                switch ((karty[i] - 1) / 8)
                {
                    case 0:
                        karta = "Z";
                        break;
                    case 1:
                        karta = "Č";
                        break;
                    case 2:
                        karta = "G";
                        break;
                    case 3:
                        karta = "Ž";
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
                switch ((karty[i]-1) % 8)
                {
                    case 0:
                        karta += "7 ";
                        break;
                    case 1:
                        karta += "8 ";
                        break;
                    case 2:
                        karta += "9 ";
                        break;
                    case 3:
                        karta += "10";
                        break;
                    case 4:
                        karta += "J ";
                        break;
                    case 5:
                        karta += "Q ";
                        break;
                    case 6:
                        karta += "K ";
                        break;
                    case 7:
                        karta += "A ";
                        break;
                }
                if ((i + 1) % 8 == 0)    // vypise po 8 cisel
                {
                    c = c + karta; // na konci riadku neda medzeru
                    Console.WriteLine(c);
                    c = "";
                }
                else
                {
                    c = c + karta + " "; // udava medzeru za kartu
                }
            }
            Console.ReadLine();
        }
    }
}
