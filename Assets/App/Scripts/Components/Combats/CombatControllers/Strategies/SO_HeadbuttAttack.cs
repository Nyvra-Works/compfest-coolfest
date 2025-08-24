using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_HeadbuttAttack", menuName = "Scriptable Objects/Combat/SO_HeadbuttAttack")]
public class SO_HeadbuttAttack : SO_AbstractDamageDealerStrategy
{
    [SerializeField] FloatReference _damage;
    CombatEventType _combatEventType = CombatEventType.HeadbuttAttack;
    public FloatReference Damage => _damage;

    public override void DealDamage(Transform[] targets, Transform myTransform)
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
                _combatEventType
            );

        }
    }
}