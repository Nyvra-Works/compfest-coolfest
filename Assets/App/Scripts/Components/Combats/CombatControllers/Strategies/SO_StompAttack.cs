using UnityEngine;

[CreateAssetMenu(fileName = "SO_StompAttack", menuName = "Scriptable Objects/Combat/SO_StompAttack")]
public class SO_StompAttack : SO_AbstractDamageDealerStrategy
{
    [SerializeField] FloatReference _damage;
    [SerializeField] CombatEventType _combatEventType = CombatEventType.StompAttack;
    public override void DealDamage(Transform[] targets, Transform myTransform)
    {
        if (targets == null)
        {
            return;
        }
        foreach (Transform target in targets)
        {
            // give damage to IDamagable
            target.GetComponent<IDamagable>()?.TakeDamage(_damage);

            // send my enum
            target.GetComponent<ICombatReceiver>()?.ReceiveCombatEvent(
                _combatEventType
            );
        }
    }
}