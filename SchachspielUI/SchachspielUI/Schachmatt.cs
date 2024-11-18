using System.Linq;

namespace SchachspielUI
{
    class SchachMatt
    {
        public static bool schachweiß;
        public static bool schachschwarz;

        public static void Schach()
        {
            int schachX;
            int schachY;
            int anzahlZuege;

            schachweiß = false;
            schachschwarz = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (SpielfeldUI.schachbrett[i, j].IstWeiss && (SpielfeldUI.schachbrett[i, j].Bezeichnung == '♔' || SpielfeldUI.schachbrett[i, j].Bezeichnung == '♚'))
                    {
                        schachX = i; schachY = j;

                        for (int r = 0; r < 8; r++)
                        {

                            if (schachweiß)
                            {
                                break;
                            }

                            for (int t = 0; t < 8; t++)
                            {

                                if (schachweiß)
                                {
                                    break;
                                }

                                if (SpielfeldUI.schachbrett[r, t].Bezeichnung != ' ' && !SpielfeldUI.schachbrett[r, t].IstWeiss)
                                {
                                    anzahlZuege = SpielfeldUI.schachbrett[r, t].AlleZuege.Count();
                                    for (int h = 0; h < anzahlZuege; h++)
                                    {
                                        if (SpielfeldUI.schachbrett[r, t].AlleZuege[h].ZugX == schachX &&
                                            SpielfeldUI.schachbrett[r, t].AlleZuege[h].ZugY == schachY)
                                        {
                                            schachweiß = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!SpielfeldUI.schachbrett[i, j].IstWeiss && (SpielfeldUI.schachbrett[i, j].Bezeichnung == '♔' || SpielfeldUI.schachbrett[i, j].Bezeichnung == '♚'))
                    {
                        schachX = i; schachY = j;

                        for (int r = 0; r < 8; r++)
                        {
                            if (schachschwarz)
                            {
                                break;
                            }

                            for (int t = 0; t < 8; t++)
                            {
                                if (schachschwarz)
                                {
                                    break;
                                }

                                if (SpielfeldUI.schachbrett[r, t].Bezeichnung != ' ' && SpielfeldUI.schachbrett[r, t].IstWeiss)
                                {
                                    anzahlZuege = SpielfeldUI.schachbrett[r, t].AlleZuege.Count();
                                    for (int h = 0; h < anzahlZuege; h++)
                                    {
                                        if (SpielfeldUI.schachbrett[r, t].AlleZuege[h].ZugX == schachX &&
                                            SpielfeldUI.schachbrett[r, t].AlleZuege[h].ZugY == schachY)
                                        {
                                            schachschwarz = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static bool mattSchwarz;
        public static bool mattWeiß;

        public static void Schachmatt()
        {
            bool keinMatt = false;
            mattSchwarz = false;
            mattWeiß = false;
            int testX;
            int testY;
            int anzahlZuege;
            char uFigur;

            if (schachweiß)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (keinMatt)
                    {
                        break;
                    }
                    for (int j = 0; j < 8; j++)
                    {

                        if (keinMatt)
                        {
                            break;
                        }

                        if (SpielfeldUI.schachbrett[i, j].IstWeiss && SpielfeldUI.schachbrett[i, j].Bezeichnung != ' ')
                        {
                            anzahlZuege = SpielfeldUI.schachbrett[i, j].AlleZuege.Count();
                            for (int h = 0; h < anzahlZuege; h++)
                            {
                                testX = SpielfeldUI.schachbrett[i, j].AlleZuege[h].ZugX;
                                testY = SpielfeldUI.schachbrett[i, j].AlleZuege[h].ZugY;
                                uFigur = SpielfeldUI.schachbrett[testX, testY].Bezeichnung;

                                TestSchachmatt(uFigur, testX, testY, i, j, false);

                                if (!schachweiß)
                                {
                                    keinMatt = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (schachweiß)
                {
                    mattWeiß = true;
                }
            }

            else if (schachschwarz)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (keinMatt)
                    {
                        break;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        if (keinMatt)
                        {
                            break;
                        }

                        if (!SpielfeldUI.schachbrett[i, j].IstWeiss && SpielfeldUI.schachbrett[i, j].Bezeichnung != ' ')
                        {
                            anzahlZuege = SpielfeldUI.schachbrett[i, j].AlleZuege.Count();
                            for (int h = 0; h < anzahlZuege; h++)
                            {
                                testX = SpielfeldUI.schachbrett[i, j].AlleZuege[h].ZugX;
                                testY = SpielfeldUI.schachbrett[i, j].AlleZuege[h].ZugY;
                                uFigur = SpielfeldUI.schachbrett[testX, testY].Bezeichnung;

                                TestSchachmatt(uFigur, testX, testY, i, j, true);

                                if (!schachschwarz)
                                {
                                    keinMatt = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (schachschwarz)
                {
                    mattSchwarz = true;
                }
            }
        }

        private static void TestSchachmatt(char uFigur, int TestX, int TestY, int i, int j, bool weiss)
        {
            SpielfeldUI.schachbrett[TestX, TestY] = SpielfeldUI.schachbrett[i, j];
            SpielfeldUI.schachbrett[TestX, TestY].PositionX = TestX;
            SpielfeldUI.schachbrett[TestX, TestY].PositionY = TestY;
            SpielfeldUI.schachbrett[i, j] = new LeeresFeld(i, j);

            SpielfeldUI.BerechneAlleZuege();
            Schach();

            SpielfeldUI.schachbrett[i, j] = SpielfeldUI.schachbrett[TestX, TestY];
            SpielfeldUI.schachbrett[i, j].PositionX = i;
            SpielfeldUI.schachbrett[i, j].PositionY = j;
            UrsprueglicheFigur(uFigur, TestX, TestY, weiss);
            SpielfeldUI.BerechneAlleZuege();
        }

        public static void UrsprueglicheFigur(char uFigur, int uFigurX, int uFigurY, bool weiss)
        {
            if (uFigur == '⦾')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Bauer('⦾', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♘')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Springer('♘', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♗')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Laeufer('♗', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♖')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Turm('♖', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♕')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Dame('♕', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♞')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Springer('♞', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♝')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Laeufer('♝', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♜')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Turm('♜', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '♛')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Dame('♛', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == '⦿')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new Dame('⦿', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == ' ')
            {
                SpielfeldUI.schachbrett[uFigurX, uFigurY] = new LeeresFeld(uFigurX, uFigurY);
            }
        }
    }
}

