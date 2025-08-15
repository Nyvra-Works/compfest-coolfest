using UnityEngine;

public interface IDamageDealer
{
    void DealDamage(Transform[] targets, Transform myTransform);
}