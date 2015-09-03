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

        // метод инициализации состояния
        protected void OnInit(WindowStateMachine stateMachine)
        {
            sm = stateMachine;
            window = stateMachine.Window;
            OnEnter();
        }

        // метод входа в состояние, вызывается автоматически сразу после инициализации и переопределяется в конкретных методах
        protected abstract void OnEnter();

        // метод выхода из состояния, вызывается автоматически перед переходом в другое состояние и переопределяется в конкретных методах
        protected abstract void OnExit();

        // метод перехода в следующее состояние
        protected void GoToState(State newState)
        {
            OnExit();
            sm.CurrentState = newState;
        }
    }
}
