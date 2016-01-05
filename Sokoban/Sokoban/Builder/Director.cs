using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.GameMap;

namespace Sokoban.Builder
{
    class Director
    {
        private MapBuilder mapBuilder;

        public void setMapBuilder(MapBuilder mb)
        {
            mapBuilder = mb;
        }

        public Map getMap()
        {
            return mapBuilder.getMap();
        }

        public void constructMap(int lvl)
        {
            mapBuilder.buildMap(lvl);
        }
    }
}
