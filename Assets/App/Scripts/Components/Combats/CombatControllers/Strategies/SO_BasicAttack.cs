using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_BasicAttack", menuName = "Scriptable Objects/Combat/SO_BasicAttack")]
public class SO_BasicAttack : SO_AbstractDamageDealerStrategy
{
    [field: SerializeField] public FloatReference Damage { get; private set; }
    [field: SerializeField] public FloatReference Knockback { get; private set; }
    [field: SerializeField] public FloatReference ElevationMofifier { get; private set; }

    public override void DealDamage(Transform[] targets, Transform myTransform)
    {
        if (targets == null)
        {
            return;
        }
        foreach (Transform target in targets)
        {
            // apply knockback
            Vector3 direction = (target.transform.position - myTransform.position);
            direction.y += ElevationMofifier;

            if (target.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                rigidbody.AddForce(direction.normalized * Knockback, ForceMode.Impulse);
            }
            // target.GetComponent<Rigidbody>().AddForce(direction.normalized * Knockback, ForceMode.Impulse);


            // give damage to IDamagable
            target.GetComponent<IDamagable>()?.TakeDamage(Damage.Value);

            // send my enum
            // TODO
            target.GetComponent<ICombatReceiver>()?.ReceiveCombatEvent(
                CombatEventType.BasicAttack
            );

        }
    }
}