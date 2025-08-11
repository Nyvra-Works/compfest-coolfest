using System;
using UnityEngine;

public class MB_Collectible : MonoBehaviour, IPoolable<MB_Collectible>
{
    [SerializeField] LayerMask _collectorLayerMask;


    public Action<MB_Collectible> OnCollected;


    void OnTriggerEnter(Collider other)
    {
        if (IsInTargetLayer(other.gameObject.layer))
        {
            Debug.Log("Collectible collected");
            OnCollected?.Invoke(this);

        }
    }

    public void SetReleaseCallback(Action<MB_Collectible> releaseAction)
    {
        OnCollected = releaseAction;
    }
    private bool IsInTargetLayer(int layer)
    {
        return (_collectorLayerMask.value & (1 << layer)) != 0;
    }

}