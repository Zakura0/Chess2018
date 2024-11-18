using System;
using System.Windows;
using System.Windows.Media;

namespace SchachspielUI
{
    public partial class SpielfeldUI : Window
    {

        public static string spielerfarbe = "weiße";

        public SpielfeldUI()
        {
            InitializeComponent();
            SetzeStartFiguren();
            SetzeFiguren();
        }

        public static Spielfigur[,] schachbrett = new Spielfigur[8, 8];

        public static void BerechneAlleZuege()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (schachbrett[i, j].Bezeichnung != ' ')
                    {
                        schachbrett[i, j].AlleZuege.Clear();
                    }
                    schachbrett[i, j].BerechneZuege(schachbrett);
                }
            }
        }

        private void SetzeStartFiguren()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 6)
                    {
                        schachbrett[i, j] = new Bauer('⦾', true, i, j);
                    }
                    else if (i == 1)
                    {
                        schachbrett[i, j] = new Bauer('⦿', false, i, j);
                    }
                    else if (i == 0 || i == 7)
                    {
                        schachbrett[7, 0] = new Turm('♖', true, 7, 0);
                        schachbrett[7, 1] = new Springer('♘', true, 7, 1);
                        schachbrett[7, 2] = new Laeufer('♗', true, 7, 2);
                        schachbrett[7, 3] = new Dame('♕', true, 7, 3);
                        schachbrett[7, 4] = new Koenig('♔', true, 7, 4);
                        schachbrett[7, 5] = new Laeufer('♗', true, 7, 5);
                        schachbrett[7, 6] = new Springer('♘', true, 7, 6);
                        schachbrett[7, 7] = new Turm('♖', true, 7, 7);

                        schachbrett[0, 0] = new Turm('♜', false, 0, 0);
                        schachbrett[0, 1] = new Springer('♞', false, 0, 1);
                        schachbrett[0, 2] = new Laeufer('♝', false, 0, 2);
                        schachbrett[0, 3] = new Dame('♛', false, 0, 3);
                        schachbrett[0, 4] = new Koenig('♚', false, 0, 4);
                        schachbrett[0, 5] = new Laeufer('♝', false, 0, 5);
                        schachbrett[0, 6] = new Springer('♞', false, 0, 6);
                        schachbrett[0, 7] = new Turm('♜', false, 0, 7);
                    }
                    else
                    {
                        schachbrett[i, j] = new LeeresFeld(i, j);
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    UniSpielfeld.Children.Add(schachbrett[i, j]);
                }
            }
        }

        private void SetzeFiguren()
        {

            UniSpielfeld.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    UniSpielfeld.Children.Add(schachbrett[i, j]);
                    schachbrett[i, j].Content = schachbrett[i, j].Bezeichnung;
                    if (schachbrett[i, j].IstWeiss)
                    {
                        schachbrett[i, j].Foreground = Brushes.Black;
                    }
                    if (!schachbrett[i, j].IstWeiss)
                    {
                        schachbrett[i, j].Foreground = Brushes.Black;
                    }

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            schachbrett[i, j].Background = Brushes.White;
                        }
                        else
                        {
                            schachbrett[i, j].Background = Brushes.DarkGray;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            schachbrett[i, j].Background = Brushes.DarkGray;
                        }
                        else
                        {
                            schachbrett[i, j].Background = Brushes.White;
                        }
                    }
                }
            }
            if (spielerfarbe == "weiße")
            {
                recWeiß.Content = "X";
                recSchwarz.Content = "";
            }
            else if (spielerfarbe == "schwarze")
            {
                recWeiß.Content = "";
                recSchwarz.Content = "X";
            }

            ClickRefresh();

        }

        private void MarkiereFelder()
        {

            int anzahlZuege = schachbrett[Bewegung.posX, Bewegung.posY].AlleZuege.Count;

            for (int i = 0; i < anzahlZuege; i++)
            {
                int MarkX = schachbrett[Bewegung.posX, Bewegung.posY].AlleZuege[i].ZugX;
                int MarkY = schachbrett[Bewegung.posX, Bewegung.posY].AlleZuege[i].ZugY;

                if (schachbrett[MarkX, MarkY].Bezeichnung != ' ')
                {
                    schachbrett[MarkX, MarkY].Background = Brushes.IndianRed;
                }
                else
                {
                    schachbrett[MarkX, MarkY].Background = Brushes.LightGreen;
                }
            }
        }

        private static bool ersterZug = true;

        public static bool gueltigerZug;

        public void ClickRefresh()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    schachbrett[i, j].Click -= Button_Click;
                    schachbrett[i, j].Click += Button_Click;
                }
            }
        }

        void bb_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {

            Rochade.Rochieren();

            gueltigerZug = false;

            if (ersterZug)
            {
                Bewegung.posX = (sender as Spielfigur).PositionX;
                Bewegung.posY = (sender as Spielfigur).PositionY;

                if ((spielerfarbe == "weiße" && schachbrett[Bewegung.posX, Bewegung.posY].IstWeiss)
                    || (spielerfarbe == "schwarze" && !schachbrett[Bewegung.posX, Bewegung.posY].IstWeiss)
                    && schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung != ' ')
                {
                    BerechneAlleZuege();
                    MarkiereFelder();

                    if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♔' && Rochade.weißeRochadeGueltig && Rochade.w_links)
                    {
                        schachbrett[7, 2].Background = Brushes.LightGreen;
                    }
                    if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♔' && Rochade.weißeRochadeGueltig && Rochade.w_rechts)
                    {
                        schachbrett[7, 6].Background = Brushes.LightGreen;
                    }
                    if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♚' && Rochade.schwarzeRochadeGueltig && Rochade.b_links)
                    {
                        schachbrett[0, 2].Background = Brushes.LightGreen;
                    }
                    if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♚' && Rochade.schwarzeRochadeGueltig && Rochade.b_rechts)
                    {
                        schachbrett[0, 6].Background = Brushes.LightGreen;
                    }


                    ersterZug = false;
                }
            }
            else if (!ersterZug)
            {
                Bewegung.zielX = (sender as Spielfigur).PositionX;
                Bewegung.zielY = (sender as Spielfigur).PositionY;

                if (schachbrett[Bewegung.zielX, Bewegung.zielY].Bezeichnung != ' ')
                {
                    schlag = " x ";
                }
                else
                {
                    schlag = " - ";
                }

                
                sFigur1 = Convert.ToString(schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung);
                sFigur2 = Convert.ToString(schachbrett[Bewegung.zielX, Bewegung.zielY].Bezeichnung);
                hposX = Convert.ToString(FelderNotierungX(Bewegung.posX));
                hposY = Convert.ToString(FelderNotierungY(Bewegung.posY));
                hzielX = Convert.ToString(FelderNotierungX(Bewegung.zielX));
                hzielY = Convert.ToString(FelderNotierungY(Bewegung.zielY));

                if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♔' && Rochade.weißeRochadeGueltig && Rochade.w_links && Bewegung.zielX == 7 && Bewegung.zielY == 2)
                {
                    Rochade._Rochieren(true, false);
                }
                if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♔' && Rochade.weißeRochadeGueltig && Rochade.w_rechts && Bewegung.zielX == 7 && Bewegung.zielY == 6)
                {
                    Rochade._Rochieren(true, true);
                }
                if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♚' && Rochade.schwarzeRochadeGueltig && Rochade.b_links && Bewegung.zielX == 0 && Bewegung.zielY == 2)
                {
                    Rochade._Rochieren(false, false);
                }
                if (schachbrett[Bewegung.posX, Bewegung.posY].Bezeichnung == '♚' && Rochade.schwarzeRochadeGueltig && Rochade.b_rechts && Bewegung.zielX == 0 && Bewegung.zielY == 6)
                {
                    Rochade._Rochieren(false, true);
                }

                Bewegung.BewegeFigur();

                SetzeFiguren();
                ersterZug = true;

                if (gueltigerZug && !Bewegung.ungueltigWegenSchach && !Rochade.hatRochiert)
                {
                    NotiereZug();
                }

                if (Rochade.hatRochiert)
                {
                    sFigur2 = "";
                    hposX = "";
                    hposY = "";
                    hzielX = "";
                    hzielY = "";
                    schlag = "";

                    if (Rochade.w_links)
                    {
                        sFigur1 = "W 0-0-0";
                        NotiereZug();
                    }
                    else if (Rochade.w_rechts)
                    {
                        sFigur1 = "W 0-0";
                        NotiereZug();
                    }
                    else if (Rochade.b_links)
                    {
                        sFigur1 = "B 0-0-0";
                        NotiereZug();
                    }
                    else if (Rochade.b_rechts)
                    {
                        sFigur1 = "B 0-0";
                        NotiereZug();
                    }
                }

                if (Bewegung.ungueltigWegenSchach)
                {
                    MessageBox.Show("Kann nicht ziehen, da der König sonst im Schach steht!", "Achtung");
                }

                if (SchachMatt.mattSchwarz)
                {
                    MessageBox.Show("Der schwarze König steht im Schachmatt!", "Spielende");
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            bBeenden.Visibility = Visibility.Visible;
                            schachbrett[i, j].IsHitTestVisible = false;
                        }
                    }
                    infoLabel.Content = "Schachmatt! Bitte das Spiel beenden.";

                }
                else if (SchachMatt.mattWeiß)
                {
                    MessageBox.Show("Der weiße König steht im Schachmatt!", "Spielende");
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            bBeenden.Visibility = Visibility.Visible;
                            schachbrett[i, j].IsHitTestVisible = false;
                        }
                    }
                    infoLabel.Content = "Schachmatt! Bitte das Spiel beenden.";
                }

                if (SchachMatt.schachweiß)
                {
                    infoLabel.Content = "Der weiße König steht im Schach";
                }
                else if (SchachMatt.schachschwarz)
                {
                    infoLabel.Content = "Der schwarze König steht im Schach!";
                }
                else
                {
                    infoLabel.Content = "";
                }
            }
        }

        private static string sFigur1;
        private static string sFigur2;
        private static string schlag;
        private static string hposX;
        private static string hposY;
        private static string hzielX;
        private static string hzielY;

        private static string sHistorie;

        public void NotiereZug()
        {
            sHistorie = historie.Text;
            historie.Text = sHistorie + sFigur1 + hposY + hposX + schlag + sFigur2 + hzielY + hzielX + "\n";
            historie.ScrollToEnd();
        }

        private int FelderNotierungX(int feld)
        {
            if (feld == 0)
            {
                return 8;
            }
            else if (feld == 1)
            {
                return 7;
            }
            else if (feld == 2)
            {
                return 6;
            }
            else if (feld == 3)
            {
                return 5;
            }
            else if (feld == 4)
            {
                return feld;
            }
            else if (feld == 5)
            {
                return 3;
            }
            else if (feld == 6)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        private string FelderNotierungY(int feld)
        {
            if (feld == 0)
            {
                return "a";
            }
            else if (feld == 1)
            {
                return "b";
            }
            else if (feld == 2)
            {
                return "c";
            }
            else if (feld == 3)
            {
                return "d";
            }
            else if (feld == 4)
            {
                return "e";
            }
            else if (feld == 5)
            {
                return "f";
            }
            else if (feld == 6)
            {
                return "g";
            }
            else
            {
                return "h";
            }
        }
    }
}
