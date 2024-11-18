using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class Koenig : Spielfigur
    {
        public Koenig(char Typ, bool weiss, int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            Bezeichnung = Typ;
            IstWeiss = weiss;
            AlleZuege = new List<Zug>();
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            int ZugX;
            int ZugY;

            //Oben
            if (PositionX + 1 <= 7 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 1, PositionY].IstWeiss || schachbrett[PositionX + 1, PositionY].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX + 1 <= 7 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 1, PositionY].IstWeiss || schachbrett[PositionX + 1, PositionY].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Unten
            if (PositionX - 1 >= 0 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 1, PositionY].IstWeiss || schachbrett[PositionX - 1, PositionY].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX - 1 >= 0 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 1, PositionY].IstWeiss || schachbrett[PositionX - 1, PositionY].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Rechts
            if (PositionY + 1 <= 7 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX, PositionY + 1].IstWeiss || schachbrett[PositionX, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionY + 1 <= 7 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX, PositionY + 1].IstWeiss || schachbrett[PositionX, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Links
            if (PositionY - 1 >= 0 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX, PositionY - 1].IstWeiss || schachbrett[PositionX, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionY - 1 >= 0 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX, PositionY - 1].IstWeiss || schachbrett[PositionX, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Unten Rechts
            if ((PositionX + 1 <= 7 && PositionY + 1 <= 7) && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 1, PositionY + 1].IstWeiss || schachbrett[PositionX + 1, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if ((PositionX + 1 <= 7 && PositionY + 1 <= 7) && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 1, PositionY + 1].IstWeiss || schachbrett[PositionX + 1, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Unten Links
            if ((PositionX + 1 <= 7 && PositionY - 1 >= 0) && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 1, PositionY - 1].IstWeiss || schachbrett[PositionX + 1, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if ((PositionX + 1 <= 7 && PositionY - 1 >= 0) && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 1, PositionY - 1].IstWeiss || schachbrett[PositionX + 1, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Rechts Oben
            if ((PositionX - 1 >= 0 && PositionY + 1 <= 7) && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 1, PositionY + 1].IstWeiss || schachbrett[PositionX - 1, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if ((PositionX - 1 >= 0 && PositionY + 1 <= 7) && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 1, PositionY + 1].IstWeiss || schachbrett[PositionX - 1, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            //Links Oben
            if ((PositionX - 1 >= 0 && PositionY - 1 >= 0) && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 1, PositionY - 1].IstWeiss || schachbrett[PositionX - 1, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if ((PositionX - 1 >= 0 && PositionY - 1 >= 0) && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 1, PositionY - 1].IstWeiss || schachbrett[PositionX - 1, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }

        }
    }
}
