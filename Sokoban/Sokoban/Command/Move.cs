using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Command
{
    public class Move
    {
        private Command mode;

        public void SetMode(Command command)
        {
            mode = command;
        }

        public void Command()
        {
            mode.Execute();
        }
    }
}
