namespace StateMachines.Enemy.States
{
    using UnityEngine;

    public abstract class BaseState
    {
        public abstract void Enter(MB_EnemyStateContext context);
        public abstract void UpdateExecute(MB_EnemyStateContext context);
        public abstract void Exit(MB_EnemyStateContext context);
    }
}