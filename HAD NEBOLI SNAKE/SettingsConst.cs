using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAD_NEBOLI_SNAKE
{
    class SettingsConst
    {
        // název fontu pro celou aplikaci
        public const string FontName = "Verdana";


        // hlášky a texty
        public const string String_WindowTitle = "HAD NEBOLI SNAKE";
        public const string String_Start = "Stiskni ENTER pro start hry";
        public const string String_Controls = "Pohyb: WASD/ŠIPKY" + "\n" + "Konec Hry: ESC";


        // herní hodnotky
        public const int Num_TickInterval = 10; // v ms
        public const int Num_DifficultyCount = 3; // pokud se zmeni todle bude se zmenit vic veci :(
        public const int Num_WallsMultiplier = 4;
        public const int Num_GameWidth = 900;
        public const int Num_GameHeight = 600;

    }
}
