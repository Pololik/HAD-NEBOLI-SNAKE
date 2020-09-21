using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAD_NEBOLI_SNAKE
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        // počet ticků které se při pohybování hadem přeskakujou, tim se snižuje jeho rychlost
        private int tmpObt;
        private Direction tmpDir;
        private bool GameRunning = false;
        private float UnitWidth;
        private float UnitHeight;

        private Difficulty[] diffs = new Difficulty[SettingsConst.Num_DifficultyCount];
       
        public Form1()
        {
            diffs[0] = new Difficulty("Lehká", 100, 4);
            diffs[1] = new Difficulty("Střední", 125, 2);
            diffs[2] = new Difficulty("Těžká", 150, 1);

            InitializeComponent();

            //----- je strašnej odpad ale líp to neumim :(, ve Form1.Designer.cs se to furt přepisuje
            Text = SettingsConst.String_WindowTitle;
            labelControls0.Text = SettingsConst.String_Controls;
            checkboxSettingsWalls.Text = SettingsConst.String_SettingWalls;
            pbGameField.Width = SettingsConst.Num_GameWidth;
            pbGameField.Height = SettingsConst.Num_GameHeight;
            radioButtonSettings1.Text = diffs[0].Name;
            radioButtonSettings2.Text = diffs[1].Name;
            radioButtonSettings3.Text = diffs[2].Name;
            //------------------------

            labelGameOver.Text = SettingsConst.String_Start;

            // nastaví game timer
            GameTimer.Interval = SettingsConst.Num_TickInterval;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Start();
        }
        private void SetDifficulty()
        {
            if (radioButtonSettings1.Checked)
            {
                SettingsVar.Difficulty = 0;
            }
            else if (radioButtonSettings2.Checked)
            {
                SettingsVar.Difficulty = 1;
            }
            else if (radioButtonSettings3.Checked)
            {
                SettingsVar.Difficulty = 2;
            }
        }

        private void HideStuff()
        {
            labelGameOver.Visible = false;
            panelSettings.Enabled = false; // nebo Visible
        }

        private void ShowStuff()
        {
            labelGameOver.Visible = true;
            panelSettings.Enabled = true;
        }

        private void StartGame()
        {
            GameRunning = true;
            HideStuff();
            pbGameField.Select(); // odznačí nastavení aby se po konci hry omylem nezměnilo

            // nastaví nastavení na defaultní - směr pohledu, skóre...
            new SettingsVar();
            SetDifficulty();
            SettingsVar.Walls = checkboxSettingsWalls.Checked;
            tmpDir = SettingsVar.Direction;
            UnitWidth = pbGameField.Width / SettingsVar.MapWidth;
            UnitHeight = pbGameField.Height / SettingsVar.MapHeight;

            // vytvoří novou část hada
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            labelFoodCount0.Text = SettingsVar.FoodCount.ToString();
            labelScore0.Text = SettingsVar.Score.ToString();
            GenerateFood();
        }

        // položí ovoce na náhodnou pozici
        private void GenerateFood()
        {
            bool isOutsideSnake = false;
            while (isOutsideSnake != true)
            {
                Random random = new Random();
                food = new Circle { X = random.Next(0, SettingsVar.MapWidth), Y = random.Next(0, SettingsVar.MapHeight) };
                foreach (Circle x in Snake)
                {
                    if (food.X != x.X || food.Y != x.Y)
                    {
                        isOutsideSnake = true;
                    }
                }
            }

        }

        private void UpdateScreen(object sender, EventArgs e)
        {

            // zkontroluje jestli hra běží
            if (!GameRunning)
            {
                // zkontroluje jestli je enter nebo mezernik stlačen
                if (Input.KeyPressed(Keys.Enter) || Input.KeyPressed(Keys.Space))
                {
                    StartGame();
                }
                // zkontroluje jestli je stlačen esc
                if (Input.KeyPressed(Keys.Escape))
                {
                    Application.Exit();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Escape))
                {
                    Input.ChangeState(Keys.Escape, false);
                    EndGame();
                }
                if ((Input.KeyPressed(Keys.Right) || Input.KeyPressed(Keys.D)) && SettingsVar.Direction != Direction.Left)
                    tmpDir = Direction.Right;
                else if ((Input.KeyPressed(Keys.Left) || Input.KeyPressed(Keys.A)) && SettingsVar.Direction != Direction.Right)
                    tmpDir = Direction.Left;
                else if ((Input.KeyPressed(Keys.Up) || Input.KeyPressed(Keys.W)) && SettingsVar.Direction != Direction.Down)
                    tmpDir = Direction.Up;
                else if ((Input.KeyPressed(Keys.Down) || Input.KeyPressed(Keys.S)) && SettingsVar.Direction != Direction.Up)
                    tmpDir = Direction.Down;

                // přeskakování ticků pro úpravu obtížnosti
                if (diffs[SettingsVar.Difficulty].SkipCount > 0)
                {
                    if (tmpObt > 0)
                    {
                        tmpObt--;
                        return;
                    }
                    else
                    {
                        tmpObt = diffs[SettingsVar.Difficulty].SkipCount;
                    }
                }
                SettingsVar.Direction = tmpDir;
                MovePlayer();
            }

            pbGameField.Invalidate();
        }

        private void pbGameField_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            int tmpWidth = Convert.ToInt32(UnitWidth);
            int tmpHeight = Convert.ToInt32(UnitHeight);

            if (GameRunning)
            {
                //Nakreslí hada
                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    // volba barvy
                    if (i == 0)
                        snakeColour = Brushes.DarkMagenta; // hlava je černá
                    else
                        snakeColour = Brushes.DarkOrange; // tělo zelený

                    // vybarví kolečko
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * tmpWidth,
                                      Snake[i].Y * tmpHeight,
                                      tmpWidth, tmpHeight));
                }

                //Nakreslí jídlo
                canvas.FillEllipse(Brushes.ForestGreen,
                    new Rectangle(food.X * tmpWidth,
                         food.Y * tmpHeight, tmpWidth, tmpHeight));

            }
        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                // pohyb hlavy
                if (i == 0)
                {
                    switch (SettingsVar.Direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }

                    // detekuje kolize s okrajema. když nejsou zdi tak teleportuje na druhou stranu
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= SettingsVar.MapWidth || Snake[i].Y >= SettingsVar.MapHeight)
                    {
                        if (SettingsVar.Walls)
                        {
                            EndGame();
                        }
                        else
                        {
                            if (Snake[i].X < 0)
                            {
                                Snake[i].X = SettingsVar.MapWidth - 1;
                            }
                            else if (Snake[i].Y < 0)
                            {
                                Snake[i].Y = SettingsVar.MapHeight - 1;
                            }
                            else if (Snake[i].X >= SettingsVar.MapWidth)
                            {
                                Snake[i].X = 0;
                            }
                            else if (Snake[i].Y >= SettingsVar.MapHeight)
                            {
                                Snake[i].Y = 0;
                            }
                        }
                    }

                    // detekuje kolize s tělem
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            EndGame();
                        }
                    }

                    // detekuje kolize s jídlem
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood();
                    }

                }
                else
                {
                    // pohyb těla
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);

            // tyhle 2(+2) řádky způsoběj že
            // se nastavení nebude moct měnit klávesama (šipkama se ovládaj třeba radio čudlíky)
            // a odstraněj zvuk při zmáčknutí většiny kláves
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void EatFood()
        {
            // přidá kruh k tělu
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(circle);

            // updatuje skóre
            int tmpScore = 0;
            tmpScore += diffs[SettingsVar.Difficulty].ScoreInc;

            if (SettingsVar.Walls)
            {
                tmpScore *= SettingsConst.Num_WallsMultiplier;
            }
            SettingsVar.Score += tmpScore;

            labelScore0.Text = SettingsVar.Score.ToString();

            GenerateFood();

            // updatuje jídla
            SettingsVar.FoodCount++;
            labelFoodCount0.Text = SettingsVar.FoodCount.ToString();
        }

        private void EndGame()
        {
            GameRunning = false;

            string gameOver =   "KONEC HRY\n\n" +
                                "TVOJE FINÁLNÍ SKÓRE JE:  " + SettingsVar.Score +
                                "\n\nSNĚDL JSI:  " + SettingsVar.FoodCount + " JÍDLA" +
                                "\n\nSTISKNI ENTER PRO DALŠÍ POKUS";
            labelGameOver.Text = gameOver;

            ShowStuff();
        }
    }
}
