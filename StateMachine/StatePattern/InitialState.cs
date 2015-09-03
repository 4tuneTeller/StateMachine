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
        System.Windows.RoutedEventHandler stateChangeEventHandler;

        // Этот конструкто получает состояние, из которого осуществляется переход и вызывает второй конструктор, в который передает свойства этого состояния. 
        public InitialState (State state) :this(state.SM)
        { }

        public InitialState (WindowStateMachine stateMachine)
        {
            stateChangeEventHandler = (a, b) => GoToState(new SecondButtonActiveState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            window.Source = new Uri("Home.xaml", UriKind.Relative);
            window.ContentRendered += Window_ContentRendered;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            window.ContentRendered -= Window_ContentRendered;
            Home homePage = (Home)window.Content;
            homePage.rightButton.IsEnabled = false;
            homePage.leftButton.Click += stateChangeEventHandler;
        }

        protected override void OnExit()
        {
            ((Home)window.Content).leftButton.Click -= stateChangeEventHandler;
        }
    }
}
