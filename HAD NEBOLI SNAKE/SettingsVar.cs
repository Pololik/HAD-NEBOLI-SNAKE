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

    public enum DifficultyEnum
    {
        Easy,
        Medium,
        Hard
    }

    public class SettingsVar
    {
        // velikost kuliček, bylo by super kdyby velikost hrací plochy byla dělitelná tímto číslem
        public static int MapWidth;
        public static int MapHeight;


        // Počet bodů za jedno ovoce
        public static int BodyEasy { get; set; }
        public static int BodyMed { get; set; }
        public static int BodyHard { get; set; }

        public static int FoodCount { get; set; }

        public static int Score { get; set; }
        public static int Difficulty { get; set; }
        public static Direction Direction { get; set; }
        public static bool Walls { get; set; }

        public SettingsVar()
        {
            MapWidth = 60;
            MapHeight = 40;
            BodyEasy = 125;
            BodyMed = 150;
            BodyHard = 175;

            // další nemá moc smysl měnit
            FoodCount = 0;
            Score = 0;
            Difficulty = 1;
            Direction = Direction.Down;
        }
    }
}
