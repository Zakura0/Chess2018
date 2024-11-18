using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SchachspielUI
{
    public partial class BauernUW : Window
    {
        public BauernUW()
        {
            InitializeComponent();

            if (SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY].Bezeichnung == '⦾' || SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY].Bezeichnung == '⦿')
            {
                if (SpielfeldUI.spielerfarbe == "weiße")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Dame('♕', true, Bewegung.zielX, Bewegung.zielY);
                }
                else if (SpielfeldUI.spielerfarbe == "schwarze")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Dame('♛', false, Bewegung.zielX, Bewegung.zielY);
                }
            }

            if (SpielfeldUI.spielerfarbe == "weiße")
            {
                tb1.Content = "♕";
                tb2.Content = "♖";
                tb3.Content = "♘";
                tb4.Content = "♗";
            }
            else if (SpielfeldUI.spielerfarbe == "schwarze")
            {
                tb1.Content = "♛";
                tb2.Content = "♜";
                tb3.Content = "♞";
                tb4.Content = "♝";
            }

            auswahl = " ";
        }

        private static string auswahl;

        private void Click_UW(object sender, RoutedEventArgs e)
        {
            auswahl = Convert.ToString((sender as ToggleButton).Content);

            if (auswahl == "♕" || auswahl == "♛")
            {
                tb2.IsChecked = false;
                tb3.IsChecked = false;
                tb4.IsChecked = false;
            }
            else if (auswahl == "♖" || auswahl == "♜")
            {
                tb1.IsChecked = false;
                tb3.IsChecked = false;
                tb4.IsChecked = false;
            }
            else if (auswahl == "♘" || auswahl == "♞")
            {
                tb1.IsChecked = false;
                tb2.IsChecked = false;
                tb4.IsChecked = false;
            }
            else if (auswahl == "♗" || auswahl == "♝")
            {
                tb1.IsChecked = false;
                tb2.IsChecked = false;
                tb3.IsChecked = false;
            }
        }
        private void Click_UWB(object sender, RoutedEventArgs e)
        {
            if (auswahl == "♕" || auswahl == "♛" || auswahl == " ")
            {
                if (SpielfeldUI.spielerfarbe == "weiße")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Dame('♕', true, Bewegung.zielX, Bewegung.zielY);
                }
                else if (SpielfeldUI.spielerfarbe == "schwarze")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Dame('♛', false, Bewegung.zielX, Bewegung.zielY);
                }
            }
            else if (auswahl == "♖" || auswahl == "♜")
            {
                if (SpielfeldUI.spielerfarbe == "weiße")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Turm('♖', true, Bewegung.zielX, Bewegung.zielY);
                }
                else if (SpielfeldUI.spielerfarbe == "schwarze")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Turm('♜', false, Bewegung.zielX, Bewegung.zielY);
                }
            }
            else if (auswahl == "♘" || auswahl == "♞")
            {
                if (SpielfeldUI.spielerfarbe == "weiße")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Springer('♘', true, Bewegung.zielX, Bewegung.zielY);
                }
                else if (SpielfeldUI.spielerfarbe == "schwarze")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Springer('♞', false, Bewegung.zielX, Bewegung.zielY);
                }
            }
            else if (auswahl == "♗" || auswahl == "♝")
            {
                if (SpielfeldUI.spielerfarbe == "weiße")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Laeufer('♗', true, Bewegung.zielX, Bewegung.zielY);
                }
                else if (SpielfeldUI.spielerfarbe == "schwarze")
                {
                    SpielfeldUI.schachbrett[Bewegung.zielX, Bewegung.zielY] = new Laeufer('♝', false, Bewegung.zielX, Bewegung.zielY);
                }
            }

            Close();
        }
    }
}
