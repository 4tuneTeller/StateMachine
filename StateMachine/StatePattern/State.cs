using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // абстрактный класс состояний, от которого будем наследовать остальные состояния
    public abstract class State
    {
        // машина состояний, которая будет использовать наши состояния. В данном примере не используется, но если бы нам нужны были какие-то данные, общие для всех состояний, эти данные мы бы передовали через эту МС
        protected StateMachine sm; 

        public StateMachine SM
        {
            get { return sm; }
            set { sm = value; }
        }

        public abstract void GoToNextState();
    }
}
