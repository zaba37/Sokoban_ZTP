using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Memento
{
    class Originator
    {
        List<List<int>> state;

        public void setState(List<List<int>> state)
        {
            this.state = state;
        }

        public List<List<int>> getState()
        {
            return state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state);
        }

        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
        }

    }
}
