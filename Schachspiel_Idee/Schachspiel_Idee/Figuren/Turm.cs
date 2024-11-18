using System.Collections.Generic;

namespace Schachspiel
{
    public class Turm : Spielfigur
    {
        public Turm(char Typ, bool weiss, int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            Bezeichnung = Typ;
            IstWeiss = weiss;
            AlleZuege = new List<Zug>();
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            int zugX;
            int zugY;

            // Nach unten
            if (PositionX != 7)
            {
                for (int i = PositionX + 1; i < 8; i++)
                {
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, PositionY].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, PositionY].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, PositionY].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, PositionY].IstWeiss)
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, PositionY].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, PositionY].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, PositionY].IstWeiss)
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                }
            }

            // Nach oben
            if (PositionX != 0)
            {
                for (int i = PositionX - 1; i > -1; i--)
                {
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, PositionY].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, PositionY].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[i, PositionY].IstWeiss)
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, PositionY].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, PositionY].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, PositionY].IstWeiss)
                        {
                            zugX = i;
                            zugY = PositionY;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                }
            }

            // Nach rechts
            if (PositionY != 7)
            {
                for (int i = PositionY + 1; i < 8; i++)
                {
                    if (i == 7)
                    {
                    }
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[PositionX, i].Bezeichnung == ' ')
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[PositionX, i].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[PositionX, i].IstWeiss)
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[PositionX, i].Bezeichnung == ' ')
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[PositionX, i].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[PositionX, i].IstWeiss)
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                }
            }

            // Nach links
            if (PositionY != 0)
            {
                for (int i = PositionY - 1; i > -1; i--)
                {
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[PositionX, i].Bezeichnung == ' ')
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[PositionX, i].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[PositionX, i].IstWeiss)
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[PositionX, i].Bezeichnung == ' ')
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[PositionX, i].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[PositionX, i].IstWeiss)
                        {
                            zugX = PositionX;
                            zugY = i;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                }
            }
        }
    }
}