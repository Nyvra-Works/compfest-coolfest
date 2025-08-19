using UnityEngine;

[CreateAssetMenu(fileName = "SO_ThrowWithForce", menuName = "Scriptable Objects/Throw/SO_ThrowWithForce", order = 0)]
public class SO_ThrowWithForce : SO_Throw
{
    [SerializeField] private float _force = 5;

    public override void Execute(Vector3 targetPosition, Vector3 myPosition, Rigidbody rigidbody)
    {
        var direction = (targetPosition - myPosition).normalized;
        rigidbody.AddForce(direction.normalized * _force, ForceMode.Impulse);
    }


}