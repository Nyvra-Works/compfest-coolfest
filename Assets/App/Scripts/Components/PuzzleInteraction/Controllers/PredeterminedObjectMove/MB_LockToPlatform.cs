using Unity.VisualScripting;
using UnityEngine;

public class MB_LockToPlatform : MonoBehaviour
{
    private Transform _originalObjectParent;
    [SerializeField] private LayerMask _lockedObjectLayerMask;

    void LockToPlatform(Transform lockedObject)
    {
        _originalObjectParent = lockedObject.parent;
        lockedObject.parent = transform;
    }

    void UnlockFromPlatform(Transform lockedObject)
    {
        lockedObject.parent = _originalObjectParent;
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((1 << collision.gameObject.layer & _lockedObjectLayerMask) != 0)
        {
            LockToPlatform(collision.transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if ((1 << collision.gameObject.layer & _lockedObjectLayerMask) != 0)
        {
            UnlockFromPlatform(collision.transform);
        }
    }
}