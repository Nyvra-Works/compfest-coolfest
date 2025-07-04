using System;

namespace StateMachines.Player.States
{
    public abstract class AbstractState<Context, EState> where EState : Enum
    {
        public abstract void Enter(Context context);
        public abstract void UpdateExecute(Context context);
        public abstract void Exit(Context context);
    }
}