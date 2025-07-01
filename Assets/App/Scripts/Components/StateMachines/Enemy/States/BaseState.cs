namespace StateMachines.Enemy.States
{
    using UnityEngine;

    public abstract class BaseState
    {
        public abstract void Enter(EnemyStateContext context);
        public abstract void UpdateExecute(EnemyStateContext context);
        public abstract void Exit(EnemyStateContext context);
    }
}