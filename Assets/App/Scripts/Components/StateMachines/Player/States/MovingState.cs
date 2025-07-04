using UnityEngine;

namespace StateMachines.Player.States
{
    public class MovingState : AbstractState<MB_AbstractContext<StateEnum>, StateEnum>
    {
        public override void Enter(MB_AbstractContext<StateEnum> context)
        {
            Debug.Log("Entering Moving State");
        }

        public override void Exit(MB_AbstractContext<StateEnum> context)
        {
        }

        public override void UpdateExecute(MB_AbstractContext<StateEnum> context)
        {
            
        }
    }
}