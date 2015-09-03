using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // состояние второго экрана, после ввода текста "hello" в текстовое поле
    class SecondScreenThanksState : State
    {
        System.Windows.RoutedEventHandler stateChangeEventHandler;

        public SecondScreenThanksState(State state) :this(state.SM)
        { }

        public SecondScreenThanksState(WindowStateMachine stateMachine)
        {
            stateChangeEventHandler = (a, b) => GoToNextState(new InitialState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.labelOne.Content = "Thank you";
            secondScreen.buttonThree.IsEnabled = true;
            secondScreen.buttonThree.Click += stateChangeEventHandler;
        }

        protected override void OnExit()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.labelOne.Content = "";
            secondScreen.buttonThree.Click -= stateChangeEventHandler;
        }
    }
}
