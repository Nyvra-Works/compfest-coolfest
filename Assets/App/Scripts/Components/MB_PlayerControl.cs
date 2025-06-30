using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class MB_PlayerControl : MonoBehaviour, ICharacterControl
{
    /*
    * serialize fields (injection)
    */
    // [SerializeField] private Walkable walkable;

    /*
    * fields
    */
    // private IWalkable _walkable;

    public Vector3 LateralMovement { get; private set; }
    void Update()
    {
        LateralMovement = Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.forward;
        LateralMovement.Normalize();
    }
}