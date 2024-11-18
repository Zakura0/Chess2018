using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachspielUI
{
    public class Dame : Spielfigur
    {
        public Dame(char Typ, bool weiss, int positionX, int positionY)
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
            int j;

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

            //Oben Links
            if (PositionX != 0 || PositionY != 0)
            {
                j = PositionY - 1;
                for (int i = PositionX - 1; i > -1; i--)
                {
                    if (j == -1)
                    {
                        break;
                    }
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    j--;
                }
            }

            //Oben Rechts
            if (PositionX != 0 || PositionY != 7)
            {
                j = PositionY + 1;
                for (int i = PositionX - 1; i > -1; i--)
                {
                    if (j == 8)
                    {
                        break;
                    }
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    j++;
                }
            }

            //Unten Links
            if (PositionX != 7 || PositionY != 0)
            {
                j = PositionY - 1;
                for (int i = PositionX + 1; i < 8; i++)
                {
                    if (j == -1)
                    {
                        break;
                    }
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    j--;
                }
            }

            //Unten Rechts
            if (PositionX != 7 || PositionY != 7)
            {
                j = PositionY + 1;
                for (int i = PositionX + 1; i < 8; i++)
                {
                    if (j == 8)
                    {
                        break;
                    }
                    if (schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;
                        }
                    }
                    else if (!schachbrett[PositionX, PositionY].IstWeiss)
                    {
                        if (schachbrett[i, j].Bezeichnung == ' ')
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                        }
                        else if (!schachbrett[i, j].IstWeiss)
                        {
                            break;
                        }
                        else if (schachbrett[i, j].IstWeiss)
                        {
                            zugX = i;
                            zugY = j;
                            AlleZuege.Add(new Zug(zugX, zugY));
                            break;

                        }
                    }
                    j++;
                }
            }
        }
    }
}
