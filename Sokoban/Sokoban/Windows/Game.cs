using Sokoban.Builder;
using Sokoban.Buttons;
using Sokoban.Command;
using Sokoban.GameMap;
using Sokoban.MapParts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;
using Sokoban.Sound;
namespace Sokoban.Windows
{
    public partial class Game : Form
    {


       SoundPlayer typewriter = Player.getSoundPlayerInstance();
      //  Pause pauseWindow;

        private List<List<int>> readNumbers;
      


        private int mapNumber;
        private int numberOfMap;


        private int totalPoints;

        private int posX;
        private int posY;
       // List<PointPosition> PointsList;

        private int SetBoxes;
        private int numberSteps;
        private int numberShiftsBoxes;

        private int previousNumberSteps;
        private int previousnumberShiftsBoxes;

        private int widthElement;
        private int heightElement;
        private CustomButton cbArrowUp;
        private CustomButton cbArrowDown;
        private CustomButton cbArrowRight;
        private CustomButton cbArrowLeft;
        private System.Timers.Timer timer;
        private DateTime startTime;
        private String elapsedTime;
        private TimeSpan elapsedTimeDateTime;

        private PictureBox framePb;


        private DateTime pauseTime;
        private Label infoTimeLabel;
        private Point infoTimeLabelLocation;

        private Label infoStepsLabel;
        private Point infoStepsLabelLocation;

        private Label infoBoxesLabel;
        private Point infoBoxesLabelLocation;


        private Label TimeLabel;
        private Point TimeLabelLocation;

        private Label StepsLabel;
        private Point StepsLabelLocation;

        private Label BoxesLabel;
        private Point BoxesLabelLocation;


        private PictureBox[] startScreen;
        private CustomButton cbStart;

        Map newMap;
        Director newDirector;
        Move newMove; 
        

        public Game()
        {
            InitializeComponent();


            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.BackgroundImage = Image.FromFile(@"Map\Floor.png");
            this.DoubleBuffered = true;

            mapNumber = 1;

            numberOfMap = 9;  //ILOSC MAP


          //  PointsList = null;
            SetBoxes = 0;
            posX = 0;
            posY = 0;
            widthElement = 64;
            heightElement = 64;
            totalPoints = 0;

            typewriter.Stop();
            typewriter.SoundLocation = @"Music\step.wav";

            startScreen = new PictureBox[9];
            startScreen[0] = new PictureBox();
            startScreen[0].Image = new Bitmap(@"Drawable\L1.png");
            startScreen[1] = new PictureBox();
            startScreen[1].Image = new Bitmap(@"Drawable\L2.png");
            startScreen[2] = new PictureBox();
            startScreen[2].Image = new Bitmap(@"Drawable\L3.png");
            startScreen[3] = new PictureBox();
            startScreen[3].Image = new Bitmap(@"Drawable\L4.png");
            startScreen[4] = new PictureBox();
            startScreen[4].Image = new Bitmap(@"Drawable\L5.png");
            startScreen[5] = new PictureBox();
            startScreen[5].Image = new Bitmap(@"Drawable\L6.png");
            startScreen[6] = new PictureBox();
            startScreen[6].Image = new Bitmap(@"Drawable\L7.png");
            startScreen[7] = new PictureBox();
            startScreen[7].Image = new Bitmap(@"Drawable\L8.png");
            startScreen[8] = new PictureBox();
            startScreen[8].Image = new Bitmap(@"Drawable\L9.png");

            foreach (PictureBox start in startScreen)
            {
                start.Location = new Point(250, 150);
                start.Height = start.Image.Height;
                start.Width = start.Image.Width;
                start.BackColor = Color.Transparent;
            }

            cbStart = new CustomButton(@"Buttons\GameButtons\StartNormal.png", @"Buttons\GameButtons\StartPress.png", @"Buttons\GameButtons\StartFocus.png", 550, 380, "StartTag");
            cbStart.MouseClick += new MouseEventHandler(mouseClick);


            newDirector = new Director();
            newMove = new Move();
            RetroMapBuilder ret = new RetroMapBuilder();
            newDirector.setMapBuilder(ret);
            newDirector.constructMap(1);
            newMap = newDirector.getMap();          
            
            initMap(newMap);

        }

