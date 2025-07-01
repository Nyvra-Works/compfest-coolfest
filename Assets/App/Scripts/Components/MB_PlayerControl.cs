using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class MB_PlayerControl : MB_CharacterControl
{
    /*
    * serialize fields (injection)
    */
    // [SerializeField] private Walkable walkable;

    /*
    * fields
    */
    // private IWalkable _walkable;

    public override Vector3 TargetDirection { get; set; }
    void Update()
    {
        TargetDirection = Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.forward;
        TargetDirection.Normalize();
    }
}