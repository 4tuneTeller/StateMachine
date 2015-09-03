using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    class SecondButtonActiveState : State
    {
        System.Windows.RoutedEventHandler stateChangeEventHandler;

        public SecondButtonActiveState (State state) :this(state.SM)
        { }

        public SecondButtonActiveState (WindowStateMachine stateMachine)
        {
            stateChangeEventHandler = (a, b) => GoToNextState(new SecondScreenInitState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.IsEnabled = true;
            homePage.rightButton.Click += stateChangeEventHandler;
        }

        //protected override void GoToNextState()
        //{
        //    OnExit();
        //    sm.CurrentState = new SecondScreenInitState();
        //}

        protected override void OnExit()
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.Click -= stateChangeEventHandler;
            homePage.rightButton.IsEnabled = false;
        }
    }
}
