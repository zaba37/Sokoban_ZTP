using System;
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

        public override  void buildMap(int lvl)
        {
            List<List<int>> readNumbers = readFile("sokoban_" + lvl + ".txt");
            int posX = 0;
            int posY = 0;
            List<Point> PointsList = findPositionPoints(readNumbers);
            map.setPointList(PointsList);
            for (int i = 0; i < readNumbers.Count(); i++)
            {

                List<Part> initList = new List<Part>();

                for (int j = 0; j < readNumbers[i].Count(); j++)
                {

                    if (readNumbers[i][j] == 5)
                    {
                        //tutaj powinno zbudowac bohatera ale nie mam na niego koncepcji wiec puki co wstawiam skrzynke
                         // Hero newHero = new Hero(64, 64, posX, posY);
                        //initList.Add(factory.produceBox(posX, posY, "retro"));
                        initList.Add(new Hero(64, 64, 64, 64));
                    }


                    if (readNumbers[i][j] == 6)
                    {
                        initList.Add(factory.produceBox(posX, posY, "retro"));
                    }


                    if (readNumbers[i][j] == 1)
                    {
                        initList.Add(factory.produceEmpty());

                    }


                    if (readNumbers[i][j] == 2)
                    {
                        initList.Add(factory.produceWall(posX, posY, "retro"));
                    }


                    if (readNumbers[i][j] == 4)
                    {
                        initList.Add(factory.produceBoxPoint(posX, posY, "retro"));
                    }


                    if (readNumbers[i][j] == 3)
                    {
                        initList.Add(factory.produceFloor(posX, posY, "retro"));
                    }

                    posX = posX + 64;

                }
                posY = posY + 64;
                posX = posX - (64 * initList.Count());

                map.AddPartList(initList);
            }
        }
    }
}
