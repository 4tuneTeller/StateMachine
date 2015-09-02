using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    class SecondButtonActiveState : State
    {
        public SecondButtonActiveState (StateMachine stateMachine)
        {
            sm = stateMachine;
        }

        public override void GoToNextState()
        {
            throw new NotImplementedException();
        }
    }
}
