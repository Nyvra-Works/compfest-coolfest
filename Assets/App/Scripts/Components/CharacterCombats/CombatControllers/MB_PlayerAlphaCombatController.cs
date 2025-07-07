using System;
using UnityEngine;

public class MB_PlayerAlphaCombatController : MonoBehaviour
{
    [Header("Targets Finders")]
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForBasicAttack { get; private set; }
    [field: SerializeField] public MB_TargetsFinderByLayer TargetsFinderForSpecialAttack { get; private set; }
    [SerializeField] private BasicAttack _basicAttack;
    // void OnEnable()
    // {
    //     _combatInput.BasicAttackEvent += BasicAttackEventInvoked;
    // }
    // void OnDisable()
    // {
    //     _combatInput.BasicAttackEvent -= BasicAttackEventInvoked;
    // }

    void Start()
    {
        BasicAttackEvent += BasicAttackEventInvoked;
    }
    public Action BasicAttackEvent;
    void BasicAttackEventInvoked()
    {
        _basicAttack.DealDamage(TargetsFinderForBasicAttack.Targets?.ToArray());
    }

}