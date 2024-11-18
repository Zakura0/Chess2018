using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schachspiel
{
    class Strings
    {
        public static string Spielerfarbe = "weiße";
        public const string Freund = "Kann nicht auf freundlich besetztes Feld ziehen.";
        public static readonly string eingabeUngueltig = "Der Eintrag war ungültig, bitte erneut eingeben.";
        public static readonly string KeineFigur = "Keine Figur zum Ziehen gewählt, bitte Eingabe wiederholen.";
        public static readonly string NurWeiß = "Der weiße Spieler kann nur die weißen Figuren bewegen!";
        public static readonly string NurSchwarz = "Der schwarze Spieler kann nur die schwarzen Figuren bewegen!";
        public static readonly string Beenden = "Beenden mit Enter.";
        public static readonly string GewonnenWeiß = "Schachmatt! Der weiße Spieler hat die Partie gewonnen!";
        public static readonly string GewonnenSchwarz = "Schachmatt! Der schwarze Spieler hat die Partie gewonnen!";
        public static readonly string SchachWeiß = "Der weiße König steht im Schach!";
        public static readonly string SchachSchwarz = "Der schwarze König steht im Schach!";
        public static readonly string EingabePosY = "Bitte den Buchstaben der Spalte der zu bewegenden Figur eintragen:";
        public static readonly string EingabePosX = "Bitte die Koordinate der Reihe der zu bewegenden Figur eintragen:";
        public static readonly string EingabeZielY = "Bitte den Buchstaben der Spalte des Zielfeldes eintragen:";
        public static readonly string EingabeZielX = "Bitte die Koordinate der Reihe des Zielfeldes eintragen:";
    }
}