        private void initLabels()
        {

            framePb = new PictureBox();
            framePb.Location = new Point(960, 0);
            framePb.Image = new Bitmap(@"Map\frame.png");
            framePb.Height = framePb.Image.Height;
            framePb.Width = framePb.Image.Width;
            framePb.BackColor = Color.Transparent;

            infoTimeLabelLocation = new Point(1026, 70);
            infoTimeLabel = new Label();
            // infoTimeLabel.Width = 80;
            //infoTimeLabel.Height = 30;
            infoTimeLabel.AutoSize = true;
            infoTimeLabel.BackColor = Color.Red;
            infoTimeLabel.Font = new Font(Font.Name, 13);
            infoTimeLabel.Location = infoTimeLabelLocation;
            infoTimeLabel.BackColor = System.Drawing.Color.Transparent;
            // infoTimeLabel.Image = new Bitmap(@"Drawable\Wall_Gray.png");
            infoTimeLabel.Text = "Time: ";
            this.Controls.Add(infoTimeLabel);

            TimeLabelLocation = new Point(1086, 70);
            TimeLabel = new Label();
            TimeLabel.Width = 100;
            TimeLabel.Height = 30;
            TimeLabel.Font = new Font(Font.Name, 13);
            TimeLabel.Location = TimeLabelLocation;
            TimeLabel.BackColor = System.Drawing.Color.Transparent;
            TimeLabel.Text = "00:00";
            this.Controls.Add(TimeLabel);

            infoStepsLabelLocation = new Point(1026, 100);
            infoStepsLabel = new Label();
            // infoStepsLabel.Width = 175;
            // infoStepsLabel.Height = 30;
            infoStepsLabel.Font = new Font(Font.Name, 13);
            infoStepsLabel.Location = infoStepsLabelLocation;
            infoStepsLabel.BackColor = System.Drawing.Color.Transparent;
            infoStepsLabel.Text = "Number of steps: ";
            infoStepsLabel.AutoSize = true;
            this.Controls.Add(infoStepsLabel);

            StepsLabelLocation = new Point(1181, 100);
            StepsLabel = new Label();
            StepsLabel.Width = 60;
            StepsLabel.Height = 30;
            StepsLabel.Font = new Font(Font.Name, 13);
            StepsLabel.Location = StepsLabelLocation;
            StepsLabel.BackColor = System.Drawing.Color.Transparent;
            StepsLabel.Text = "0";
            this.Controls.Add(StepsLabel);


            infoBoxesLabelLocation = new Point(1026, 130);
            infoBoxesLabel = new Label();
            //infoBoxesLabel.Width = 175;
            //   infoBoxesLabel.Height = 30;
            infoBoxesLabel.Font = new Font(Font.Name, 13);
            infoBoxesLabel.Location = infoBoxesLabelLocation;
            infoBoxesLabel.BackColor = System.Drawing.Color.Transparent;
            infoBoxesLabel.Text = "Number of shifts boxes: ";
            infoBoxesLabel.AutoSize = true;
            this.Controls.Add(infoBoxesLabel);

            BoxesLabelLocation = new Point(1225, 130); //1136
            BoxesLabel = new Label();
            BoxesLabel.Width = 40;
            BoxesLabel.Height = 30;
            BoxesLabel.Font = new Font(Font.Name, 13);
            BoxesLabel.Location = BoxesLabelLocation;
            BoxesLabel.BackColor = System.Drawing.Color.Transparent;
            BoxesLabel.Text = "0";
            this.Controls.Add(BoxesLabel);
            this.Controls.Add(framePb);
        }



        private void initMap(Map map)
        {
            this.Controls.Add(cbStart);
            cbStart.Show();
            this.Controls.Add(startScreen[mapNumber - 1]);
            startScreen[mapNumber - 1].Show();
            initLabels();
            initButtons();
            previousnumberShiftsBoxes = 0;
            previousNumberSteps = 0;

            SetBoxes = 0;
            posX = 0;
            posY = 0;
            for (int i = 0; i < map.getSizeX();i++ )
            {

                for (int j = 0; j < map.getSizeY(i);j++ )
                {                   
                   this.Controls.Add(map.getPart(i, j).picturebox);
                }
                    
            }


            timer = new System.Timers.Timer(100);
            timer.Elapsed += (s, e) => UpdateTime(e);
            timer.AutoReset = true;
            timer.Start();
        }




        private int numberSetBoxes(List<List<Part>> map, List<Point> listPoints)
        {
            int number = 0;
            foreach (Point p in listPoints)
            {
                if (map[p.X][p.Y].GetType() == typeof(Box))
                    number++;
            }
            return number;
        }

