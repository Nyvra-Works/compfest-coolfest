using StateMachines.Enemy.States;
using UnityEngine;

public class MB_CharacterMovement : MonoBehaviour
{
    /*
     * serialize fields (injection)
     */
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float _walkSpeed = 5f;
    public float WalkSpeed => _walkSpeed;

    [Header("I Walk (assign one)")]
    [SerializeField] protected MB_CharacterWalk _walkable;
    // [SerializeField] private PlayerWalk playerWalk;
    // [SerializeField] private AINavMeshWalk aINavMeshWalk;   


    [Header("I Character Control (assign one)")]
    [SerializeField] protected MB_CharacterMovementControl _characterControl;
    // [SerializeField] private MB_PlayerControl playerControl;
    // [SerializeField] private MB_AIControl aIControl;



    /*
     * fields
     */


    private void Awake()
    {
        // _walkable = playerWalk != null ? playerWalk : aINavMeshWalk;
        if (_walkable == null)
        {
            Debug.LogError($"{this.name} Walkable is not assigned. Please assign either PlayerWalk or AINavMeshWalk.");
            return;
        }

        // _characterControl = playerControl != null ? playerControl : aIControl;
        if (_characterControl == null)
        {
            Debug.LogError($"{this.name} Character control is not assigned. Please assign either MB_PlayerControl or MB_AIControl.");
        }
    }
    public virtual void Update()
    {
        _walkable.SetPosition(_characterControl.TargetDirection);
        // Debug.Log($"Target Direction: {_characterControl.TargetDirection}");
    }

}