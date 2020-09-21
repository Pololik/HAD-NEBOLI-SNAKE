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
        public static int Šířka { get; set; }
        public static int Výška { get; set; }


        // Počet bodů za jedno ovoce
        public static int BodyEasy { get; set; }
        public static int BodyMed { get; set; }
        public static int BodyHard { get; set; }

        public static int FoodCount { get; set; }

        public static int Score { get; set; }
        public static DifficultyEnum Obtiznost { get; set; }
        public static Direction Direction { get; set; }
        public static bool Walls { get; set; }

        public SettingsVar()
        {
            Šířka = 15;
            Výška = 15;
            BodyEasy = 125;
            BodyMed = 150;
            BodyHard = 175;

            // další nemá moc smysl měnit
            FoodCount = 0;
            Score = 0;
            Obtiznost = DifficultyEnum.Medium;
            Direction = Direction.Down;
        }
    }
}
