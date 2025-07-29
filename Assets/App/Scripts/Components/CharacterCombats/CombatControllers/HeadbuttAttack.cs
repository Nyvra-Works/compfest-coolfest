using System;
using UnityEngine;

[Serializable]
public class HeadbuttAttack: IDamageDealer
{
    [SerializeField] FloatReference _damage;
    public FloatReference Damage => _damage;

    public void DealDamage(Transform[] targets, Transform myTransform)
    {
         if (targets == null)
        {
            return;
        }
        foreach (Transform target in targets)
        {
            // give damage to IDamagable
            target.GetComponent<IDamagable>()?.TakeDamage(Damage.Value);

            // send my enum
            target.GetComponent<ICombatReceiver>()?.ReceiveCombatEvent(
                // TODO
                // CombatEventType.BasicAttack
            ); 

        }
    }
}