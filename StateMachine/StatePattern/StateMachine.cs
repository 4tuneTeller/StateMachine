using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // наша машина состояний
    public class StateMachine
    {
        State currentState = null;

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public StateMachine()
        {
            currentState = new InitialState(this);
        }
    }
}
