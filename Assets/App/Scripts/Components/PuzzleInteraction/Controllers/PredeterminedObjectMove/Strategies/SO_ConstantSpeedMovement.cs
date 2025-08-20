using UnityEngine;

[CreateAssetMenu(fileName = "SO_ConstantSpeedMovement", menuName = "Scriptable Objects/Puzzle Interaction/SO_ConstantSpeedMovement", order = 0)]
public class SO_ConstantSpeedMovement : SO_AbstractMovement
{
    [SerializeField] private float _speed = 1f;
    public override void UpdatePosition(Vector3 position, Transform transform)
    {
        //     if (rb.isKinematic != IsKinematic)
        //     {
        //         rb.isKinematic = IsKinematic;
        //     }
        //     rb.MovePosition(Vector3.MoveTowards(rb.position, position, _speed * Time.fixedDeltaTime)
        //     );
        transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.fixedDeltaTime);
    }
}