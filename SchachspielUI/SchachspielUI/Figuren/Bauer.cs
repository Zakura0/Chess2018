using System;
using System.Collections.Generic;

namespace SchachspielUI
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

        public static void BauernUmwandlung()
        {
            BauernUW bauernUW = new BauernUW();
            bauernUW.ShowDialog();
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            //Bauer weiß
            if (IstWeiss)
            {
                int zugX;
                int zugY;
                if (PositionX == 6 && schachbrett[PositionX - 1, PositionY].Bezeichnung == ' ' && schachbrett[PositionX - 2, PositionY].Bezeichnung == ' ')
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
                if (PositionX == 1 && schachbrett[PositionX + 1, PositionY].Bezeichnung == ' ' &&  schachbrett[PositionX + 2, PositionY].Bezeichnung == ' ')
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

