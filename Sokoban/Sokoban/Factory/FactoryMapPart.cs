using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.MapParts;

namespace Sokoban.Factory
{
    class FactoryMapPart
    {
        public Part produceBox(int x, int y, String style)
        {
            return new Box(x, y, style);
        }

        public Part produceBoxPoint(int x, int y, String style)
        {
            return new BoxPoint(x, y, style);
        }

        public Part produceEmpty(int posX, int posY, String style)
        {
            return new Empty();
        }

        public Part produceFloor(int x, int y, String style)
        {
            return new Floor(x, y, style);
        }

        public Part produceWall(int x, int y, String style)
        {
            return new Wall(x, y, style);
        }

        public Part produceHero(int x, int y, String style)
        {
            return new Hero(x, y, style);
        }
    }
}
