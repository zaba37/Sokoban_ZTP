using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.MapParts;

namespace Sokoban.GameMap
{
    class Map
    {
        private List<List<Part>> map;

        public Map()
        {
            map = new List<List<Part>>();
        }

        public void AddPartList(List<Part> list){
            map.Add(list);
        }

        public List<List<Part>> getMap()
        {
            return map;
        }

        public void setMap(List<List<Part>> newMap)
        {
            map = newMap; 
        }
    }
}
