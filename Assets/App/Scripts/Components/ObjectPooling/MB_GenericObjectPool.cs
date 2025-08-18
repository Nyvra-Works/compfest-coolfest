using UnityEngine;
using UnityEngine.Pool;
using System;

public abstract class MB_GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [Header("Pool Settings")]
    [SerializeField] protected T prefab;
    [SerializeField] protected int defaultCapacity = 10;
    [SerializeField] protected int maxSize = 100;
    [SerializeField] private int prewarmCount = 10;

    protected ObjectPool<T> pool;

    protected virtual void Awake()
    {
        pool = new ObjectPool<T>(
            createFunc: CreateObject,
            actionOnGet: OnGetObject,
            actionOnRelease: OnReleaseObject,
            actionOnDestroy: OnDestroyObject,
            collectionCheck: false,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );
    }

    protected virtual void Start()
    {
        for (int i = 0; i < prewarmCount; i++)
        {
            var obj = CreateObject();
            Release(obj);
        }
    }



    public virtual T Get()
    {
        return pool.Get();
    }


    public virtual void Release(T obj)
    {
        pool.Release(obj);
    }

    protected virtual T CreateObject()
    {
        var obj = Instantiate(prefab, transform);

        if (obj is IPoolable<T> poolable)
        {
            poolable.SetReleaseCallback(Release);
        }

        return obj;
    }

    protected virtual void OnGetObject(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected virtual void OnReleaseObject(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyObject(T obj)
    {
        Destroy(obj.gameObject);
    }

}
