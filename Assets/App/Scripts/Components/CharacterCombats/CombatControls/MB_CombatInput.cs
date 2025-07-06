using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MB_CombatInput : MonoBehaviour
{
    public Action BasicAttackEvent { get; set; }
    public Action SpecialAttack1Event { get; set; }
    public Action SpecialAttack2Event { get; set; }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            BasicAttackEvent?.Invoke();
            // Debug.Log("Basic Attack");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            SpecialAttack1Event?.Invoke();
            // Debug.Log("Special Attack 1");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            SpecialAttack2Event?.Invoke();
            // Debug.Log("Special Attack 2");
        }
    }
}