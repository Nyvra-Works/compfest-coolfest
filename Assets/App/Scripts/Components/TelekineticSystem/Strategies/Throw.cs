using UnityEngine;

[System.Serializable]
public class Throw
{
    [SerializeField] private float _force = 5;
    public void Execute(Vector3 direction, Rigidbody rigidbody)
    {
        rigidbody.AddForce(direction.normalized * _force, ForceMode.Impulse);
    }
}