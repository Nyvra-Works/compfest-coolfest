using System;
using UnityEngine;

public class MB_PlayerAlphaCombatController : MonoBehaviour
{
    [Header("Targets Finders")]
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForBasicAttack { get; private set; }
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForSpecialAttack { get; private set; }


    [Header("Attack Scripts")]
    [SerializeField] private SO_AbstractDamageDealerStrategy _basicAttack;
    [SerializeField] private SO_AbstractDamageDealerStrategy _headbuttAttack;
    [SerializeField] private SO_AbstractDamageDealerStrategy _stompAttack;

    [Header("State Machine Context")]
    [SerializeField] private MB_PlayerStateContext _stateContext;
    void OnEnable()
    {
        // _combatInput.BasicAttackEvent += BasicAttackEventInvoked;
        BasicAttackEvent += BasicAttackEventInvoked;
        HeadbuttAttackEvent += HeadbuttAttackEventInvoked;


        _stateContext.HeadbuttStayAscendingHandler += HeadbuttAttackEventInvoked;

        _stateContext.OnEnterStompAttackHandler += StompAttackEventInvoked;
    }
    void OnDisable()
    {
        // _combatInput.BasicAttackEvent -= BasicAttackEventInvoked;
        BasicAttackEvent -= BasicAttackEventInvoked;
        HeadbuttAttackEvent -= HeadbuttAttackEventInvoked;

        _stateContext.HeadbuttStayAscendingHandler -= HeadbuttAttackEventInvoked;

        _stateContext.OnEnterStompAttackHandler -= StompAttackEventInvoked;

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
    void StompAttackEventInvoked()
    {
        var targets = TargetsFinderForSpecialAttack.Targets;
        if (targets == null)
        {
            return;
        }
        _stompAttack.DealDamage(targets?.ToArray(), transform);
    }

}