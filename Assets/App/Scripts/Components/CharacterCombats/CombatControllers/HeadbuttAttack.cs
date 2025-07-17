using System;
using UnityEngine;

[Serializable]
public class HeadbuttAttack: IDamageDealer
{
    [SerializeField] FloatReference _damage;
    public FloatReference Damage => _damage;
    [SerializeField] FloatReference maximumHeight;
    public FloatReference MaximumHeight => maximumHeight;
    public void DealDamage(Transform[] targets, Transform myTransform)
    {
        throw new NotImplementedException();
    }
}