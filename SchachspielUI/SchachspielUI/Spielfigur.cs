using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SchachspielUI
{
    public abstract class Spielfigur : Button
    {

        public Spielfigur()
        {
            FontSize = 65;
        }

        private List<Zug> _alleZuege;
        private int _positionX;
        private int _positionY;
        private bool _istWeiss;
        private char _bezeichnung;

        public List<Zug> AlleZuege
        {
            get => _alleZuege;
            set => _alleZuege = value;
        }

        public int PositionX
        {
            get => _positionX;
            set => _positionX = value;
        }

        public int PositionY
        {
            get => _positionY;
            set => _positionY = value;
        }

        public bool IstWeiss
        {
            get => _istWeiss;
            set => _istWeiss = value;
        }

        public char Bezeichnung
        {
            get => _bezeichnung;
            set => _bezeichnung = value;
            
        }

        public abstract void BerechneZuege(Spielfigur[,] schachbrett);
    }
}
