using System;
using UnityEngine;

public class MB_PlayerAlphaCombatController : MonoBehaviour
{
    [Header("Targets Finders")]
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForBasicAttack { get; private set; }
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForSpecialAttack { get; private set; }

    [SerializeField] private BasicAttack _basicAttack;
    [SerializeField] private HeadbuttAttack _headbuttAttack;
    void OnEnable()
    {
        // _combatInput.BasicAttackEvent += BasicAttackEventInvoked;
        BasicAttackEvent += BasicAttackEventInvoked;
        HeadbuttAttackEvent += HeadbuttAttackEventInvoked;

    }
    void OnDisable()
    {
        // _combatInput.BasicAttackEvent -= BasicAttackEventInvoked;
        BasicAttackEvent -= BasicAttackEventInvoked;
        HeadbuttAttackEvent -= HeadbuttAttackEventInvoked;
    }

    public Action BasicAttackEvent;
    public Action HeadbuttAttackEvent;
    void BasicAttackEventInvoked()
    {
        var targets = TargetsFinderForBasicAttack.Targets;
        if (targets == null)
        {
            return;
        }
        _basicAttack.DealDamage(targets?.ToArray(), transform);
    }
    void HeadbuttAttackEventInvoked()
    {
        var targets = TargetsFinderForSpecialAttack.Targets;
        if (targets == null)
        {
            return;
        }
        _headbuttAttack.DealDamage(targets?.ToArray(), transform);
    }

}