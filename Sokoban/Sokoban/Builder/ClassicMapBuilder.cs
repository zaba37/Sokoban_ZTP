using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.MapParts;

namespace Sokoban.Builder
{
    class ClassicMapBuilder : MapBuilder 
    {

        public override void buildBox(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceBox(posX, posY, "classic"));
        }

        public override void buildBoxPoint(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceBoxPoint(posX, posY, "classic"));
        }

        public override void buildEmpty(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceEmpty(posX, posY, "classic"));
        }

        public override void buildFloor(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceFloor(posX, posY, "classic"));
        }

        public override void buildWall(int posX, int posY)
        {
            singleMapElementLine.Add(factory.produceWall(posX, posY, "classic"));
        }
    }
}
