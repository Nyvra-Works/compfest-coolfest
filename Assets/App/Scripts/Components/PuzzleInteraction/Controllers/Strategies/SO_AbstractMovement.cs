using UnityEngine;

[CreateAssetMenu(fileName = "SO_Movement", menuName = "Scriptable Objects/Puzzle Interaction/SO_Movement", order = 0)]
public abstract class SO_AbstractMovement : ScriptableObject
{
    protected bool IsKinematic = true;
    public abstract void UpdatePosition(Vector3 position, Rigidbody rb);
}