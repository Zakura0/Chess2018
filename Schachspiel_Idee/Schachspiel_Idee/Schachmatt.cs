using System.Linq;

namespace Schachspiel
{
    class SchachMatt
    {
        public static bool schachweiß;
        public static bool schachschwarz;

        public static void Schach()
        {
            int SchachX;
            int SchachY;
            int AnzahlZuege;

            schachweiß = false;
            schachschwarz = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Spielfeld.Schachbrett[i, j].IstWeiss && Spielfeld.Schachbrett[i, j].Bezeichnung == 'K')
                    {
                        SchachX = i; SchachY = j;

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

                                if (Spielfeld.Schachbrett[r, t].Bezeichnung != ' ' && !Spielfeld.Schachbrett[r, t].IstWeiss)
                                {
                                    AnzahlZuege = Spielfeld.Schachbrett[r, t].AlleZuege.Count();
                                    for (int h = 0; h < AnzahlZuege; h++)
                                    {
                                        if (Spielfeld.Schachbrett[r, t].AlleZuege[h].ZugX == SchachX &&
                                            Spielfeld.Schachbrett[r, t].AlleZuege[h].ZugY == SchachY)
                                        {
                                            schachweiß = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!Spielfeld.Schachbrett[i, j].IstWeiss && Spielfeld.Schachbrett[i, j].Bezeichnung == 'K')
                    {
                        SchachX = i; SchachY = j;

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

                                if (Spielfeld.Schachbrett[r, t].Bezeichnung != ' ' && Spielfeld.Schachbrett[r, t].IstWeiss)
                                {
                                    AnzahlZuege = Spielfeld.Schachbrett[r, t].AlleZuege.Count();
                                    for (int h = 0; h < AnzahlZuege; h++)
                                    {
                                        if (Spielfeld.Schachbrett[r, t].AlleZuege[h].ZugX == SchachX &&
                                            Spielfeld.Schachbrett[r, t].AlleZuege[h].ZugY == SchachY)
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
        public static bool MattSchwarz;
        public static bool MattWeiß;

        public static void Schachmatt()
        {
            bool KeinMatt = false;
            MattSchwarz = false;
            MattWeiß = false;
            int TestX;
            int TestY;
            int AnzahlZuege;
            char uFigur;

            if (schachweiß)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (KeinMatt)
                    {
                        break;
                    }
                    for (int j = 0; j < 8; j++)
                    {

                        if (KeinMatt)
                        {
                            break;
                        }

                        if (Spielfeld.Schachbrett[i, j].IstWeiss && Spielfeld.Schachbrett[i, j].Bezeichnung != ' ')
                        {
                            AnzahlZuege = Spielfeld.Schachbrett[i, j].AlleZuege.Count();
                            for (int h = 0; h < AnzahlZuege; h++)
                            {
                                TestX = Spielfeld.Schachbrett[i, j].AlleZuege[h].ZugX;
                                TestY = Spielfeld.Schachbrett[i, j].AlleZuege[h].ZugY;
                                uFigur = Spielfeld.Schachbrett[TestX, TestY].Bezeichnung;

                                TestSchachmatt(uFigur, TestX, TestY, i, j, false);

                                if (!schachweiß)
                                {
                                    KeinMatt = true;
                                    break;
                                }
                            }
                        }
                    }                    
                }
                if (schachweiß)
                {
                    MattWeiß = true;
                }
            }

            else if (schachschwarz)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (KeinMatt)
                    {
                        break;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        if (KeinMatt)
                        {
                            break;
                        }

                        if (!Spielfeld.Schachbrett[i, j].IstWeiss && Spielfeld.Schachbrett[i, j].Bezeichnung != ' ')
                        {
                            AnzahlZuege = Spielfeld.Schachbrett[i, j].AlleZuege.Count();
                            for (int h = 0; h < AnzahlZuege; h++)
                            {
                                TestX = Spielfeld.Schachbrett[i, j].AlleZuege[h].ZugX;
                                TestY = Spielfeld.Schachbrett[i, j].AlleZuege[h].ZugY;
                                uFigur = Spielfeld.Schachbrett[TestX, TestY].Bezeichnung;

                                TestSchachmatt(uFigur, TestX, TestY, i, j, true);

                                if (!schachschwarz)
                                {
                                    KeinMatt = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (schachschwarz)
                {
                    MattSchwarz = true;
                }
            }
        }

        private static void TestSchachmatt(char uFigur, int TestX, int TestY, int i, int j, bool weiss)
        {
            Spielfeld.Schachbrett[TestX, TestY] = Spielfeld.Schachbrett[i, j];
            Spielfeld.Schachbrett[TestX, TestY].PositionX = TestX;
            Spielfeld.Schachbrett[TestX, TestY].PositionY = TestY;
            Spielfeld.Schachbrett[i, j] = new LeeresFeld();

            Spielfeld.BerechneAlleZuege();
            Schach();

            Spielfeld.Schachbrett[i, j] = Spielfeld.Schachbrett[TestX, TestY];
            Spielfeld.Schachbrett[i, j].PositionX = i;
            Spielfeld.Schachbrett[i, j].PositionY = j;
            UrsprueglicheFigur(uFigur, TestX, TestY, weiss);
            Spielfeld.BerechneAlleZuege();
        }

        public static void UrsprueglicheFigur(char uFigur, int uFigurX, int uFigurY, bool weiss)
        {
            if (uFigur == 'B')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new Bauer('B', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == 'S')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new Springer('S', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == 'L')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new Laeufer('L', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == 'T')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new Turm('T', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == 'D')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new Dame('D', weiss, uFigurX, uFigurY);
            }
            else if (uFigur == ' ')
            {
                Spielfeld.Schachbrett[uFigurX, uFigurY] = new LeeresFeld();
            }
        }
    }
}

