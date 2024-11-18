namespace SchachspielUI
{
    class Rochade
    {
        public static bool hatRochiert;
        public static bool weißeRochadeGueltig = true;
        public static bool schwarzeRochadeGueltig = true;

        public static bool w_links;
        public static bool w_rechts;
        public static bool b_links;
        public static bool b_rechts;

        public static void Rochieren()
        {
            w_links = false;
            w_rechts = false;
            b_links = false;
            b_rechts = false;
            hatRochiert = false;
            if (SpielfeldUI.spielerfarbe == "weiße")
            {
                if (weißeRochadeGueltig && SpielfeldUI.schachbrett[7, 0].Bezeichnung == '♖'
                    && SpielfeldUI.schachbrett[7, 4].Bezeichnung == '♔' && SpielfeldUI.schachbrett[7, 0].IstWeiss && SpielfeldUI.schachbrett[7, 4].IstWeiss
                    && SpielfeldUI.schachbrett[7, 1].Bezeichnung == ' ' && SpielfeldUI.schachbrett[7, 2].Bezeichnung == ' ' && SpielfeldUI.schachbrett[7, 3].Bezeichnung == ' ')
                {
                    w_links = true;
                }
                if (weißeRochadeGueltig && SpielfeldUI.schachbrett[7, 7].Bezeichnung == '♖'
                    && SpielfeldUI.schachbrett[7, 4].Bezeichnung == '♔' && SpielfeldUI.schachbrett[7, 7].IstWeiss && SpielfeldUI.schachbrett[7, 7].IstWeiss
                    && SpielfeldUI.schachbrett[7, 5].Bezeichnung == ' ' && SpielfeldUI.schachbrett[7, 6].Bezeichnung == ' ')
                {
                    w_rechts = true;
                }
            }
            else if (SpielfeldUI.spielerfarbe == "schwarze")
            {
                if (schwarzeRochadeGueltig && SpielfeldUI.schachbrett[0, 0].Bezeichnung == '♜'
                    && SpielfeldUI.schachbrett[0, 4].Bezeichnung == '♚' && !SpielfeldUI.schachbrett[0, 0].IstWeiss && !SpielfeldUI.schachbrett[0, 4].IstWeiss
                    && SpielfeldUI.schachbrett[0, 1].Bezeichnung == ' ' && SpielfeldUI.schachbrett[0, 2].Bezeichnung == ' ' && SpielfeldUI.schachbrett[0, 3].Bezeichnung == ' ')
                {
                    b_links = true;
                }
                else if (schwarzeRochadeGueltig && SpielfeldUI.schachbrett[0, 7].Bezeichnung == '♜'
                    && SpielfeldUI.schachbrett[0, 4].Bezeichnung == '♚' && !SpielfeldUI.schachbrett[0, 7].IstWeiss && !SpielfeldUI.schachbrett[0, 7].IstWeiss
                    && SpielfeldUI.schachbrett[0, 5].Bezeichnung == ' ' && SpielfeldUI.schachbrett[0, 6].Bezeichnung == ' ')
                {
                    b_rechts = true;
                }
            }
        }

        public static void _Rochieren(bool weiß, bool rechts)
        {
            if (weiß)
            {
                if (!rechts)
                {
                    SpielfeldUI.schachbrett[7, 4] = new LeeresFeld(7, 4);
                    SpielfeldUI.schachbrett[7, 0] = new LeeresFeld(7, 0);
                    SpielfeldUI.schachbrett[7, 1] = new LeeresFeld(7, 1);
                    SpielfeldUI.schachbrett[7, 2] = new Koenig('♔', true, 7, 2);
                    SpielfeldUI.schachbrett[7, 3] = new Turm('♖', true, 7, 3);
                    hatRochiert = true;
                }
                else if (rechts)
                {
                    SpielfeldUI.schachbrett[7, 4] = new LeeresFeld(7, 4);
                    SpielfeldUI.schachbrett[7, 7] = new LeeresFeld(7, 7);
                    SpielfeldUI.schachbrett[7, 6] = new Koenig('♔', true, 7, 6);
                    SpielfeldUI.schachbrett[7, 5] = new Turm('♖', true, 7, 5);
                    hatRochiert = true;
                }
            }
            else if (!weiß)
            {
                if (!rechts)
                {
                    SpielfeldUI.schachbrett[0, 4] = new LeeresFeld(0, 4);
                    SpielfeldUI.schachbrett[0, 0] = new LeeresFeld(0, 0);
                    SpielfeldUI.schachbrett[0, 1] = new LeeresFeld(0, 1);
                    SpielfeldUI.schachbrett[0, 2] = new Koenig('♚', false, 0, 2);
                    SpielfeldUI.schachbrett[0, 3] = new Turm('♜', false, 0, 3);
                    hatRochiert = true;
                }
                else if (rechts)
                {
                    SpielfeldUI.schachbrett[0, 4] = new LeeresFeld(0, 4);
                    SpielfeldUI.schachbrett[0, 7] = new LeeresFeld(0, 7);
                    SpielfeldUI.schachbrett[0, 6] = new Koenig('♚', false, 0, 6);
                    SpielfeldUI.schachbrett[0, 5] = new Turm('♜', false, 0, 5);
                    hatRochiert = true;
                }
            }
        }
    }
}

