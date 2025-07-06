using System;
using UnityEngine;

[Serializable]
public class BasicAttack
{
    [field: SerializeField] public FloatReference Damage { get; private set; }
    [field: SerializeField] public FloatReference Knockback { get; private set; }

    public void DealDamage(Transform[] targets)
    {
        foreach (Transform target in targets)
        {
            target.GetComponent<MB_SceneBoundHealthController>()?.TakeDamage(Damage.Value);
        }
    }
}