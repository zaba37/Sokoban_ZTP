﻿using Sokoban.Flyweight.Singleton;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.MapParts
{
    public class Floor : Part
    {
        public Image graphics;
        public int posX;
        public int posY;

        public Floor(int startPosX, int startPosY, String style)
        {
            this.posX = startPosX;
            this.posY = startPosY;

            //tutaj if sprawdzi jaki styl ma miec element i wstawi odpowiedni obrazek
            if (style.Contains("retro"))
            {
                this.graphics = GraphicManager.GetInstance().GetTexture(@"Map\FloorR.png");
            }
            else if (style.Contains("classic"))
            {
                this.graphics = GraphicManager.GetInstance().GetTexture(@"Map\Floor.png");
            }

            picturebox = new PictureBox();
            picturebox.Height = 64;
            picturebox.Width = 64;
            point = new Point(this.posX, this.posY);
            picturebox.Image = this.graphics;
            picturebox.Location = point;
            picturebox.BackColor = Color.Transparent;
        }

        override public void setPosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            point.X = posX;
            point.Y = posY;
            picturebox.Location = point;

        }
    }
}
