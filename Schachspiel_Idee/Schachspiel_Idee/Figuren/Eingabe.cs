using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    public class Eingabe
    {
        public string BoolString;
        public int IntPlus;
        public char BoolChar;
        public static int PosX;
        public static int PosY;
        public int ZielX;
        public int ZielY;
        public bool OoB { get; set; }

        public void BewegeFigur()
        {
            EingabeNutzer();
            if (!OoB)
            {
                ZieheFigur();
                SchachMatt.Schach();
                if (SchachMatt.schachschwarz || SchachMatt.schachweiß)
                {
                    SchachMatt.Schachmatt();
                    if (!SchachMatt.MattSchwarz && !SchachMatt.MattWeiß)
                    {
                        SchachMatt.Schach();
                    }
                }
            }
        }

        public void ZieheFigur()
        {
            bool ungueltigerZug = true;
            if (Spielfeld.Schachbrett[PosX, PosY].Bezeichnung == ' ')
            {
                Console.WriteLine("Keine Figur zum Ziehen gewählt, bitte Eingabe wiederholen.");
                Console.ReadLine();
            }
            else if (!Spielfeld.Schachbrett[PosX, PosY].IstWeiss && Strings.Spielerfarbe == "weiße")
            {
                Console.WriteLine("Der weiße Spieler kann nur die weißen Figuren bewegen!");
                Console.ReadLine();
            }
            else if (Spielfeld.Schachbrett[PosX, PosY].IstWeiss && Strings.Spielerfarbe == "schwarze")
            {
                Console.WriteLine("Der schwarze Spieler kann nur die schwarzen Figuren bewegen!");
                Console.ReadLine();
            }
            else
            {
                int GueltigeZuege = Spielfeld.Schachbrett[PosX, PosY].AlleZuege.Count();
                for (int i = 0; i < GueltigeZuege; i++)
                {
                    if (ZielX == Spielfeld.Schachbrett[PosX, PosY].AlleZuege[i].ZugX &&
                        ZielY == Spielfeld.Schachbrett[PosX, PosY].AlleZuege[i].ZugY)
                    {
                        ungueltigerZug = false;
                        Spielfeld.Schachbrett[ZielX, ZielY] = Spielfeld.Schachbrett[PosX, PosY];
                        Spielfeld.Schachbrett[ZielX, ZielY].PositionX = ZielX;
                        Spielfeld.Schachbrett[ZielX, ZielY].PositionY = ZielY;
                        Spielfeld.Schachbrett[PosX, PosY] = new LeeresFeld();
                        Spielerwechsel();
                        Spielfeld.BerechneAlleZuege();
                        break;
                    }
                }
                if (ungueltigerZug)
                {
                    Console.WriteLine("Der Zug ist ungültig für die gewählte Figur (Typ: {0})", Spielfeld.Schachbrett[PosX, PosY].Bezeichnung);
                    Console.ReadLine();
                }

            }
        }

        public void EingabeNutzer()
        {
            if (SchachMatt.MattSchwarz)
            {
                Console.WriteLine("Schachmatt! Der weiße Spieler hat die Partie gewonnen!");
                Console.WriteLine("Beenden mit Enter.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (SchachMatt.MattWeiß)
            {
                Console.WriteLine("Schachmatt! Der schwarze Spieler hat die Partie gewonnen!");
                Console.WriteLine("Beenden mit Enter.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (SchachMatt.schachweiß)
            {
                Console.WriteLine("Der weiße König steht im Schach!");
            }
            else if (SchachMatt.schachschwarz)
            {
                Console.WriteLine("Der schwarze König steht im Schach!");
            }

            Console.WriteLine("Der {0} Spieler ist am Zug.", Strings.Spielerfarbe);
            Console.WriteLine("Bitte den Buchstaben der Spalte der zu bewegenden Figur eintragen:");
            PosY = EingabeBuchstabe(PosY);
            while (OoB)
            {
                Console.WriteLine(Strings.eingabeUngueltig);
                PosX = EingabeBuchstabe(PosX);
            }

            Console.WriteLine("Bitte die Koordinate der Reihe der zu bewegenden Figur eintragen:");
            PosX = EingabeZahl(PosX);
            while (OoB)
            {
                Console.WriteLine(Strings.eingabeUngueltig);
                PosX = EingabeZahl(PosX);
            }

            Console.WriteLine("Bitte den Buchstaben der Spalte des Zielfeldes eintragen:");
            ZielY = EingabeBuchstabe(ZielY);
            while (OoB)
            {
                Console.WriteLine(Strings.eingabeUngueltig);
                ZielY = EingabeBuchstabe(ZielY);
            }

            Console.WriteLine("Bitte die Koordinate der Reihe des Zielfeldes eintragen:");
            ZielX = EingabeZahl(ZielX);
            while (OoB)
            {
                Console.WriteLine(Strings.eingabeUngueltig);
                ZielX = EingabeZahl(ZielX);
            }
        }

        private bool EingabeGueltig(int input, bool gueltig)
        {
            bool ungueltig = false;

            if (!gueltig)
                ungueltig = true;
            else if (input < 0)
                ungueltig = true;
            else if (input > 8 - 1)
                ungueltig = true;

            return ungueltig;
        }

        private void AbfrageOutOfBounds(int output)
        {
            int BoolInt = output;
            BoolString = Convert.ToString(BoolInt);
            OoB = EingabeGueltig(output, int.TryParse(BoolString, out output));
        }

        private int EingabeZahl(int Feld)
        {
            string boolstring = (Console.ReadLine());
            bool isInt = int.TryParse(boolstring, out int testint);
            if (boolstring == "" || !isInt)
            {
                OoB = true;
                return Feld;
            }
            else
            {
                IntPlus = int.Parse(boolstring);
                Feld = ZahlenUmdrehen(IntPlus);
                Feld = Convert.ToInt32(Feld);
                AbfrageOutOfBounds(Feld);
                return Feld;
            }
        }

        private int EingabeBuchstabe(int Feld)
        {
            string boolstring = (Console.ReadLine());
            bool isChar = char.TryParse(boolstring, out char testchar);
            if (boolstring == "" || !isChar)
            {
                OoB = true;
                return Feld;
            }
            else
            {
                BoolChar = char.Parse(boolstring);
                Feld = IstChar(BoolChar);
                Feld = Convert.ToInt32(Feld);
                AbfrageOutOfBounds(Feld);
                return Feld;
            }
        }

        private int IstChar(char BoolChar)
        {
            if (BoolChar == 'A' || BoolChar == 'a')
            {
                return 0;
            }
            else if (BoolChar == 'B' || BoolChar == 'b')
            {
                return 1;
            }
            else if (BoolChar == 'C' || BoolChar == 'c')
            {
                return 2;
            }
            else if (BoolChar == 'D' || BoolChar == 'd')
            {
                return 3;
            }
            else if (BoolChar == 'E' || BoolChar == 'e')
            {
                return 4;
            }
            else if (BoolChar == 'F' || BoolChar == 'f')
            {
                return 5;
            }
            else if (BoolChar == 'G' || BoolChar == 'g')
            {
                return 6;
            }
            else if (BoolChar == 'H' || BoolChar == 'h')
            {
                return 7;
            }
            else
            {
                return Convert.ToInt32(BoolChar);
            }
        }

        private int ZahlenUmdrehen(int Eingabe)
        {
            if (Eingabe == 1)
            {
                return 7;
            }
            else if (Eingabe == 2)
            {
                return 6;
            }
            else if (Eingabe == 3)
            {
                return 5;
            }
            else if (Eingabe == 4)
            {
                return 4;
            }
            else if (Eingabe == 5)
            {
                return 3;
            }
            else if (Eingabe == 6)
            {
                return 2;
            }
            else if (Eingabe == 7)
            {
                return 1;
            }
            else if (Eingabe == 8)
            {
                return 0;
            }
            else
            {
                return 99;
            }
        }

        private string Spielerwechsel()
        {
            if (Strings.Spielerfarbe == "weiße")
            {
                Strings.Spielerfarbe = "schwarze";
            }
            else if (Strings.Spielerfarbe == "schwarze")
            {
                Strings.Spielerfarbe = "weiße";
            }
            return Strings.Spielerfarbe;
        }
    }
}
