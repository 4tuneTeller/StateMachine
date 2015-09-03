using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // аткивируется вторая кнопка, по нажатию на которой произойдет переход в следующее состояние - на следующий экран
    class SecondButtonActiveState : State
    {
        System.Windows.RoutedEventHandler stateChangeEventHandler;

        public SecondButtonActiveState (State state) :this(state.SM)
        { }

        public SecondButtonActiveState (WindowStateMachine stateMachine)
        {
            stateChangeEventHandler = (a, b) => GoToState(new SecondScreenInitState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.IsEnabled = true;
            homePage.rightButton.Click += stateChangeEventHandler;
        }

        protected override void OnExit()
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.Click -= stateChangeEventHandler;
            homePage.rightButton.IsEnabled = false;
        }
    }
}
