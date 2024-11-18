using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class Springer : Spielfigur
    {
        public Springer(char Typ, bool weiss, int positionX, int positionY)
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

            // -2,-1 oben links
            if (PositionX >= 2 && PositionY >= 1 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 2, PositionY - 1].IstWeiss || schachbrett[PositionX - 2, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 2;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX >= 2 && PositionY >= 1 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 2, PositionY - 1].IstWeiss || schachbrett[PositionX - 2, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 2;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // -2,+1 oben rechts
            if (PositionX >= 2 && PositionY <= 6 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 2, PositionY + 1].IstWeiss || schachbrett[PositionX - 2, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 2;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX >= 2 && PositionY <= 6 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 2, PositionY + 1].IstWeiss || schachbrett[PositionX - 2, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 2;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // -1,-2 links oben
            if (PositionX >= 1 && PositionY >= 2 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 1, PositionY - 2].IstWeiss || schachbrett[PositionX - 1, PositionY - 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY - 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX >= 1 && PositionY >= 2 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 1, PositionY - 2].IstWeiss || schachbrett[PositionX - 1, PositionY - 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY - 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // -1,+2 rechts oben
            if (PositionX >= 1 && PositionY <= 5 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX - 1, PositionY + 2].IstWeiss || schachbrett[PositionX - 1, PositionY + 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY + 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX >= 1 && PositionY <= 5 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX - 1, PositionY + 2].IstWeiss || schachbrett[PositionX - 1, PositionY + 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX - 1;
                ZugY = PositionY + 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // +1,-2 links unten
            if (PositionX <= 6 && PositionY >= 2 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 1, PositionY - 2].IstWeiss || schachbrett[PositionX + 1, PositionY - 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY - 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX <= 6 && PositionY >= 2 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 1, PositionY - 2].IstWeiss || schachbrett[PositionX + 1, PositionY - 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY - 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // +1,+2 rechts unten
            if (PositionX <= 6 && PositionY <= 5 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 1, PositionY + 2].IstWeiss || schachbrett[PositionX + 1, PositionY + 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY + 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX <= 6 && PositionY <= 5 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 1, PositionY + 2].IstWeiss || schachbrett[PositionX + 1, PositionY + 2].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 1;
                ZugY = PositionY + 2;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // +2-1 unten links
            if (PositionX <= 5 && PositionY >= 1 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 2, PositionY - 1].IstWeiss || schachbrett[PositionX + 2, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 2;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX <= 5 && PositionY >= 1 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 2, PositionY - 1].IstWeiss || schachbrett[PositionX + 2, PositionY - 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 2;
                ZugY = PositionY - 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            // +2,+1 unten rechts
            if (PositionX <= 5 && PositionY <= 6 && (schachbrett[PositionX, PositionY].IstWeiss && (!schachbrett[PositionX + 2, PositionY + 1].IstWeiss || schachbrett[PositionX + 2, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 2;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
            else if (PositionX <= 5 && PositionY <= 6 && (!schachbrett[PositionX, PositionY].IstWeiss && (schachbrett[PositionX + 2, PositionY + 1].IstWeiss || schachbrett[PositionX + 2, PositionY + 1].Bezeichnung == ' ')))
            {
                ZugX = PositionX + 2;
                ZugY = PositionY + 1;
                AlleZuege.Add(new Zug(ZugX, ZugY));
            }
        }
    }
}
