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
        // obtiznostnik = 0... přeskočí se 0 ticků, rychlost je maximální
        private int obtiznostnik;
        private int tmpObt;
        private Direction tmpDir;
        private bool GameRunning = false;

        private Difficulty[] diffs = new Difficulty[SettingsConst.Num_DifficultyCount];
       
        public Form1()
        {
            diffs.Append(new Difficulty("Lehká", 100, 4));
            diffs.Append(new Difficulty("Střední", 125, 2));
            diffs.Append(new Difficulty("Těžká", 150, 1));

            InitializeComponent();

            labelGameOver.Text = SettingsConst.String_Start;

            //Nastaví hrací rychlost a game timer
            GameTimer.Interval = SettingsConst.Num_TickInterval;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Start();
        }
        private void NastavObtiznost()
        {
            if (radioButtonSettings3.Checked)
            {
                obtiznostnik = 1;
                SettingsVar.Obtiznost = DifficultyEnum.Hard;
            }
            else if (radioButtonSettings2.Checked)
            {
                obtiznostnik = 2;
                SettingsVar.Obtiznost = DifficultyEnum.Medium;
            }
            else if (radioButtonSettings1.Checked)
            {
                obtiznostnik = 4;
                SettingsVar.Obtiznost = DifficultyEnum.Easy;
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

            //Nastaví nastavení na defaultní - smer pohledu, skore...
            new SettingsVar();
            NastavObtiznost();
            SettingsVar.Walls = checkboxSettingsWalls.Checked;
            tmpDir = SettingsVar.Direction;

            //Vytvoří novou část hada
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            labelFoodCount0.Text = SettingsVar.FoodCount.ToString();
            labelScore0.Text = SettingsVar.Score.ToString();
            GenerateFood();
        }

        //Položí na hrací pole náhodný objekt
        private void GenerateFood()
        {
            int maxXPos = pbGameField.Size.Width / SettingsVar.Šířka;
            int maxYPos = pbGameField.Size.Height / SettingsVar.Výška;

            Random random = new Random();
            food = new Circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
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
                // je to až tady aby se nemohlo stát že se přeskočí tick ve kterym se zmáčkla nějaká šipka (ignorovala by se, což nechceme žeano)
                if (obtiznostnik > 0)
                {
                    if (tmpObt > 0)
                    {
                        tmpObt--;
                        return;
                    }
                    else
                    {
                        tmpObt = obtiznostnik;
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
                        new Rectangle(Snake[i].X * SettingsVar.Šířka,
                                      Snake[i].Y * SettingsVar.Výška,
                                      SettingsVar.Šířka, SettingsVar.Výška));
                }

                //Nakreslí jídlo
                canvas.FillEllipse(Brushes.ForestGreen,
                    new Rectangle(food.X * SettingsVar.Šířka,
                         food.Y * SettingsVar.Výška, SettingsVar.Šířka, SettingsVar.Výška));

            }
        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Pohyb hlavy
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


                    //Dostat maximum X and Y Pos
                    int maxXPos = pbGameField.Size.Width / SettingsVar.Šířka;
                    int maxYPos = pbGameField.Size.Height / SettingsVar.Výška;

                    //Detekuje kolize s okrajema. když nejsou zdi tak teleportuje na druhou stranu
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        if (SettingsVar.Walls)
                        {
                            EndGame();
                        }
                        else
                        {
                            if (Snake[i].X < 0)
                            {
                                Snake[i].X = maxXPos - 1;
                            }
                            else if (Snake[i].Y < 0)
                            {
                                Snake[i].Y = maxYPos - 1;
                            }
                            else if (Snake[i].X >= maxXPos)
                            {
                                Snake[i].X = 0;
                            }
                            else if (Snake[i].Y >= maxYPos)
                            {
                                Snake[i].Y = 0;
                            }
                        }
                    }

                    //Detekuje kolize s tělem
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            EndGame();
                        }
                    }

                    //Detekuje kolize s jídlem
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood();
                    }

                }
                else
                {
                    //Pohyb těla
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
            //Přidá kruh k tělu
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(circle);

            //Updatuje Score
            int tmpScore = 0;
            switch (SettingsVar.Obtiznost)
            {
                case DifficultyEnum.Easy:
                    tmpScore += SettingsVar.BodyEasy;
                    break;
                case DifficultyEnum.Medium:
                    tmpScore += SettingsVar.BodyMed;
                    break;
                case DifficultyEnum.Hard:
                    tmpScore += SettingsVar.BodyHard;
                    break;
            }
            if (SettingsVar.Walls)
            {
                tmpScore *= SettingsConst.Num_WallsMultiplier;
            }
            SettingsVar.Score += tmpScore;

            labelScore0.Text = SettingsVar.Score.ToString();

            GenerateFood();

            //Updatuje Score
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
