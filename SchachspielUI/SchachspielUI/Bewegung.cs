using System;
using System.Linq;
using System.Windows;

namespace SchachspielUI
{
    public class Bewegung
    {
        public static int posX;
        public static int posY;
        public static int zielX;
        public static int zielY;

        public static void BewegeFigur()
        {
            SpielfeldUI.BerechneAlleZuege();
            if (!Rochade.hatRochiert)
            {
                ZieheFigur();
            }
            if (Rochade.hatRochiert)
            {
                Spielerwechsel();
            }
            SchachMatt.Schach();
            if (SchachMatt.schachschwarz || SchachMatt.schachweiß)
            {
                SchachMatt.Schachmatt();
                if (!SchachMatt.mattSchwarz && !SchachMatt.mattWeiß)
                {
                    SchachMatt.Schach();
                }
            }
        }

        public static bool ungueltigWegenSchach = false;

        private static void ZieheFigur()
        {
            char urspruenglicheFigur;
            ungueltigWegenSchach = false;
            int gueltigeZuege = SpielfeldUI.schachbrett[posX, posY].AlleZuege.Count();
            for (int i = 0; i < gueltigeZuege; i++)
            {
                if (zielX == SpielfeldUI.schachbrett[posX, posY].AlleZuege[i].ZugX &&
                    zielY == SpielfeldUI.schachbrett[posX, posY].AlleZuege[i].ZugY)
                {
                    SpielfeldUI.gueltigerZug = true;
                    urspruenglicheFigur = SpielfeldUI.schachbrett[zielX, zielY].Bezeichnung;
                    SpielfeldUI.schachbrett[zielX, zielY] = SpielfeldUI.schachbrett[posX, posY];
                    SpielfeldUI.schachbrett[zielX, zielY].PositionX = zielX;
                    SpielfeldUI.schachbrett[zielX, zielY].PositionY = zielY;
                    SpielfeldUI.schachbrett[posX, posY] = new LeeresFeld(posX, posY);
                    if (SpielfeldUI.schachbrett[7, 4].Bezeichnung != '♔')
                    {
                        Rochade.weißeRochadeGueltig = false;
                    }
                    else if (SpielfeldUI.schachbrett[0, 4].Bezeichnung != '♚')
                    {
                        Rochade.schwarzeRochadeGueltig = false;
                    }
                    
                    if ((zielX == 0 && SpielfeldUI.schachbrett[zielX, zielY].Bezeichnung == '⦾') || (zielX == 7 && SpielfeldUI.schachbrett[zielX, zielY].Bezeichnung == '⦿'))
                    {
                        Bauer.BauernUmwandlung();
                    }

                    if (SpielfeldUI.spielerfarbe == "schwarze")
                    {
                        SpielfeldUI.BerechneAlleZuege();
                        SchachMatt.Schach();
                        if (SchachMatt.schachschwarz)
                        {
                            ungueltigWegenSchach = true;
                            SpielfeldUI.schachbrett[posX, posY] = SpielfeldUI.schachbrett[zielX, zielY];
                            SpielfeldUI.schachbrett[posX, posY].PositionX = posX;
                            SpielfeldUI.schachbrett[posX, posY].PositionY = posY;
                            SchachMatt.UrsprueglicheFigur(urspruenglicheFigur, zielX, zielY, true);
                            SpielfeldUI.BerechneAlleZuege();
                            break;
                        }
                    }
                    else if (SpielfeldUI.spielerfarbe == "weiße")
                    {
                        SpielfeldUI.BerechneAlleZuege();
                        SchachMatt.Schach();
                        if (SchachMatt.schachweiß)
                        {
                            ungueltigWegenSchach = true;
                            SpielfeldUI.schachbrett[posX, posY] = SpielfeldUI.schachbrett[zielX, zielY];
                            SpielfeldUI.schachbrett[posX, posY].PositionX = posX;
                            SpielfeldUI.schachbrett[posX, posY].PositionY = posY;
                            SchachMatt.UrsprueglicheFigur(urspruenglicheFigur, zielX, zielY, false);
                            SpielfeldUI.BerechneAlleZuege();
                            break;
                        }
                    }

                    SpielfeldUI.BerechneAlleZuege();
                    Spielerwechsel();
                    break;
                }
            }
        }

        private static string Spielerwechsel()
        {
            if (SpielfeldUI.spielerfarbe == "weiße")
            {
                SpielfeldUI.spielerfarbe = "schwarze";
            }
            else if (SpielfeldUI.spielerfarbe == "schwarze")
            {
                SpielfeldUI.spielerfarbe = "weiße";
            }
            return SpielfeldUI.spielerfarbe;
        }
    }
}
