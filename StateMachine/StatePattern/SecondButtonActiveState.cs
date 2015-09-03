using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    class SecondButtonActiveState : State
    {
        public SecondButtonActiveState (State state) :this(state.SM)
        { }

        public SecondButtonActiveState (WindowStateMachine stateMachine)
        {
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.IsEnabled = true;
        }

        protected override void GoToNextState()
        {
            throw new NotImplementedException();
        }
    }
}
