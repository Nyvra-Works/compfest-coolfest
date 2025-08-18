using UnityEngine;

public abstract class MB_CharacterWalk : MonoBehaviour, ILocomotory
{
    public abstract void SetPosition(Vector3 direction);
}