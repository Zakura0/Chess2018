using System;
using System.Linq;

namespace Schachspiel
{
    public class Eingabe
    {
        public string BoolString;
        public int IntPlus;
        public char BoolChar;
        public static int PosX;
        public static int PosY;
        public int ZielX;
        public int ZielY;
        public bool OoB { get; set; }

        public void BewegeFigur()
        {
            EingabeNutzer();
            if (!OoB)
            {
                if (!Rochade.hatRochiert)
                {
                    ZieheFigur();
                }
                SchachMatt.Schach();
                if (SchachMatt.schachschwarz || SchachMatt.schachweiß)
                {
                    SchachMatt.Schachmatt();
                    if (!SchachMatt.MattSchwarz && !SchachMatt.MattWeiß)
                    {
                        SchachMatt.Schach();
                    }
                }
            }
        }

        public void ZieheFigur()
        {
            char urspruenglicheFigur;
            bool ungueltigWegenSchach = false;
            bool ungueltigerZug = true;
            if (Spielfeld.Schachbrett[PosX, PosY].Bezeichnung == ' ')
            {
                Console.WriteLine(Strings.KeineFigur);
                Console.ReadLine();
            }
            else if (!Spielfeld.Schachbrett[PosX, PosY].IstWeiss && Strings.Spielerfarbe == "weiße")
            {
                Console.WriteLine(Strings.NurWeiß);
                Console.ReadLine();
            }
            else if (Spielfeld.Schachbrett[PosX, PosY].IstWeiss && Strings.Spielerfarbe == "schwarze")
            {
                Console.WriteLine(Strings.NurSchwarz);
                Console.ReadLine();
            }
            else
            {
                int GueltigeZuege = Spielfeld.Schachbrett[PosX, PosY].AlleZuege.Count();
                for (int i = 0; i < GueltigeZuege; i++)
                {
                    if (ZielX == Spielfeld.Schachbrett[PosX, PosY].AlleZuege[i].ZugX &&
                        ZielY == Spielfeld.Schachbrett[PosX, PosY].AlleZuege[i].ZugY)
                    {
                        ungueltigerZug = false;
                        urspruenglicheFigur = Spielfeld.Schachbrett[ZielX, ZielY].Bezeichnung;
                        Spielfeld.Schachbrett[ZielX, ZielY] = Spielfeld.Schachbrett[PosX, PosY];
                        Spielfeld.Schachbrett[ZielX, ZielY].PositionX = ZielX;
                        Spielfeld.Schachbrett[ZielX, ZielY].PositionY = ZielY;
                        Spielfeld.Schachbrett[PosX, PosY] = new LeeresFeld();
                        if (Spielfeld.Schachbrett[7, 4].Bezeichnung != 'K')
                        {
                            Rochade.WeißeRochadeGueltig = false;
                        }
                        else if (Spielfeld.Schachbrett[0, 4].Bezeichnung != 'K')
                        {
                            Rochade.SchwarzeRochadeGueltig = false;
                        }

                        if (Strings.Spielerfarbe == "schwarze" && SchachMatt.schachschwarz)
                        {
                            Spielfeld.BerechneAlleZuege();
                            SchachMatt.Schach();
                            if (SchachMatt.schachschwarz)
                            {
                                ungueltigWegenSchach = true;
                                Spielfeld.Schachbrett[PosX, PosY] = Spielfeld.Schachbrett[ZielX, ZielY];
                                Spielfeld.Schachbrett[PosX, PosY].PositionX = PosX;
                                Spielfeld.Schachbrett[PosX, PosY].PositionY = PosY;
                                SchachMatt.UrsprueglicheFigur(urspruenglicheFigur, ZielX, ZielY, true);
                                Spielfeld.BerechneAlleZuege();
                                break;
                            }
                        }
                        else if (Strings.Spielerfarbe == "weiße" && SchachMatt.schachschwarz)
                        {
                            Spielfeld.BerechneAlleZuege();
                            SchachMatt.Schach();
                            if (SchachMatt.schachweiß)
                            {
                                ungueltigWegenSchach = true;
                                Spielfeld.Schachbrett[PosX, PosY] = Spielfeld.Schachbrett[ZielX, ZielY];
                                Spielfeld.Schachbrett[PosX, PosY].PositionX = PosX;
                                Spielfeld.Schachbrett[PosX, PosY].PositionY = PosY;
                                SchachMatt.UrsprueglicheFigur(urspruenglicheFigur, ZielX, ZielY, false);
                                Spielfeld.BerechneAlleZuege();
                                break;
                            }
                        }
                        if (Spielfeld.Schachbrett[ZielX, ZielY].Bezeichnung == 'B' && (ZielX == 7 || ZielX == 0))
                        {
                            Bauer.BauernUmwandlung(ZielX, ZielY);
                        }

                        Spielfeld.BerechneAlleZuege();
                        Spielerwechsel();
                        break;
                    }
                }
                if (ungueltigWegenSchach)
                {
                    Console.WriteLine("Die Figur (Typ: {0}) kann nicht ziehen da ihr König bedroht wird!", Spielfeld.Schachbrett[PosX, PosY].Bezeichnung);
                    Console.ReadLine();
                }
                else if (ungueltigerZug)
                {
                    Console.WriteLine("Der Zug ist ungültig für die gewählte Figur (Typ: {0})", Spielfeld.Schachbrett[PosX, PosY].Bezeichnung);
                    Console.ReadLine();
                }

            }
        }

