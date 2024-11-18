namespace SchachspielUI
{
    class LeeresFeld : Spielfigur
    {
        public LeeresFeld(int _posX, int _posY)
        {
            Bezeichnung = ' ';
            PositionX = _posX;
            PositionY = _posY;
        }

        public override void BerechneZuege(Spielfigur[,] schachbrett)
        {
            //Hier könnte ihre Werbung stehen.
        }
    }
}
