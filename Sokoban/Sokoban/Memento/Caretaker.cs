using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Memento
{
    class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento state)
        {
            if(mementoList.Count() >= 3){
                mementoList.RemoveAt(0);
                mementoList.Add(state);
            }
            else
            {
                mementoList.Add(state);
            }      
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }
}
