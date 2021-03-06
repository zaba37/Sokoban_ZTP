﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.MapParts;
using Sokoban.Command;

namespace Sokoban.Builder
{
    class RetroMapBuilder : MapBuilder
    {
        public RetroMapBuilder()
        {
            map.setStyle("retro");
        }

        public override void buildBox(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceBox(posX, posY, "retro"));
        }

        public override void buildBoxPoint(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceBoxPoint(posX, posY, "retro"));
        }

        public override void buildEmpty(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceEmpty(posX, posY, "retro"));
        }

        public override void buildFloor(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceFloor(posX, posY, "retro"));
        }

        public override void buildWall(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceWall(posX, posY, "retro"));
        }

        public override void buildHero(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceHero(posX, posY, "retro"));
        }
    }
}
