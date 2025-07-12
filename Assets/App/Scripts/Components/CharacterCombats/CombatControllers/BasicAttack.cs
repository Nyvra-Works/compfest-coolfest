using System;
using UnityEngine;

[Serializable]
public class BasicAttack
{
    [field: SerializeField] public FloatReference Damage { get; private set; }
    [field: SerializeField] public FloatReference Knockback { get; private set; }
    [field: SerializeField] public FloatReference ElevationMofifier { get; private set; }
    private DamageDealer _damageDealer;
    private void Start()
    {
        _damageDealer = new DamageDealer(Damage);
    }

    public void DealDamage(Transform[] targets, Transform myTransform)
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
            target.GetComponent<Rigidbody>().AddForce(direction.normalized * Knockback, ForceMode.Impulse);


            // give damage to IDamagable
            target.GetComponent<IDamagable>()?.TakeDamage(Damage.Value);

        }
    }
}