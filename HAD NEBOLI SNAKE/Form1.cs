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
        private bool praveZapnuto = true;
        // počet ticků které se při pohybování hadem přeskakujou, tim se snižuje jeho rychlost
        // obtiznostnik = 0... přeskočí se 0 ticků, rychlost je maximální
        private int obtiznostnik;
        private int tmpObt;
        private Direction tmpSmer = Direction.Down;

        public Form1()
        {
            InitializeComponent();


            //Nastaví nastavení na defaultní (jenom pro rychlost :()
            new Settings();

            //Nastaví hrací rychlost a game timer
            hracicas.Interval = 1000 / Settings.Rychlost;
            hracicas.Tick += UpdateScreen;
            hracicas.Start();


            //neZapne novou hru
            //StartGame();

            // počká než zmáčkneš entr protože to je normální
            lblGameOver.Text = "ČUS PÍČUS ZANDEJ ENTR PRO HRANÍ";

        }
        private void NastavObtiznost()
        {
            if (radioButtonSettingsHard.Checked)
            {
                obtiznostnik = 1;
                Settings.Obtiznost = Difficulty.Hard;
            }
            else if (radioButtonSettingsMed.Checked)
            {
                obtiznostnik = 2;
                Settings.Obtiznost = Difficulty.Medium;
            }
            else if (radioButtonSettingsEasy.Checked)
            {
                obtiznostnik = 4;
                Settings.Obtiznost = Difficulty.Easy;
            }
        }

        private void SkryjVeci()
        {
            lblGameOver.Visible = false;
            panelSettings.Enabled = false; // nebo Visible
        }

        private void UkazVeci()
        {
            lblGameOver.Visible = true;
            panelSettings.Enabled = true;
        }

        private void StartGame()
        {
            SkryjVeci();

            //Nastaví nastavení na defaultní - smer pohledu, skore...
            new Settings();
            NastavObtiznost();
            Settings.Zdi = checkBoxSettingsZdi.Checked;

            //Vytvoří novou část hada
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);


            labelScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        //Položí na hrací pole náhodný objekt
        private void GenerateFood()
        {
            int maxXPos = pbHracipole.Size.Width / Settings.Šířka;
            int maxYPos = pbHracipole.Size.Height / Settings.Výška;

            Random random = new Random();
            food = new Circle { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) };
        }

        private void UpdateScreen(object sender, EventArgs e)
        {


            //Zkontroluje jestli je game over
            if (Settings.KonecHry || praveZapnuto)
            {
                //Zkontroluje jestli je enter nebo mezerník stlačen
                if (Input.KeyPressed(Keys.Enter) || Input.KeyPressed(Keys.Space))
                {
                    if (praveZapnuto) praveZapnuto = !praveZapnuto;
                    StartGame();
                }
                //Zkontroluje jestli je escape stlačen
                if (Input.KeyPressed(Keys.Escape))
                {
                    Application.Exit();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Escape))
                {
                    Input.ChangeState(Keys.Escape, false); // aby se to rovnou cely nevyplo
                    Smrt();
                }
                if ((Input.KeyPressed(Keys.Right) || Input.KeyPressed(Keys.D)) && Settings.směr != Direction.Left)
                    tmpSmer = Direction.Right;
                else if ((Input.KeyPressed(Keys.Left) || Input.KeyPressed(Keys.A)) && Settings.směr != Direction.Right)
                    tmpSmer = Direction.Left;
                else if ((Input.KeyPressed(Keys.Up) || Input.KeyPressed(Keys.W)) && Settings.směr != Direction.Down)
                    tmpSmer = Direction.Up;
                else if ((Input.KeyPressed(Keys.Down) || Input.KeyPressed(Keys.S)) && Settings.směr != Direction.Up)
                    tmpSmer = Direction.Down;

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
                Settings.směr = tmpSmer;
                MovePlayer();
            }

            pbHracipole.Invalidate();

        }

        private void pbHraciPole_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (praveZapnuto) return;

            if (!Settings.KonecHry)
            {
                //Nakreslí hada
                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    // volba barvy
                    if (i == 0)
                        snakeColour = Brushes.Black; // hlava je černá
                    else
                        snakeColour = Brushes.Green; // tělo zelený

                    // vybarví kolečko
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Šířka,
                                      Snake[i].Y * Settings.Výška,
                                      Settings.Šířka, Settings.Výška));
                }

                //Nakreslí jídlo
                canvas.FillEllipse(Brushes.Red,
                    new Rectangle(food.X * Settings.Šířka,
                         food.Y * Settings.Výška, Settings.Šířka, Settings.Výška));

            }
        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Move head
                if (i == 0)
                {
                    switch (Settings.směr)
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
                    int maxXPos = pbHracipole.Size.Width / Settings.Šířka;
                    int maxYPos = pbHracipole.Size.Height / Settings.Výška;

                    //Detekuje kolize s okrajema. když nejsou zdi tak teleportuje na druhou stranu
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        if (Settings.Zdi)
                        {
                            Smrt();
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
                            Smrt();
                        }
                    }

                    //Detekuje kolize s jídlem
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Sněz();
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
        private void Sněz()
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
            switch (Settings.Obtiznost)
            {
                case Difficulty.Easy:
                    tmpScore += Settings.BodyEasy;
                    break;
                case Difficulty.Medium:
                    tmpScore += Settings.BodyMed;
                    break;
                case Difficulty.Hard:
                    tmpScore += Settings.BodyHard;
                    break;
            }
            if (Settings.Zdi)
            {
                tmpScore *= 4;
            }
            Settings.Score += tmpScore;

            labelScore.Text = Settings.Score.ToString();

            GenerateFood();
        }

        private void Smrt()
        {
            Settings.KonecHry = true;

            string gameOver =   "KONEC HRY\n\n" +
                                "TVOJE FINÁLNÍ SKÓRE JE:\n" +
                                Settings.Score +
                                "\n\nSTISKNI ENTER PRO DALŠÍ POKUS";
            lblGameOver.Text = gameOver;

            UkazVeci();
        }

        private void labelControls2_Click(object sender, EventArgs e)
        {

        }
    }
}
