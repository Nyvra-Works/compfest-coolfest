using UnityEngine;

public abstract class MB_CharacterWalk : MonoBehaviour, IWalk
{
    public abstract void SetPosition(Vector3 direction);
}