using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Flyweight.Singleton
{
    class GraphicManager
    {
        private static GraphicManager instance = null;
        private Dictionary<string, Image> graphicsLibrary;       
        private GraphicManager()
        {
            graphicsLibrary = new Dictionary<string, Image>();

        }
        public static GraphicManager GetInstance()
        {
            if (instance == null)
                instance = new GraphicManager();
            return instance;
        }
        public Image GetTexture(string name)
        {
            if (graphicsLibrary.ContainsKey(name))
            {
                return graphicsLibrary[name];
            }
            else
            {                           
                    try
                    {
                        Image temp = Image.FromFile(name);                        
                        if (temp != null)
                        {
                            graphicsLibrary.Add(name, temp);
                            return temp;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                
            }
        }
    
    }
}
