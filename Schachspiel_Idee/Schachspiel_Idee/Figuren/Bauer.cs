using System;
using System.Collections.Generic;


namespace Schachspiel
{
    public class Bauer : Spielfigur
    {
        private static char Umwandlung;
        private static bool ungueltig { get; set; }

        public Bauer(char typ, bool weiss, int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            Bezeichnung = typ;
            IstWeiss = weiss;
            AlleZuege = new List<Zug>();
        }

        public static void BauernUmwandlung(int BauerX, int BauerY)
        {
            Console.WriteLine("Bitte Bezeichnung der Figur zum Umwandeln eingeben:");
            Umwandlung = AbfrageCharUngueltig(Umwandlung);
            while (ungueltig)
            {
                Console.WriteLine("Die Eingabe war ungültig, bitte erneut versuchen:");
                Umwandlung = AbfrageCharUngueltig(Umwandlung);
            }
            if (!ungueltig)
            {
                _tauscheFiguren(BauerX, BauerY);
            }
        }

        private static char AbfrageCharUngueltig(char Buchstabe)
        {
            string boolstring = (Console.ReadLine());
            bool isChar = char.TryParse(boolstring, out char testchar);

            if (boolstring == "" || !isChar)
            {
                ungueltig = true;
                return Buchstabe;
            }
            else if (boolstring == "L" || boolstring == "T" || boolstring == "S" || boolstring == "D" ||
                     boolstring == "l" || boolstring == "t" || boolstring == "s" || boolstring == "d")
            {
                Buchstabe = char.Parse(boolstring);
                ungueltig = false;
                return Buchstabe;
            }
            else
            {
                ungueltig = true;
                return Buchstabe;
            }
        }

        private static void _tauscheFiguren(int BauerX, int BauerY)
        {
            if (Umwandlung == 'L' || Umwandlung == 'l')
            {
                if (BauerX == 7)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Laeufer('L', false, BauerX, BauerY);
                }
                else if (BauerX == 0)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Laeufer('L', true, BauerX, BauerY);
                }
            }
            else if (Umwandlung == 'T' || Umwandlung == 't')
            {
                if (BauerX == 7)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Turm('T', false, BauerX, BauerY);
                }
                else if (BauerX == 0)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Turm('T', true, BauerX, BauerY);
                }
            }
            else if (Umwandlung == 'S' || Umwandlung == 's')
            {
                if (BauerX == 7)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Springer('S', false, BauerX, BauerY);
                }
                else if (BauerX == 0)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Springer('S', true, BauerX, BauerY);
                }
            }
            else if (Umwandlung == 'D' || Umwandlung == 'd')
            {
                if (BauerX == 7)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Dame('D', false, BauerX, BauerY);
                }
                else if (BauerX == 0)
                {
                    Spielfeld.Schachbrett[BauerX, BauerY] = new Dame('D', true, BauerX, BauerY);
                }
            }
            else
            {

            }
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            //Bauer weiß
            if (IstWeiss)
            {
                int zugX;
                int zugY;
                if (PositionX == 6 && schachbrett[PositionX - 2, PositionY].Bezeichnung == ' ')
                {
                    zugX = PositionX - 2;
                    zugY = PositionY;
                    AlleZuege.Add(new Zug(zugX, zugY));
                }
                if (PositionY != 7)
                {
                    if (!schachbrett[PositionX - 1, PositionY + 1].IstWeiss && schachbrett[PositionX - 1, PositionY + 1].Bezeichnung != ' ')
                    {
                        zugX = PositionX - 1;
                        zugY = PositionY + 1;
                        AlleZuege.Add(new Zug(zugX, zugY));
                    }
                }
                if (PositionY != 0)
                {
                    if (!schachbrett[PositionX - 1, PositionY - 1].IstWeiss && schachbrett[PositionX - 1, PositionY - 1].Bezeichnung != ' ')
                    {
                        zugX = PositionX - 1;
                        zugY = PositionY - 1;
                        AlleZuege.Add(new Zug(zugX, zugY));
                    }
                }
                if (schachbrett[PositionX - 1, PositionY].Bezeichnung == ' ')
                {
                    zugX = PositionX - 1;
                    zugY = PositionY;
                    AlleZuege.Add(new Zug(zugX, zugY));
                }
            }

            //Bauer schwarz
            else if (!IstWeiss)
            {
                int zugX;
                int zugY;
                if (PositionX == 1 && schachbrett[PositionX + 2, PositionY].Bezeichnung == ' ')
                {
                    zugX = PositionX + 2;
                    zugY = PositionY;
                    AlleZuege.Add(new Zug(zugX, zugY));
                }
                if (PositionY != 7)
                {
                    if (schachbrett[PositionX + 1, PositionY + 1].IstWeiss && schachbrett[PositionX + 1, PositionY + 1].Bezeichnung != ' ')
                    {
                        zugX = PositionX + 1;
                        zugY = PositionY + 1;
                        AlleZuege.Add(new Zug(zugX, zugY));
                    }
                }
                if (PositionY != 0)
                {
                    if (schachbrett[PositionX + 1, PositionY - 1].IstWeiss && schachbrett[PositionX + 1, PositionY - 1].Bezeichnung != ' ')
                    {
                        zugX = PositionX + 1;
                        zugY = PositionY - 1;
                        AlleZuege.Add(new Zug(zugX, zugY));
                    }
                }
                if (schachbrett[PositionX + 1, PositionY].Bezeichnung == ' ')
                {
                    zugX = PositionX + 1;
                    zugY = PositionY;
                    AlleZuege.Add(new Zug(zugX, zugY));
                }
            }
        }
    }
}
