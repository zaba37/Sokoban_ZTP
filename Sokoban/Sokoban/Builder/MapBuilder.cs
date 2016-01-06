using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.GameMap;
using System.IO;
using System.Drawing;
using Sokoban.MapParts;
using Sokoban.Factory;

namespace Sokoban.Builder
{
    abstract class MapBuilder
    {
        protected Map map;
        protected List<Part> singleMapElementLine;
        protected FactoryMapPart factory;

        public MapBuilder()  
        {
            map = new Map();
            factory = new FactoryMapPart();
            singleMapElementLine = new List<Part>();
        }

        public Map getMap()
        {
            return map;
        }

        public void addPartListToMap(){
            map.AddPartList(singleMapElementLine);
            singleMapElementLine = new List<Part>();
        }

        public void setPointList(List<Point> list)
        {
            map.setPointList(list);
        }

        abstract public void buildBox(int posX, int posY);
        abstract public void buildBoxPoint(int posX, int posY);
        abstract public void buildEmpty(int posX, int posY);
        abstract public void buildFloor(int posX, int posY);
        abstract public void buildWall(int posX, int posY);
        abstract public void buildHero(int posX, int posY);
    }
}
