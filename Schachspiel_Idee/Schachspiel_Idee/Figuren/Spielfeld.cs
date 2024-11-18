using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class Spielfeld
    {
        readonly string buchstaben = "    A   B   C   D   E   F   G   H";
        private Eingabe MainEingabe;
        public static Spielfigur[,] Schachbrett;

        public Spielfeld()
        {
            MainEingabe = new Eingabe();
            SpielfHSym = "+---";
            SpielfVSym = "| ";

            Schachbrett = new Spielfigur[8, 8];
            ErstelleFiguren();
            BerechneAlleZuege();

        }

        public string SpielfHSym { get; set; }
        public string SpielfVSym { get; set; }

        public void SpielfeldErstellen()
        {
            while (!MainEingabe.OoB)
            {
                Console.Clear();
                Console.WriteLine(buchstaben);

                for (int i = 0; i < 8; i++)
                {
                    Console.Write("  ");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(SpielfHSym);
                    }

                    Console.Write("+\n");

                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 0)
                        {
                            Console.Write((8 - i) + " ");
                        }
                        Console.Write(SpielfVSym + Schachbrett[i, j].Bezeichnung + " ");
                    }
                    Console.Write("| " + (8 - i) + "\n");
                }
                Console.Write("  ");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write(SpielfHSym);
                }
                Console.WriteLine("+");
                Console.WriteLine(buchstaben);
                Console.Write("\n");

                MainEingabe.BewegeFigur();
            }
        }

        private void ErstelleFiguren()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 6)
                    {
                        Schachbrett[i, j] = new Bauer('B', true, i, j);
                    }
                    else if (i == 1)
                    {
                        Schachbrett[i, j] = new Bauer('B', false, i, j);
                    }
                    else if (i == 0 || i == 8 - 1)
                    {
                        Schachbrett[7, 0] = new Turm('T', true, 7, 0);
                        Schachbrett[7, 1] = new Springer('S', true, 7, 1);
                        Schachbrett[7, 2] = new Laeufer('L', true, 7, 2);
                        Schachbrett[7, 3] = new Dame('D', true, 7, 3);
                        Schachbrett[7, 4] = new Koenig('K', true, 7, 4);
                        Schachbrett[7, 5] = new Laeufer('L', true, 7, 5);
                        Schachbrett[7, 6] = new Springer('S', true, 7, 6);
                        Schachbrett[7, 7] = new Turm('T', true, 7, 7);

                        Schachbrett[0, 0] = new Turm('T', false, 0, 0);
                        Schachbrett[0, 1] = new Springer('S', false, 0, 1);
                        Schachbrett[0, 2] = new Laeufer('L', false, 0, 2);
                        Schachbrett[0, 3] = new Dame('D', false, 0, 3);
                        Schachbrett[0, 4] = new Koenig('K', false, 0, 4);
                        Schachbrett[0, 5] = new Laeufer('L', false, 0, 5);
                        Schachbrett[0, 6] = new Springer('S', false, 0, 6);
                        Schachbrett[0, 7] = new Turm('T', false, 0, 7);
                    }
                    else
                    {
                        Schachbrett[i, j] = new LeeresFeld();
                    }
                }
            }
        }

        public static void BerechneAlleZuege()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Schachbrett[i, j].Bezeichnung != ' ')
                    {
                        Schachbrett[i, j].AlleZuege.Clear();
                    }
                    Schachbrett[i, j].BerechneZuege(Schachbrett);
                }
            }
        }
    }
}
