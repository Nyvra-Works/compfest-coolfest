using UnityEngine;

public class MB_PlayerMovement : MonoBehaviour
{
    /*
     * serialize fields (injection)
     */
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _walkSpeed = 5f;

    [SerializeField] private PlayerWalk walkable;
    [SerializeField] private MB_PlayerControl characterControl;


    /*
     * fields
     */
    private IWalk _walkable;
    private ICharacterControl _characterControl;

    private void Awake()
    {
        _walkable = walkable;
        _characterControl = characterControl;

        _walkable = new PlayerWalk(_rigidbody, _walkSpeed);
    }
    void FixedUpdate()
    {
        _walkable.Move(_characterControl.LateralMovement);
    }
}