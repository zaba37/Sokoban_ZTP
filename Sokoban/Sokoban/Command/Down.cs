using Sokoban.GameMap;
using Sokoban.MapParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.Command
{
    public class Down : Command
    {
        private Hero hero;
        private Map map;
        private Control.ControlCollection controls;
        public Down(Hero hero, Map map, Control.ControlCollection controls)
        {
            this.hero = hero;
            this.map = map;
            this.controls = controls;
        }

        public void Execute()
        {
            hero.goDown(map, controls);
        }
    }
}
