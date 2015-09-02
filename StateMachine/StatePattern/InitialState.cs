using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.StatePattern
{
    class InitialState : State
    {
        // начальное состояние: первый экран, кнопка №1 активна, кнопка №2 - нет
        public InitialState (StateMachine stateMachine)
        {
            sm = stateMachine;
        }

        public override void GoToNextState()
        {

        }
    }
}
