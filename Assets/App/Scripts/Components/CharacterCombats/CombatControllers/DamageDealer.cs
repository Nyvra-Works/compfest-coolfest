using UnityEngine;

public class DamageDealer
{
    private readonly float _damage;
    public DamageDealer(float damage)
    {
        _damage = damage;
    }
    public void DealDamage(IDamagable damagable)
    {
        // damagable.GetComponent<IDamagable>()?.TakeDamage(_damage);
        damagable.TakeDamage(_damage);
    }
}