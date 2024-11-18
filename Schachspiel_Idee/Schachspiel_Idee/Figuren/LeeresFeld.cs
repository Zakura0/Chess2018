using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class LeeresFeld : Spielfigur
    {
        public LeeresFeld()
        {
            Bezeichnung = ' ';
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            //Hier könnte ihre Werbung stehen.
        }
    }
}
