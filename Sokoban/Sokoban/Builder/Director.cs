using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.GameMap;
using System.Drawing;
using System.IO;
using Sokoban.MapParts;

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
            List<List<int>> readNumbers = readFile("sokoban_" + lvl + ".txt");
            int posX = 0;
            int posY = 0;
            List<Point> pointsList = findPositionPoints(readNumbers);
            mapBuilder.setPointList(pointsList);

            for (int i = 0; i < readNumbers.Count(); i++)
            {
                int lineElementCounter = 0;

                for (int j = 0; j < readNumbers[i].Count(); j++)
                {
             
                    if (readNumbers[i][j] == 5)
                    {
                        //tutaj powinno zbudowac bohatera ale nie mam na niego koncepcji wiec puki co wstawiam skrzynke
                        //  Hero newHero = new Hero(heightElement, widthElement, posX, posY);
                       // initList.Add(factory.produceBox(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildHero(posX, posY);
                    }


                    if (readNumbers[i][j] == 6)
                    {
                        //initList.Add(factory.produceBox(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildBox(posX, posY);
                    }


                    if (readNumbers[i][j] == 1)
                    {
                       // initList.Add(factory.produceEmpty(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildEmpty(posX, posY);
                    }


                    if (readNumbers[i][j] == 2)
                    {
                        //initList.Add(factory.produceWall(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildWall(posX, posY);
                    }


                    if (readNumbers[i][j] == 4)
                    {
                        //initList.Add(factory.produceBoxPoint(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildBoxPoint(posX, posY);
                    }


                    if (readNumbers[i][j] == 3)
                    {
                       // initList.Add(factory.produceFloor(posX, posY, "retro"));
                        lineElementCounter++;
                        mapBuilder.buildFloor(posX, posY);
                    }

                    posX = posX + 64;

                }
                posY = posY + 64;
                posX = posX - (64 * lineElementCounter);

                mapBuilder.addPartListToMap();
            }
        }

        private List<List<int>> readFile(string path)
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

        private List<Point> findPositionPoints(List<List<int>> map)
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
    }
}
