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
        // velikost kuliček, bylo by super kdyby velikost hrací plochy byla dělitelná tímto číslem
        public static int MapWidth;
        public static int MapHeight;

        public static int StartingX;
        public static int StartingY;

        public static int FoodCount { get; set; }
        public static int Score { get; set; }
        public static int ScoreNext;
        public static int Difficulty { get; set; }
        public static Direction Direction { get; set; }
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
