using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.MapParts;
using System.Drawing;

namespace Sokoban.GameMap
{
    public class Map
    {
        private List<List<Part>> map;
        private string style;
        private List<Point> pointList;
        public Map()
        {
            map = new List<List<Part>>();
        }

        public void AddPartList(List<Part> list)
        {
            map.Add(list);
        }


        public List<Point> getPointList()
        {
            return pointList;
        }
        public void setPointList(List<Point> list)
        {
            pointList = list;
        }
        public List<List<Part>> getMap()
        {
            return map;
        }

        public void setMap(List<List<Part>> newMap)
        {
            map = newMap;
        }

        public string getStyle()
        {
            return style;
        }

        public void setStyle(string _style)
        {
            style = _style;
        }
        public Part getPart(int x, int y)
        {
            return map[x][y];
        }

        public void setPart(Part elem, int x, int y)
        {
            map[x][y] = elem;
        }

        public int getSizeX()
        {
            return map.Count();
        }

        public int getSizeY(int x)
        {
            return map[x].Count();
        }


        public int[] findHeroPosition()
        {
            Type t = typeof(Hero);
            int[] position = new int[2];
            for (int i = 0; i < map.Count(); i++)
            {
                for (int j = 0; j < map[i].Count(); j++)
                {
                    if (map[i][j].GetType() == t)
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            return position;
        }


    }
}
