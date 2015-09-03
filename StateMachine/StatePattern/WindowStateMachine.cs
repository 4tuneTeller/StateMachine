using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // наша машина состояний
    public class WindowStateMachine
    {
        State currentState = null;
        MainWindow window = null;
        

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public MainWindow Window
        {
            get { return window; }
        }

        public WindowStateMachine(MainWindow Window)
        {
            window = Window;
            currentState = new InitialState(this);
        }
    }
}
