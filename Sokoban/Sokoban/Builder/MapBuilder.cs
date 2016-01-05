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
        protected FactoryMapPart factory;

        public MapBuilder()
        {
            map = new Map();
            factory = new FactoryMapPart();
        }

        public Map getMap()
        {
            return map;
        }

        protected List<List<int>> readFile(string path)
        {
            List<List<int>> intMap = null;

            try
            {
                var lines = File.ReadAllLines(path);
                var map = lines.Select(l => l.Split(' ')).ToList();
                intMap = map.Select(l => l.Select(i => int.Parse(i)).ToList()).ToList();
                return intMap;
            }
            catch
            {
                Environment.Exit(0);
            }

            return intMap;
        }

        protected List<Point> findPositionPoints(List<List<int>> map)
        {
            List<Point> positionsList = new List<Point>();
            for (int i = 0; i < map.Count(); i++)
            {

                for (int j = 0; j < map[i].Count(); j++)
                {
                    if (map[i][j] == 4)
                    {
                        Point newPosition = new Point(i, j);
                        positionsList.Add(newPosition);
                    }
                }
            }
            return positionsList;
        }

        //na diagramie mamy metody ktore buduja sciane, podloge itp ale one sa tez w fabryce wiec nie wiem czy poztzebujemy duplikacji tego samego czy gotowej metody ktora zrobi mape
        abstract public void buildMap(int lvl);
    }
}