        private bool CheckEndRound(int numberSetBox, List<Point> PointsPositionList)
        {
            bool endRound = false;
            if (numberSetBox == PointsPositionList.Count())
                endRound = true;

            return endRound;
        }



        private void UpdateTime(ElapsedEventArgs e)
        {
            try
            {
                elapsedTime = (DateTime.Now - startTime).ToString(@"mm\:ss");
                elapsedTimeDateTime = (DateTime.Now - startTime);
                // infoLabel.Text = elapsedTime;
                if (TimeLabel != null && elapsedTime != null)
                    TimeLabel.Text = elapsedTime;
            }

            catch
            {

            }
        }


        private void initButtons()
        {
            cbArrowUp = new CustomButton(@"Buttons\GameButtons\UpNormal.png", @"Buttons\GameButtons\UpPress.png", @"Buttons\GameButtons\UpFocus.png", 1200, 550, "UpTag");
            cbArrowDown = new CustomButton(@"Buttons\GameButtons\DownNormal.png", @"Buttons\GameButtons\DownPress.png", @"Buttons\GameButtons\DownFocus.png", 1200, 620, "DownTag");
            cbArrowRight = new CustomButton(@"Buttons\GameButtons\RightNormal.png", @"Buttons\GameButtons\RightPress.png", @"Buttons\GameButtons\RightFocus.png", 1270, 620, "RightTag");
            cbArrowLeft = new CustomButton(@"Buttons\GameButtons\LeftNormal.png", @"Buttons\GameButtons\LeftPress.png", @"Buttons\GameButtons\LeftFocus.png", 1130, 620, "LeftTag");

            this.Controls.Add(cbArrowUp);
            this.Controls.Add(cbArrowDown);
            this.Controls.Add(cbArrowRight);
            this.Controls.Add(cbArrowLeft);
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (((CustomButton)sender).Tag.ToString())
                {
                    case "StartTag":
                        timer.AutoReset = true;
                        startTime = DateTime.Now;
                        timer.Start();
                        startScreen[mapNumber - 1].Hide();
                        cbStart.Hide();
                        cbArrowUp.MouseClick += new MouseEventHandler(mouseClick);
                        cbArrowDown.MouseClick += new MouseEventHandler(mouseClick);
                        cbArrowRight.MouseClick += new MouseEventHandler(mouseClick);
                        cbArrowLeft.MouseClick += new MouseEventHandler(mouseClick);
                        break;
                }
            }  
        }



