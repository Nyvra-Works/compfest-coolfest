using UnityEngine;

[CreateAssetMenu(fileName = "SO_Throw", menuName = "Scriptable Objects/Throw/SO_Throw", order = 0)]
public abstract class SO_Throw : ScriptableObject
{
    // [SerializeField] private float _force = 5;
    // public void Execute(Vector3 direction, Rigidbody rigidbody)
    // {
    //     rigidbody.AddForce(direction.normalized * _force, ForceMode.Impulse);
    // }
    public abstract void Execute(Vector3 targetPosition, Vector3 myPosition, Rigidbody rigidbody);

}