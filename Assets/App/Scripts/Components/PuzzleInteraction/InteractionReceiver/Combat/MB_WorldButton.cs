using System;
using System.Linq.Expressions;
using UnityEngine;

namespace PuzzleInteraction.InteractionReceiver
{

    public class MB_WorldButton : MB_AbstractInteractionReceiver, ICombatReceiver
    {
        [SerializeField] bool isActive = false;
        [SerializeField] ReceiverMode receiverMode = ReceiverMode.Toggle;
        [SerializeField] float _toggleCooldownDuration = 0.5f;
        [SerializeField] CombatEventType _acceptedCombatEventType = CombatEventType.BasicAttack;
        public CombatEventType CombatEventType => _acceptedCombatEventType;
        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnActiveChanged?.Invoke();
                if (isActive && OnIsActiveTrue != null)
                {
                    OnIsActiveTrue?.Invoke();
                }
                else if (!isActive && OnIsActiveFalse != null)
                {
                    OnIsActiveFalse?.Invoke();
                }
            }
        }
        float time = 0;
        public void ReceiveCombatEvent(CombatEventType combatEventType)
        {
            time -= Time.deltaTime;

            if (time > 0)
            {
                return;
            }
            time = _toggleCooldownDuration;


            if (combatEventType == _acceptedCombatEventType)
            {
                IsActive = receiverMode switch
                {
                    ReceiverMode.Toggle => !isActive,
                    ReceiverMode.Trigger => true,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

    }
}