        private void endRound()
        {
            timer.Stop();
            mapNumber++;


            //  DateTime ElapsedTime = DateTime.Parse(elapsedTime);
            int totalSeconds = (elapsedTimeDateTime.Hours * 360) + (elapsedTimeDateTime.Minutes * 60) + elapsedTimeDateTime.Seconds;
            if (totalSeconds < 20)
                totalPoints = totalPoints + 100;
            if (totalSeconds >= 20 && totalSeconds <= 40)
                totalPoints = totalPoints + 50;
            if (totalSeconds > 40)
                totalPoints = totalPoints + 20;
            double pointsForSteps = ((double)numberSteps) * 0.1;

            totalPoints = totalPoints - (int)pointsForSteps;
            if (totalPoints < 0)
                totalPoints = 0;


            this.Controls.Clear();

            mapNumber++;
            if (mapNumber < 5)
            {
                RetroMapBuilder ret = new RetroMapBuilder();
                newDirector.setMapBuilder(ret);
                newDirector.constructMap(mapNumber);
                newMap = newDirector.getMap();
                newMap.setStyle("retro");
            }
            else
            {
                ClassicMapBuilder clas = new ClassicMapBuilder();
                newDirector.setMapBuilder(clas);
                newDirector.constructMap(mapNumber);
                newMap = newDirector.getMap();
                newMap.setStyle("classic");
            }

            initMap(newMap);
            

           //UZUPELNIC ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        private void pressEsc()
        {
            /*
            timer.Stop();
            pauseTime = DateTime.Now;

           // typewriter.Stop();
           // typewriter.SoundLocation = @"Music\pauseMusic.wav";
            //typewriter.PlayLooping();

            if (pauseWindow == null)
            {
                pauseWindow = new Pause();
                pauseWindow.Tag = Tag;
            }


            this.Hide();
            pauseWindow.ShowDialog();

            if (pauseWindow.flag == 1)
            {
                var difference = DateTime.Now - pauseTime;
                startTime = startTime.Add(difference);

                typewriter.Stop();
                typewriter.SoundLocation = @"Music\step.wav";

                timer.Start();
                this.Show();
            }

            if (pauseWindow.flag == 2)
            {
                this.Controls.Clear();

                typewriter.Stop();
                typewriter.SoundLocation = @"Music\step.wav";


                double pointsForSteps = ((double)numberSteps) * 0.1;
                totalPoints = totalPoints - (int)pointsForSteps;

                initMap("sokoban_" + mapNumber + ".txt");
                this.Show();
            }

            if (pauseWindow.flag == 3)
            {
                typewriter.Stop();
                typewriter.SoundLocation = @"Music\mainMusic.wav";
                typewriter.PlayLooping();
                this.Close();
            }
             */
        }


        private void endgame()
        {
            int[] heroPos = newMap.findHeroPosition();
            Hero hero = (Hero)newMap.getPart(heroPos[0], heroPos[1]);

            numberSteps = hero.getNumberSteps();
            timer.Stop();
            TimeSpan test = elapsedTimeDateTime;
            // DateTime ElapsedTime = DateTime.Parse(elapsedTime);
            int totalSeconds = (elapsedTimeDateTime.Hours * 360) + (elapsedTimeDateTime.Minutes * 60) + elapsedTimeDateTime.Seconds;
            if (totalSeconds < 20)
                totalPoints = totalPoints + 100;
            if (totalSeconds >= 20 && totalSeconds <= 40)
                totalPoints = totalPoints + 50;
            if (totalSeconds > 40)
                totalPoints = totalPoints + 20;
            double pointsForSteps = ((double)numberSteps) * 0.1;

            totalPoints = totalPoints - (int)pointsForSteps;
            if (totalPoints < 0)
                totalPoints = 0;

            typewriter.Stop();
            typewriter.SoundLocation = @"Music\mainMusic.wav";
            typewriter.PlayLooping();

            EndGame endGameWindow = new EndGame(totalPoints);
            endGameWindow.Tag = this.Tag;
            endGameWindow.Show();
            this.Close();
        }




        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38) //gora
            {
                int[] heroPos = newMap.findHeroPosition();
                Hero hero = (Hero)newMap.getPart(heroPos[0], heroPos[1]);
                Command.Up newUp = new Up(hero, newMap, this.Controls);
                newMove.SetMode(newUp);
                newMove.Command();
                typewriter.Play();
                if (CheckEndRound(numberSetBoxes(newMap.getMap(),newMap.getPointList()), newMap.getPointList()))
                {
                    if (mapNumber == numberOfMap)
                        endgame();
                    endRound();
                }
            }
            if (e.KeyValue == 40) //dol
            {
                int[] heroPos = newMap.findHeroPosition();
                Hero hero = (Hero)newMap.getPart(heroPos[0], heroPos[1]);
                Command.Down newDown = new Down(hero, newMap, this.Controls);
                newMove.SetMode(newDown);
                newMove.Command();
                typewriter.Play();
                if (CheckEndRound(numberSetBoxes(newMap.getMap(), newMap.getPointList()), newMap.getPointList()))
                {
                    if (mapNumber == numberOfMap)
                        endgame();
                    endRound();
                }
            }
            if (e.KeyValue == 39) //prawo
            {           
                int[] heroPos = newMap.findHeroPosition();
                Hero hero = (Hero)newMap.getPart(heroPos[0], heroPos[1]);
                Command.Right newRight = new Right(hero, newMap,this.Controls);
                newMove.SetMode(newRight);
                newMove.Command();
                typewriter.Play();
                if (CheckEndRound(numberSetBoxes(newMap.getMap(), newMap.getPointList()), newMap.getPointList()))
                {
                    if (mapNumber == numberOfMap)
                        endgame();
                    endRound();
                }
                
            }

            if (e.KeyValue == 37) //lewo
            {
                int[] heroPos = newMap.findHeroPosition();
                Hero hero = (Hero)newMap.getPart(heroPos[0], heroPos[1]);
                Command.Left newLeft = new Left(hero, newMap, this.Controls);
                newMove.SetMode(newLeft);
                newMove.Command();
                typewriter.Play();
                if (CheckEndRound(numberSetBoxes(newMap.getMap(), newMap.getPointList()), newMap.getPointList()))
                {
                    if (mapNumber == numberOfMap)
                        endgame();
                    endRound();
                }
            }

            if (e.KeyValue == 27) //escape
            {
               // pressEsc();
                  Environment.Exit(0);
            }

        }

    
    }
}
