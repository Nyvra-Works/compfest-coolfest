using UnityEngine;

public abstract class MB_CharacterControl : MonoBehaviour, ICharacterControl
{
    public abstract Vector3 TargetDirection{ get; set; }
}