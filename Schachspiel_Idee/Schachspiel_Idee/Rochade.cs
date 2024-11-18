using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class Rochade
    {
        public static bool hatRochiert;
        private static char JaNein;
        public static bool WeißeRochadeGueltig = true;
        public static bool SchwarzeRochadeGueltig = true;
        private static bool ungueltig { get; set; }
        private static bool WillRochieren;

        public static void Rochieren()
        {
            hatRochiert = false;
            if (Strings.Spielerfarbe == "weiße")
            {
                if (WeißeRochadeGueltig && Spielfeld.Schachbrett[7, 0].Bezeichnung == 'T'
                    && Spielfeld.Schachbrett[7, 4].Bezeichnung == 'K' && Spielfeld.Schachbrett[7, 0].IstWeiss && Spielfeld.Schachbrett[7, 4].IstWeiss
                    && Spielfeld.Schachbrett[7, 1].Bezeichnung == ' ' && Spielfeld.Schachbrett[7, 2].Bezeichnung == ' ' && Spielfeld.Schachbrett[7, 3].Bezeichnung == ' ')
                {
                    Console.WriteLine("Der weiße Spieler hat die Möglichkeit zu einer Rochade mit dem linken Turm.\nRochade ausführen? (y/n)");
                    JaNein = _Eingabe(JaNein);
                    while (ungueltig)
                    {
                        Console.WriteLine("Die Eingabe war ungültig, bitte erneut versuchen:");
                        JaNein = _Eingabe(JaNein);
                    }
                    if (!ungueltig)
                    {
                        _Rochieren(true, false);
                    }
                }
                else if (WeißeRochadeGueltig && Spielfeld.Schachbrett[7, 7].Bezeichnung == 'T'
                    && Spielfeld.Schachbrett[7, 4].Bezeichnung == 'K' && Spielfeld.Schachbrett[7, 7].IstWeiss && Spielfeld.Schachbrett[7, 7].IstWeiss
                    && Spielfeld.Schachbrett[7, 5].Bezeichnung == ' ' && Spielfeld.Schachbrett[7, 6].Bezeichnung == ' ')
                {
                    Console.WriteLine("Der weiße Spieler hat die Möglichkeit zu einer Rochade mit dem rechten Turm.\nRochade ausführen? (y/n)");
                    JaNein = _Eingabe(JaNein);
                    while (ungueltig)
                    {
                        Console.WriteLine("Die Eingabe war ungültig, bitte erneut versuchen:");
                        JaNein = _Eingabe(JaNein);
                    }
                    if (!ungueltig)
                    {
                        _Rochieren(true, true);
                    }
                }
            }
            else if (Strings.Spielerfarbe == "schwarze")
            {
                if (SchwarzeRochadeGueltig && Spielfeld.Schachbrett[0, 0].Bezeichnung == 'T'
                    && Spielfeld.Schachbrett[0, 4].Bezeichnung == 'K' && !Spielfeld.Schachbrett[0, 0].IstWeiss && !Spielfeld.Schachbrett[0, 4].IstWeiss
                    && Spielfeld.Schachbrett[0, 1].Bezeichnung == ' ' && Spielfeld.Schachbrett[0, 2].Bezeichnung == ' ' && Spielfeld.Schachbrett[0, 3].Bezeichnung == ' ')
                {
                    Console.WriteLine("Der schwarze Spieler hat die Möglichkeit zu einer Rochade mit dem linken Turm.\nRochade ausführen? (y/n)");
                    JaNein = _Eingabe(JaNein);
                    while (ungueltig)
                    {
                        Console.WriteLine("Die Eingabe war ungültig, bitte erneut versuchen:");
                        JaNein = _Eingabe(JaNein);
                    }
                    if (!ungueltig)
                    {
                        _Rochieren(false, false);
                    }
                }
                else if (SchwarzeRochadeGueltig && Spielfeld.Schachbrett[0, 7].Bezeichnung == 'T'
                    && Spielfeld.Schachbrett[0, 4].Bezeichnung == 'K' && !Spielfeld.Schachbrett[0, 7].IstWeiss && !Spielfeld.Schachbrett[0, 7].IstWeiss
                    && Spielfeld.Schachbrett[0, 5].Bezeichnung == ' ' && Spielfeld.Schachbrett[0, 6].Bezeichnung == ' ')
                {
                    Console.WriteLine("Der schwarze Spieler hat die Möglichkeit zu einer Rochade mit dem rechten Turm.\nRochade ausführen? (y/n)");
                    JaNein = _Eingabe(JaNein);
                    while (ungueltig)
                    {
                        Console.WriteLine("Die Eingabe war ungültig, bitte erneut versuchen:");
                        JaNein = _Eingabe(JaNein);
                    }
                    if (!ungueltig)
                    {
                        _Rochieren(false, true);
                    }
                }
            }
        }

        private static void _Rochieren(bool weiß, bool rechts)
        {
            if (WillRochieren)
            {
                if (weiß)
                {
                    if (!rechts)
                    {
                        Spielfeld.Schachbrett[7, 4] = new LeeresFeld();
                        Spielfeld.Schachbrett[7, 0] = new LeeresFeld();
                        Spielfeld.Schachbrett[7, 1] = new LeeresFeld();
                        Spielfeld.Schachbrett[7, 2] = new Koenig('K', true, 7, 2);
                        Spielfeld.Schachbrett[7, 3] = new Turm('T', true, 7, 3);
                        hatRochiert = true;
                    }
                    else if (rechts)
                    {
                        Spielfeld.Schachbrett[7, 4] = new LeeresFeld();
                        Spielfeld.Schachbrett[7, 7] = new LeeresFeld();
                        Spielfeld.Schachbrett[7, 6] = new Koenig('K', true, 7, 6);
                        Spielfeld.Schachbrett[7, 5] = new Turm('T', true, 7, 5);
                        hatRochiert = true;
                    }
                }
                else if (!weiß)
                {
                    if (!rechts)
                    {
                        Spielfeld.Schachbrett[0, 4] = new LeeresFeld();
                        Spielfeld.Schachbrett[0, 0] = new LeeresFeld();
                        Spielfeld.Schachbrett[0, 1] = new LeeresFeld();
                        Spielfeld.Schachbrett[0, 2] = new Koenig('K', false, 0, 2);
                        Spielfeld.Schachbrett[0, 3] = new Turm('T', false, 0, 3);
                        hatRochiert = true;
                    }
                    else if (rechts)
                    {
                        Spielfeld.Schachbrett[0, 4] = new LeeresFeld();
                        Spielfeld.Schachbrett[0, 7] = new LeeresFeld();
                        Spielfeld.Schachbrett[0, 6] = new Koenig('K', false, 0, 6);
                        Spielfeld.Schachbrett[0, 5] = new Turm('T', false, 0, 5);
                        hatRochiert = true;
                    }
                }
            }
            else if (!WillRochieren)
            {
                Console.WriteLine("Es wird keine Rochade durchgeführt.");
            }
        }

        private static char _Eingabe(char Eingabe)
        {
            string boolstring = (Console.ReadLine());
            bool isChar = char.TryParse(boolstring, out char testchar);

            if (boolstring == "" || !isChar)
            {
                ungueltig = true;
                return Eingabe;
            }
            if (boolstring == "y" || boolstring == "Y")
            {
                Eingabe = char.Parse(boolstring);
                ungueltig = false;
                WillRochieren = true;
                return Eingabe;
            }
            else if (boolstring == "n" || boolstring == "N")
            {
                Eingabe = char.Parse(boolstring);
                ungueltig = false;
                WillRochieren = false;
                return Eingabe;
            }
            else
            {
                ungueltig = true;
                return Eingabe;
            }
        }
    }
}
