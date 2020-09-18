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

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public class Settings
    {
        // velikost kuliček
        public static int Šířka { get; set; }
        public static int Výška { get; set; }

        // Rychlost updatování okna, zároveň určuje nejvyšší možnou rychlost hada (těžká obtížnost)
        public static int Rychlost { get; set; }


        // Počet bodů za jedno ovoce
        public static int BodyEasy { get; set; }
        public static int BodyMed { get; set; }
        public static int BodyHard { get; set; }

        public static int Score { get; set; }
        public static Difficulty Obtiznost { get; set; }
        public static bool KonecHry { get; set; }
        public static Direction směr { get; set; }
        public static bool Zdi { get; set; }

        public Settings()
        {
            Šířka = 15;
            Výška = 15;
            Rychlost = 100;
            BodyEasy = 100;
            BodyMed = 250;
            BodyHard = 600;

            // další nemá moc smysl měnit
            Score = 0;
            Obtiznost = Difficulty.Medium;
            KonecHry = false;
            směr = Direction.Down;
        }
    }
}
