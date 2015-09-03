using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // начальное состояние: первый экран, кнопка №1 активна, кнопка №2 - нет
    class InitialState : State
    {
        // Этот конструкто получает состояние, из которого осуществляется переход и вызывает второй конструктор, в который передает данные этого состояния. 
        // В данном случае это только машина состояний, которая использует эти состояния, но в дальнейшем таким образом состояния смогут обмениваться данными
        public InitialState (State state) :this(state.SM)
        { }

        public InitialState (WindowStateMachine stateMachine)
        {
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            window.Source = new Uri("Home.xaml", UriKind.Relative);
            window.ContentRendered += Window_ContentRendered;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Home homePage = (Home)window.Content;
            homePage.rightButton.IsEnabled = false;
            homePage.leftButton.Click += (a, b) => GoToNextState();
        }

        protected override void GoToNextState()
        {
            sm.CurrentState = new SecondButtonActiveState(this);
        }
    }
}
