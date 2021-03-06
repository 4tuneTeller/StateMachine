﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    // начальное состояние второго экрана: текст Hi, поле ввода и активная кнопка
    class SecondScreenInitState : State
    {
        System.Windows.Controls.TextChangedEventHandler stateChangeEventHandler;

        public SecondScreenInitState(State state) :this(state.SM)
        { }

        public SecondScreenInitState(WindowStateMachine stateMachine)
        {
            stateChangeEventHandler = (a, b) => GoToState(new SecondScreenTextingState(this));
            OnInit(stateMachine);
        }

        protected override void OnEnter()
        {
            window.Source = new Uri("SecondScreen.xaml", UriKind.Relative);
            window.ContentRendered += Window_ContentRendered;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            window.ContentRendered -= Window_ContentRendered;
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.labelOne.Content = "Hi";
            secondScreen.textboxOne.TextChanged += stateChangeEventHandler;
        }

        protected override void OnExit()
        {
            SecondScreen secondScreen = (SecondScreen)window.Content;
            secondScreen.textboxOne.TextChanged -= stateChangeEventHandler;
        }
    }
}
