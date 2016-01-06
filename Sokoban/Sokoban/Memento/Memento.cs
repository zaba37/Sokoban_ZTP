using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Memento
{
    class Memento
    {
        private List<List<int>> state;

        public Memento(List<List<int>> state)
        {
            this.state = state;
        }

        public List<List<int>> getState()
        {
            return state;
        }
    }
}
