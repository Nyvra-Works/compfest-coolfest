using UnityEngine;

public abstract class MB_CharacterMovementControl : MonoBehaviour, ICharacterMovementControl
{
    public abstract Vector3 TargetDirection{ get; set; }
}