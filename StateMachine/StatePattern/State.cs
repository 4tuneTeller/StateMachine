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

        //protected System.Windows.RoutedEventHandler stateChangeEventHandler;
        //protected Eve stateChangeEventHandler;

        public WindowStateMachine SM
        {
            get { return sm; }
            set { sm = value; }
        }

        protected void OnInit(WindowStateMachine stateMachine)
        {
            sm = stateMachine;
            window = stateMachine.Window;
            //stateChangeEventHandler = (a, b) => GoToNextState();
            OnEnter();
        }

        protected abstract void OnEnter();
        protected abstract void OnExit();
        // метод перехода в следующее состояние, который мы будем определять в наших конкретных состояниях
        protected void GoToNextState(dynamic newState)
        {
            OnExit();
            sm.CurrentState = newState;
        }
    }
}
