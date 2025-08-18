using System.Collections;
using UnityEngine;

namespace StateMachines.Player.States
{
    public class BasicAttackState : AbstractState<MB_PlayerStateContext>
    {
        private MB_PlayerMovement _playerMovement;
        public override void Enter(MB_PlayerStateContext context)
        {
            // Debug.Log("Entering Basic Attack State");
            context.CombatController.BasicAttackEvent?.Invoke();

            // play animasi
        }

        public override void Exit(MB_PlayerStateContext context)
        {

        }
        float time = 0f;
        public override void UpdateExecute(MB_PlayerStateContext context)
        {
            // Kembali ke Idle setelah serangan selesai
            // pake animasi harusnya
            time += Time.deltaTime;
            if (time > context.BasicAttackSpeed)
            {
                time = 0f;
                context.TransitionToState(StateEnum.IdleState);
            }

            // allow player to move
            _playerMovement = (MB_PlayerMovement) context.CharacterMovement;
            _playerMovement.UpdateInState();
        }
    }
}