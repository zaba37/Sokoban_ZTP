using Sokoban.Factory;
using Sokoban.GameMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.MapParts
{
    public class Hero : Part
    {

        public Image graphics;

        public int posX;
        public int posY;
        private int numberSteps;
        private FactoryMapPart Factory;
        public Hero(int height, int width, int startPosX, int startPosY)
        {
            this.posX = startPosX;
            this.posY = startPosY;
            this.graphics = Image.FromFile(@"Map\heroDown.png");
            picturebox = new PictureBox();
            picturebox.Height = height;
            picturebox.Width = width;
            point = new Point(this.posX, this.posY);
            picturebox.Image = this.graphics;
            picturebox.Location = point;
            numberSteps = 0;
            Factory = new FactoryMapPart();
        }

        override public void setPosition(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            point.X = posX;
            point.Y = posY;
            picturebox.Location = point;

        }

        public int getNumberSteps()
        {
            return numberSteps;
        }

        public void incrementNumberSteps()
        {
            numberSteps++;
        }
        public void goUp(Map map, Control.ControlCollection Controls)
        {
            int[] heroPosition = map.findHeroPosition();
            Part help;
            Part help2;
            Part toRemove;

            if (map.getPart(heroPosition[0] - 1, heroPosition[1]).GetType() == typeof(Wall)) //gdy na prawo bedzie sciana
            {
                return;
            }

            if (map.getPart(heroPosition[0] - 1, heroPosition[1]).GetType() == typeof(Floor)) //gdy na prawo bedzie podloga
            {
                help = map.getPart(heroPosition[0] - 1, heroPosition[1]);
                map.setPart(map.getPart(heroPosition[0], heroPosition[1]), heroPosition[0] - 1, heroPosition[1]);
                map.setPart(help, heroPosition[0], heroPosition[1]);
                map.getPart(heroPosition[0] - 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] - 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] - 1, heroPosition[1]).getY() - 64);
                map.getPart(heroPosition[0], heroPosition[1]).setPosition(map.getPart(heroPosition[0], heroPosition[1]).getX(), map.getPart(heroPosition[0], heroPosition[1]).getY() + 64);

                incrementNumberSteps();
              
            }


            if (map.getPart(heroPosition[0] - 1, heroPosition[1]).GetType() == typeof(Box)) //gdy na prawo bedzie skrzynka
            {
                if (map.getPart(heroPosition[0] - 2, heroPosition[1]).GetType() == typeof(Floor) || map.getPart(heroPosition[0] - 2, heroPosition[1]).GetType() == typeof(BoxPoint)) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                {


                    help = map.getPart(heroPosition[0], heroPosition[1]);
                    map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                    Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                    help2 = map.getPart(heroPosition[0] - 1, heroPosition[1]);// = 5;                   
                    map.setPart(help, heroPosition[0] - 1, heroPosition[1]);
                    toRemove = map.getPart(heroPosition[0] - 2, heroPosition[1]);
                    map.setPart(help2, heroPosition[0] - 2, heroPosition[1]);
                    map.getPart(heroPosition[0] - 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] - 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] - 1, heroPosition[1]).getY()-64);
                    map.getPart(heroPosition[0] - 2, heroPosition[1]).setPosition(map.getPart(heroPosition[0] - 2, heroPosition[1]).getX(), map.getPart(heroPosition[0] - 2, heroPosition[1]).getY()-64);
                    Controls.Remove(toRemove.picturebox);

                    incrementNumberSteps();


                
                }
                else
                {
                 
                }
            }

            if (map.getPart(heroPosition[0] - 1, heroPosition[1]).GetType() == typeof(BoxPoint)) //gdy na prawo bedzie punkt
            {

                help = map.getPart(heroPosition[0], heroPosition[1]);
                map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                toRemove = map.getPart(heroPosition[0] - 1, heroPosition[1]);
                map.setPart(help, heroPosition[0] - 1, heroPosition[1]);
                map.getPart(heroPosition[0] - 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] - 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] - 1, heroPosition[1]).getY() - 64);
                Controls.Remove(toRemove.picturebox);

                incrementNumberSteps();

               
            }
            addBoxPoints(map, Controls);
        }

        public void goDown(Map map, Control.ControlCollection Controls)
        {
            int[] heroPosition = map.findHeroPosition();
            Part help;
            Part help2;
            Part toRemove;

            if (map.getPart(heroPosition[0] + 1, heroPosition[1]).GetType() == typeof(Wall)) //gdy na prawo bedzie sciana
            {
                return;
            }

            if (map.getPart(heroPosition[0] + 1, heroPosition[1]).GetType() == typeof(Floor)) //gdy na prawo bedzie podloga
            {
                help = map.getPart(heroPosition[0] + 1, heroPosition[1]);
                map.setPart(map.getPart(heroPosition[0], heroPosition[1]), heroPosition[0] + 1, heroPosition[1]);
                map.setPart(help, heroPosition[0], heroPosition[1]);
                map.getPart(heroPosition[0] + 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] + 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] + 1, heroPosition[1]).getY() + 64);
                map.getPart(heroPosition[0], heroPosition[1]).setPosition(map.getPart(heroPosition[0], heroPosition[1]).getX(), map.getPart(heroPosition[0], heroPosition[1]).getY() - 64);
                incrementNumberSteps();

               
            }


            if (map.getPart(heroPosition[0] + 1, heroPosition[1]).GetType() == typeof(Box)) //gdy na prawo bedzie skrzynka
            {
                if (map.getPart(heroPosition[0] + 2, heroPosition[1]).GetType() == typeof(Floor) || map.getPart(heroPosition[0] + 2, heroPosition[1]).GetType() == typeof(BoxPoint)) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                {


                    help = map.getPart(heroPosition[0], heroPosition[1]);
                    map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                    Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                    help2 = map.getPart(heroPosition[0] + 1, heroPosition[1]);// = 5;                   
                    map.setPart(help, heroPosition[0] + 1, heroPosition[1]);
                    toRemove = map.getPart(heroPosition[0] + 2, heroPosition[1]);
                    map.setPart(help2, heroPosition[0] + 2, heroPosition[1]);
                    map.getPart(heroPosition[0] + 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] + 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] + 1, heroPosition[1]).getY()+64);
                    map.getPart(heroPosition[0] + 2, heroPosition[1]).setPosition(map.getPart(heroPosition[0] + 2, heroPosition[1]).getX(), map.getPart(heroPosition[0] + 2, heroPosition[1]).getY()+64);
                    Controls.Remove(toRemove.picturebox);

                    incrementNumberSteps();


                    
                }
                else
                {
                  
                }
            }

            if (map.getPart(heroPosition[0] + 1, heroPosition[1]).GetType() == typeof(BoxPoint)) //gdy na prawo bedzie punkt
            {

                help = map.getPart(heroPosition[0], heroPosition[1]);
                map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                toRemove = map.getPart(heroPosition[0] + 1, heroPosition[1]);
                map.setPart(help, heroPosition[0] + 1, heroPosition[1]);
                map.getPart(heroPosition[0] + 1, heroPosition[1]).setPosition(map.getPart(heroPosition[0] + 1, heroPosition[1]).getX(), map.getPart(heroPosition[0] + 1, heroPosition[1]).getY() + 64);
                Controls.Remove(toRemove.picturebox);

                incrementNumberSteps();

               
            }
            addBoxPoints(map, Controls);
        }


        public void goRight(Map map, Control.ControlCollection Controls)
        {
            int[] heroPosition = map.findHeroPosition();
            Part help;
            Part help2;
            Part toRemove;

            if (map.getPart(heroPosition[0], heroPosition[1] + 1).GetType() == typeof(Wall)) //gdy na prawo bedzie sciana
            {
                return;
            }

            if (map.getPart(heroPosition[0], heroPosition[1] + 1).GetType() == typeof(Floor)) //gdy na prawo bedzie podloga
            {
                help = map.getPart(heroPosition[0], heroPosition[1] + 1);
                map.setPart(map.getPart(heroPosition[0], heroPosition[1]), heroPosition[0], heroPosition[1] + 1);
                map.setPart(help, heroPosition[0], heroPosition[1]);
                map.getPart(heroPosition[0], heroPosition[1] + 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] + 1).getX() + 64, map.getPart(heroPosition[0], heroPosition[1] + 1).getY());
                map.getPart(heroPosition[0], heroPosition[1]).setPosition(map.getPart(heroPosition[0], heroPosition[1]).getX() - 64, map.getPart(heroPosition[0], heroPosition[1]).getY());
                incrementNumberSteps();

          
            }


            if (map.getPart(heroPosition[0], heroPosition[1] + 1).GetType() == typeof(Box)) //gdy na prawo bedzie skrzynka
            {
                if (map.getPart(heroPosition[0], heroPosition[1] + 2).GetType() == typeof(Floor) || map.getPart(heroPosition[0], heroPosition[1] + 2).GetType() == typeof(BoxPoint)) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                {


                    help = map.getPart(heroPosition[0], heroPosition[1]);
                    map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                    Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                    help2 = map.getPart(heroPosition[0], heroPosition[1] + 1);// = 5;                   
                    map.setPart(help, heroPosition[0], heroPosition[1] + 1);
                    toRemove = map.getPart(heroPosition[0], heroPosition[1] + 2);
                    map.setPart(help2, heroPosition[0], heroPosition[1] + 2);
                    map.getPart(heroPosition[0], heroPosition[1] + 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] + 1).getX() + 64, map.getPart(heroPosition[0], heroPosition[1] + 1).getY());
                    map.getPart(heroPosition[0], heroPosition[1] + 2).setPosition(map.getPart(heroPosition[0], heroPosition[1] + 2).getX() + 64, map.getPart(heroPosition[0], heroPosition[1] + 2).getY());
                    Controls.Remove(toRemove.picturebox);

                    incrementNumberSteps();


                
                }
                else
                {
                
                }
            }

            if (map.getPart(heroPosition[0], heroPosition[1] + 1).GetType() == typeof(BoxPoint)) //gdy na prawo bedzie punkt
            {

                help = map.getPart(heroPosition[0], heroPosition[1]);
                map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                toRemove = map.getPart(heroPosition[0], heroPosition[1] + 1);
                map.setPart(help, heroPosition[0], heroPosition[1] + 1);
                map.getPart(heroPosition[0], heroPosition[1] + 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] + 1).getX() + 64, map.getPart(heroPosition[0], heroPosition[1] + 1).getY());
                Controls.Remove(toRemove.picturebox);

                incrementNumberSteps();

               
            }
            addBoxPoints(map, Controls);
        }

        public void goLeft(Map map, Control.ControlCollection Controls)
        {
            int[] heroPosition = map.findHeroPosition();
            Part help;
            Part help2;
            Part toRemove;

            if (map.getPart(heroPosition[0], heroPosition[1] - 1).GetType() == typeof(Wall)) //gdy na prawo bedzie sciana
            {
                return;
            }

            if (map.getPart(heroPosition[0], heroPosition[1] - 1).GetType() == typeof(Floor)) //gdy na prawo bedzie podloga
            {
                help = map.getPart(heroPosition[0], heroPosition[1] - 1);
                map.setPart(map.getPart(heroPosition[0], heroPosition[1]), heroPosition[0], heroPosition[1] - 1);
                map.setPart(help, heroPosition[0], heroPosition[1]);
                map.getPart(heroPosition[0], heroPosition[1] - 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] - 1).getX() - 64, map.getPart(heroPosition[0], heroPosition[1] - 1).getY());
                map.getPart(heroPosition[0], heroPosition[1]).setPosition(map.getPart(heroPosition[0], heroPosition[1]).getX() + 64, map.getPart(heroPosition[0], heroPosition[1]).getY());
                incrementNumberSteps();

               
            }


            if (map.getPart(heroPosition[0], heroPosition[1] - 1).GetType() == typeof(Box)) //gdy na prawo bedzie skrzynka
            {
                if (map.getPart(heroPosition[0], heroPosition[1] - 2).GetType() == typeof(Floor) || map.getPart(heroPosition[0], heroPosition[1] - 2).GetType() == typeof(BoxPoint)) //sprawdz czy mozna przesunac skrzynke(podloga lub punkt)
                {


                    help = map.getPart(heroPosition[0], heroPosition[1]);
                    map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                    Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                    help2 = map.getPart(heroPosition[0], heroPosition[1] - 1);// = 5;                   
                    map.setPart(help, heroPosition[0], heroPosition[1] - 1);
                    toRemove = map.getPart(heroPosition[0], heroPosition[1] - 2);
                    map.setPart(help2, heroPosition[0], heroPosition[1] - 2);
                    map.getPart(heroPosition[0], heroPosition[1] - 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] - 1).getX() - 64, map.getPart(heroPosition[0], heroPosition[1] - 1).getY());
                    map.getPart(heroPosition[0], heroPosition[1] - 2).setPosition(map.getPart(heroPosition[0], heroPosition[1] - 2).getX() - 64, map.getPart(heroPosition[0], heroPosition[1] - 2).getY());
                    Controls.Remove(toRemove.picturebox);

                    incrementNumberSteps();


                   
                }
                else
                {
                  
                }
            }

            if (map.getPart(heroPosition[0], heroPosition[1] - 1).GetType() == typeof(BoxPoint)) //gdy na prawo bedzie punkt
            {

                help = map.getPart(heroPosition[0], heroPosition[1]);
                map.setPart(Factory.produceFloor(heroPosition[1] * 64, heroPosition[0] * 64, map.getStyle()), heroPosition[0], heroPosition[1]);
                Controls.Add(map.getPart(heroPosition[0], heroPosition[1]).picturebox);
                toRemove = map.getPart(heroPosition[0], heroPosition[1] - 1);
                map.setPart(help, heroPosition[0], heroPosition[1] - 1);
                map.getPart(heroPosition[0], heroPosition[1] - 1).setPosition(map.getPart(heroPosition[0], heroPosition[1] - 1).getX() - 64, map.getPart(heroPosition[0], heroPosition[1] - 1).getY());
                Controls.Remove(toRemove.picturebox);

                incrementNumberSteps();

                
            }
            addBoxPoints(map, Controls);
        }


        //metoda do uzupelnienia brakujacych BoxPointow
        public void addBoxPoints(Map map, Control.ControlCollection Controls)
        {
         foreach (Point p in map.getPointList())
            {
                if (map.getPart(p.X,p.Y).GetType() == typeof(Floor))
                {
 
                    int x = map.getPart(p.X, p.Y).getX();
                    int y = map.getPart(p.X, p.Y).getY();
                    Part toRemove = map.getPart(p.X, p.Y);

                    map.setPart(Factory.produceBoxPoint(x,y,map.getStyle()), p.X,p.Y);
                    Controls.Add(map.getPart(p.X,p.Y).picturebox);
                    Controls.Remove(toRemove.picturebox);
                }
            }
        }
    
    }
}

