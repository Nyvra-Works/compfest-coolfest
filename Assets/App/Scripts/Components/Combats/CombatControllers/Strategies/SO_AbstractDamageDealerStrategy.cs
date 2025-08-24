using UnityEngine;

[CreateAssetMenu(fileName = "SO_AbstractDamageDealerStrategy", menuName = "Scriptable Objects/Combat/SO_AbstractDamageDealerStrategy", order = 0)]
public abstract class SO_AbstractDamageDealerStrategy : ScriptableObject, IDamageDealer
{
    public abstract void DealDamage(Transform[] targets, Transform myTransform);
}