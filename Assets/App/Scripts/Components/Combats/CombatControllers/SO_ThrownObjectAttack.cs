using UnityEngine;

[CreateAssetMenu(fileName = "SO_ThrownObjectAttack", menuName = "Scriptable Objects/Combat/SO_ThrownObjectAttack")]
public class SO_ThrownObjectAttack : ScriptableObject, IDamageDealer
{
    [SerializeField] FloatReference _damage;
    [SerializeField] CombatEventType _combatEventType = CombatEventType.ThrowAttack;
    public void DealDamage(Transform[] targets, Transform myTransform)
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