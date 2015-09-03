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
        // машина состояний, которая будет использовать наши состояния
        protected WindowStateMachine sm;
        protected MainWindow window;

        public WindowStateMachine SM
        {
            get { return sm; }
            set { sm = value; }
        }

        protected virtual void OnInit(WindowStateMachine stateMachine)
        {
            sm = stateMachine;
            window = stateMachine.Window;
            OnEnter();
        }

        protected abstract void OnEnter();
        // метод перехода в следующее состояние, который мы будем определять в наших конкретных состояниях
        protected abstract void GoToNextState();
    }
}
