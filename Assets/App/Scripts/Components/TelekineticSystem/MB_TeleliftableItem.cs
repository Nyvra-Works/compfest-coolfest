using UnityEngine;
public class MB_TeleliftableItem : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] Collider _collider;
    [SerializeField] Throw _throwStrategy;
    [SerializeField] [Tooltip("To apply damage or other effects")] LayerMask _layerOfTarget;
    [SerializeField] SO_ThrownObjectAttack _thrownObjectAttack;
    public void UpdatePosition(Vector3 position)
    {
        if (!_rigidbody.isKinematic && !_collider.isTrigger)
        {
            _rigidbody.isKinematic = true;
            _collider.isTrigger = true;
        }
        // _rigidbody.MovePosition(Vector3.Lerp(transform.position, position, lerpSpeed));
        _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, position, 1));
        // _rigidbody.MovePosition(position);
    }

    public void Throw(Vector3 targetPosition)
    {
        _rigidbody.isKinematic = false;
        _collider.isTrigger = false;
        var direction = (targetPosition - transform.position).normalized;
        _throwStrategy.Execute(direction, _rigidbody);
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((1 << collision.gameObject.layer & _layerOfTarget) != 0)
        {
            _thrownObjectAttack.DealDamage(new Transform[] { collision.transform }, transform);
        }
    }

}