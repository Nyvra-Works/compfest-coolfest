using System;
using UnityEngine;

public class MB_PlayerAlphaCombatController : MonoBehaviour
{
    [Header("Targets Finders")]
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForBasicAttack { get; private set; }
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForSpecialAttack { get; private set; }
    
    [SerializeField] private BasicAttack _basicAttack;
    void OnEnable()
    {
        // _combatInput.BasicAttackEvent += BasicAttackEventInvoked;
        BasicAttackEvent += BasicAttackEventInvoked;
    }
    void OnDisable()
    {
        // _combatInput.BasicAttackEvent -= BasicAttackEventInvoked;
        BasicAttackEvent -= BasicAttackEventInvoked;
    }

    public Action BasicAttackEvent;
    void BasicAttackEventInvoked()
    {
        var targets = TargetsFinderForBasicAttack.Targets;
        if (targets == null)
        {
            return;
        }
        _basicAttack.DealDamage(targets?.ToArray(), transform);
    }

}