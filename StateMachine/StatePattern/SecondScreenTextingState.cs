using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // состояение второго экрана, при вводе в поле любого текста
    class SecondScreenTextingState : State
    {
        public SecondScreenTextingState(State state) :this(state.SM)
        { }

        public SecondScreenTextingState(WindowStateMachine stateMachine)
        {
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.buttonThree.IsEnabled = false;
            secondScreen.textboxOne.TextChanged += TextboxOne_TextChanged;
        }

        private void TextboxOne_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;
            if (textBox.Text == "hello") GoToState(new SecondScreenThanksState(this));
        }

        protected override void OnExit()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.buttonThree.IsEnabled = true;
            secondScreen.textboxOne.TextChanged -= TextboxOne_TextChanged;
        }
    }
}
