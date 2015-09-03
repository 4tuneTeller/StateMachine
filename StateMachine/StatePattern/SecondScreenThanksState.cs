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
        System.Windows.RoutedEventHandler stateChangeNextEventHandler;
        //System.Windows.Controls.TextChangedEventHandler stateChangePrevEventHandler;

        public SecondScreenThanksState(State state) :this(state.SM)
        { }

        public SecondScreenThanksState(WindowStateMachine stateMachine)
        {
            stateChangeNextEventHandler = (a, b) => GoToState(new InitialState(this));
            //stateChangePrevEventHandler = (a, b) => GoToState(new SecondScreenTextingState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.labelOne.Content = "Thank you";
            secondScreen.buttonThree.IsEnabled = true;
            secondScreen.buttonThree.Click += stateChangeNextEventHandler;
            // в задании этого явно не было указано, но я решил сделать переход в предыдущее состояние, если текст в поле изменился с "hello" на какой-либо другой:
            secondScreen.textboxOne.TextChanged += TextboxOne_TextChanged;
        }

        private void TextboxOne_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            if (textBox.Text != "hello") GoToState(new SecondScreenTextingState(this));
        }

        protected override void OnExit()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.labelOne.Content = "Hi";
            secondScreen.buttonThree.Click -= stateChangeNextEventHandler;
            secondScreen.textboxOne.TextChanged -= TextboxOne_TextChanged;
        }
    }
}
