using UnityEngine;

namespace StateMachines.Player.States
{
    public class IdleState : AbstractState<MB_AbstractContext<StateEnum>, StateEnum>
    {
        public override void Enter(MB_AbstractContext<StateEnum> context)
        {
            Debug.Log("Entering Idle State");
        }

        public override void Exit(MB_AbstractContext<StateEnum> context)
        {
        }

        public override void UpdateExecute(MB_AbstractContext<StateEnum> context)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                context.TransitionToState(StateEnum.MovingState);
            }
        }
    }
}