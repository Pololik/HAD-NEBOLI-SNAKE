using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAD_NEBOLI_SNAKE
{
    /// <summary>
    /// Třída obsahující seznam překážek
    /// </summary>
    public class Map
    {
        public Graphics Canvas;
        public List<MapObject> Obstacles;
        public int Width;
        public int Height;
        public bool Edges;
        public Brush ObsColor = Brushes.Black;
        public int StartingX;
        public int StartingY;
        public Direction StartingDir;
        public int ScoreNext;

        public int UnitWidth;
        public int UnitHeight;

        public Map(int Width, int Height, int StartingX, int StartingY, Direction StartingDir, List<MapObject> Obstacles, bool Edges, int ScoreNext)
        {
            this.Width = Width;
            this.Height = Height;
            this.Obstacles = Obstacles;
            this.StartingX = StartingX;
            this.StartingY = StartingY;
            this.StartingDir = StartingDir;
            this.Edges = Edges;
            this.ScoreNext = ScoreNext;

            UnitWidth = SettingsConst.Num_GameWidth / Width;
            UnitHeight = SettingsConst.Num_GameHeight / Height;
        }

        public void SetCanvas(Graphics Canvas)
        {
            this.Canvas = Canvas;
        }

        public void SetColor(Brush Color)
        {
            this.ObsColor = Color;
        }

        /// <summary>
        /// Vykreslí do kanvasu překážky
        /// </summary>
        public void Draw()
        {
            foreach(MapObject Obs in Obstacles)
            {
                Canvas.FillRectangle(ObsColor, new Rectangle(Obs.X * UnitWidth, Obs.Y * UnitHeight, Obs.Width * UnitWidth, Obs.Height * UnitHeight));
            }
        }
    }
}