        public void EingabeNutzer()
        {
            if (SchachMatt.MattSchwarz)
            {
                Console.WriteLine(Strings.GewonnenWeiß);
                Console.WriteLine(Strings.Beenden);
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (SchachMatt.MattWeiß)
            {
                Console.WriteLine(Strings.GewonnenSchwarz);
                Console.WriteLine(Strings.Beenden);
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (SchachMatt.schachweiß)
            {
                Console.WriteLine(Strings.SchachWeiß);
            }
            else if (SchachMatt.schachschwarz)
            {
                Console.WriteLine(Strings.SchachSchwarz);
            }

            Console.WriteLine("Der {0} Spieler ist am Zug.", Strings.Spielerfarbe);
            Rochade.Rochieren();
            if (Rochade.hatRochiert)
            {
                Spielerwechsel();
            }
            else if (!Rochade.hatRochiert)
            {
                Console.WriteLine(Strings.EingabePosY);
                PosY = EingabeBuchstabe(PosY);
                while (OoB)
                {
                    Console.WriteLine(Strings.eingabeUngueltig);
                    PosY = EingabeBuchstabe(PosY);
                }

                Console.WriteLine(Strings.EingabePosX);
                PosX = EingabeZahl(PosX);
                while (OoB)
                {
                    Console.WriteLine(Strings.eingabeUngueltig);
                    PosX = EingabeZahl(PosX);
                }

                Console.WriteLine(Strings.EingabeZielY);
                ZielY = EingabeBuchstabe(ZielY);
                while (OoB)
                {
                    Console.WriteLine(Strings.eingabeUngueltig);
                    ZielY = EingabeBuchstabe(ZielY);
                }

                Console.WriteLine(Strings.EingabeZielX);
                ZielX = EingabeZahl(ZielX);
                while (OoB)
                {
                    Console.WriteLine(Strings.eingabeUngueltig);
                    ZielX = EingabeZahl(ZielX);
                }
            }
        }

        private bool EingabeGueltig(int input, bool gueltig)
        {
            bool ungueltig = false;

            if (!gueltig)
                ungueltig = true;
            else if (input < 0)
                ungueltig = true;
            else if (input > 7)
                ungueltig = true;

            return ungueltig;
        }

        private void AbfrageOutOfBounds(int output)
        {
            int BoolInt = output;
            BoolString = Convert.ToString(BoolInt);
            OoB = EingabeGueltig(output, int.TryParse(BoolString, out output));
        }

        private int EingabeZahl(int Feld)
        {
            string boolstring = (Console.ReadLine());
            bool isInt = int.TryParse(boolstring, out int testint);
            if (boolstring == "" || !isInt)
            {
                OoB = true;
                return Feld;
            }
            else
            {
                IntPlus = int.Parse(boolstring);
                Feld = ZahlenUmdrehen(IntPlus);
                AbfrageOutOfBounds(Feld);
                return Feld;
            }
        }

        private int EingabeBuchstabe(int Feld)
        {
            string boolstring = (Console.ReadLine());
            bool isChar = char.TryParse(boolstring, out char testchar);
            if (boolstring == "" || !isChar)
            {
                OoB = true;
                return Feld;
            }
            else
            {
                BoolChar = char.Parse(boolstring);
                Feld = IstChar(BoolChar);
                AbfrageOutOfBounds(Feld);
                return Feld;
            }
        }

        private int IstChar(char BoolChar)
        {
            if (BoolChar == 'A' || BoolChar == 'a')
            {
                return 0;
            }
            else if (BoolChar == 'B' || BoolChar == 'b')
            {
                return 1;
            }
            else if (BoolChar == 'C' || BoolChar == 'c')
            {
                return 2;
            }
            else if (BoolChar == 'D' || BoolChar == 'd')
            {
                return 3;
            }
            else if (BoolChar == 'E' || BoolChar == 'e')
            {
                return 4;
            }
            else if (BoolChar == 'F' || BoolChar == 'f')
            {
                return 5;
            }
            else if (BoolChar == 'G' || BoolChar == 'g')
            {
                return 6;
            }
            else if (BoolChar == 'H' || BoolChar == 'h')
            {
                return 7;
            }
            else
            {
                return Convert.ToInt32(BoolChar);
            }
        }

        private int ZahlenUmdrehen(int Eingabe)
        {
            if (Eingabe == 1)
            {
                return 7;
            }
            else if (Eingabe == 2)
            {
                return 6;
            }
            else if (Eingabe == 3)
            {
                return 5;
            }
            else if (Eingabe == 4)
            {
                return 4;
            }
            else if (Eingabe == 5)
            {
                return 3;
            }
            else if (Eingabe == 6)
            {
                return 2;
            }
            else if (Eingabe == 7)
            {
                return 1;
            }
            else if (Eingabe == 8)
            {
                return 0;
            }
            else
            {
                return 99;
            }
        }

        private string Spielerwechsel()
        {
            if (Strings.Spielerfarbe == "weiße")
            {
                Strings.Spielerfarbe = "schwarze";
            }
            else if (Strings.Spielerfarbe == "schwarze")
            {
                Strings.Spielerfarbe = "weiße";
            }
            return Strings.Spielerfarbe;
        }
    }
}
