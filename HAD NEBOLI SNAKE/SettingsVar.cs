using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAD_NEBOLI_SNAKE
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public class SettingsVar
    {
        /// <summary>
        /// Šířka mapy
        /// </summary>
        public static int MapWidth;
        /// <summary>
        /// Výška mapy
        /// </summary>
        public static int MapHeight;

        /// <summary>
        /// Souřadnice X na které had začíná
        /// </summary>
        public static int StartingX;
        /// <summary>
        /// Souřadnice Y na které had začíná
        /// </summary>
        public static int StartingY;

        public static int FoodCount { get; set; }
        public static int Score { get; set; }
        /// <summary>
        /// Počet bodů které je potřeba posbírat pro dokončení úrovně
        /// </summary>
        public static int ScoreNext;
        public static int Difficulty { get; set; }
        public static Direction Direction { get; set; }
        /// <summary>
        /// TRUE aby naražení hada do kraje mapy hada zabilo
        /// </summary>
        public static bool Edges { get; set; }

        public SettingsVar()
        {
            MapWidth = 60;
            MapHeight = 40;

            // začínající pozice a směr pohledu
            StartingX = 10;
            StartingY = 5;
            Direction = Direction.Down;

            // další nemá moc smysl měnit
            FoodCount = 0;
            Score = 0;
        }

        /// <summary>
        /// Načte nastavení z mapy
        /// </summary>
        /// <param name="Map"></param>
        public SettingsVar(Map Map)
        {
            MapWidth = Map.Width;
            MapHeight = Map.Height;
            StartingX = Map.StartingX;
            StartingY = Map.StartingY;
            Direction = Map.StartingDir;
            Edges = Map.Edges;
            FoodCount = 0;
            Score = 0;
        }
    }
}
