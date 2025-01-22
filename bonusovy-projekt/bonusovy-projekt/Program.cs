using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bonus2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\textove subory\\bludisko2.txt");
            string[] lines = File.ReadAllLines("C:\\Users\\skola\\Desktop\\Petra škola\\PI1\\textove subory\\bludisko2.txt");
            char[,] bludisko = new char[lines.Length, lines[0].Length];

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
                    priradenie = '?';
                    break;
            }

            // Naplnenie bludiska zo súboru
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    bludisko[i, j] = lines[i][j];
                }
            }

            // Nájdeme štartovaciu pozíciu hráča (H)
            int playerX = -1, playerY = -1;
            for (int i = 0; i < bludisko.GetLength(0); i++)
            {
                for (int j = 0; j < bludisko.GetLength(1); j++)
                {
                    if (bludisko[i, j] == 'H')
                    {
                        playerX = i;
                        playerY = j;
                        break;
                    }
                }
                if (playerX != -1) break;
            }

            // Ak hráč (H) neexistuje v bludisku
            if (playerX == -1 || playerY == -1)
            {
                Console.WriteLine("Hráč (H) nebol nájdený v bludisku!");
                return;
            }

            // Prehladanie riadkov a stlpcov
            for (int i = 0; i < bludisko.GetLength(0); i++)
            {
                for (int j = 0; j < bludisko.GetLength(1); j++)
                {
                    if (bludisko[i, j] == priradenie)
                    {
                        bludisko[i, j] = 'C';
                    }
                    else if (bludisko[i, j] != priradenie && bludisko[i, j] != ' ' && bludisko[i, j] != 'H')
                    {
                        bludisko[i, j] = 'x';
                    }
                }
            }

            // Herný cyklus
            while (true)
            {
                Console.Clear(); // Vyčistí konzolu

                // Vykreslenie bludiska
                for (int i = 0; i < bludisko.GetLength(0); i++)
                {
                    for (int j = 0; j < bludisko.GetLength(1); j++)
                    {
                        Console.Write(bludisko[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nPoužite W (hore), A (vľavo), S (dole), D (vpravo) na pohyb");
                char pohyb = char.ToUpper(Console.ReadKey().KeyChar);

                if (pohyb == 'Q') break;

                int novyX = playerX, novyY = playerY;

                // Určenie smeru pohybu
                if (pohyb == 'W') novyX--; // Hore
                else if (pohyb == 'A') novyY--; // Vľavo
                else if (pohyb == 'S') novyX++; // Dole
                else if (pohyb == 'D') novyY++; // Vpravo


                // Kontrola pohybu
                if (novyX < 0 || novyX >= bludisko.GetLength(0) || novyY < 0 || novyY >= bludisko.GetLength(1))
                {
                    // Hráč sa snaží ísť mimo hranice
                    // Console.WriteLine("\nNemôžete sa pohybovať mimo hranice bludiska!");
                    continue;
                }

                if (bludisko[novyX, novyY] == 'x')
                {
                    // Hráč sa snaží ísť na stenu
                    // Console.WriteLine("\nNemôžete sa pohybovať na pozíciu označenú 'x'!");
                    continue;
                }

                if (bludisko[novyX, novyY] == 'C')
                {
                    Console.Clear();
                    Console.WriteLine("Vyhral si!");
                    break;
                }

                // Aktualizácia pozície hráča
                bludisko[playerX, playerY] = ' '; // Vyprázdni predchádzajúcu pozíciu hráča
                playerX = novyX;
                playerY = novyY;
                bludisko[playerX, playerY] = 'H'; // Označí novú pozíciu hráčada
            }
            Console.ReadLine();

        }
    }
}
