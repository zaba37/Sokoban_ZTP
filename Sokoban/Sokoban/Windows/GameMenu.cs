﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban.Buttons;
using Sokoban.Sound;
using System.Media;

namespace Sokoban.Windows
{
    public partial class GameMenu : Form
    {
        GameRanking ranking;
        private CustomButton cbNewGame;
        private CustomButton cbRanking;
        private CustomButton cbExit;
        private Bitmap pngLogo;
        private PictureBox logo;
        SoundPlayer typewriter;

        public GameMenu()
        {
            //Enable full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            this.DoubleBuffered = true;

            InitializeComponent();

            logo = new PictureBox();
            pngLogo = new Bitmap(@"Drawable\logoMenu.png");
            logo.BackColor = Color.Transparent;
            logo.Image = pngLogo;
            logo.Width = pngLogo.Width;
            logo.Height = pngLogo.Height;
            logo.Location = new Point(250, 20);


            cbNewGame = new CustomButton(@"Buttons\MenuButtons\NewGameNormal.png", @"Buttons\MenuButtons\NewGamePress.png", @"Buttons\MenuButtons\NewGameFocus.png", 450, 350, "NewGameTag");
            cbRanking = new CustomButton(@"Buttons\MenuButtons\RankingNormal.png", @"Buttons\MenuButtons\RankingPress.png", @"Buttons\MenuButtons\RankingFocus.png", 480, 450, "RankingTag");
            cbExit = new CustomButton(@"Buttons\MenuButtons\ExitNormal.png", @"Buttons\MenuButtons\ExitPress.png", @"Buttons\MenuButtons\ExitFocus.png", 540, 550, "ExitTag");

            this.Controls.Add(logo);
            this.Controls.Add(cbNewGame);
            this.Controls.Add(cbRanking);
            this.Controls.Add(cbExit);
            this.BackgroundImage = new Bitmap(@"Drawable\Wall_Beige.png");

            cbNewGame.MouseClick += new MouseEventHandler(mouseClick);
            cbRanking.MouseClick += new MouseEventHandler(mouseClick);
            cbExit.MouseClick += new MouseEventHandler(mouseClick);
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (((CustomButton)sender).Tag.ToString())
                {
                    case "RankingTag":
                        if (ranking == null)
                        {
                            ranking = new GameRanking();
                            ranking.Tag = this;
                        }
                        ranking.Show(this);
                        this.Hide();
                        break;

                    case "ExitTag":
                        Application.Exit();
                        break;

                    case "NewGameTag":
                        Game newGame = new Game();
                        newGame.Tag = this;
                        newGame.Show(this);
                        this.Hide();
                        break;
                }
            }
        }
    }
}
