using UnityEngine;

public class MB_TeleliftableSpawner : MonoBehaviour
{
    [SerializeField] Vector3 _spawnOffset;
    [SerializeField] MB_TeleliftableItem _prefab;

    public MB_TeleliftableItem Spawn()
    {
        var instance = Instantiate(_prefab, transform.position + _spawnOffset, Quaternion.identity);
        instance.SetReleaseCallback(OnItemExpired);
        return instance;
    }
    private void OnItemExpired(MB_TeleliftableItem item)
    {
        item.gameObject.SetActive(false);
        item.transform.SetParent(transform);
        item.transform.position = transform.position + _spawnOffset;
        item.gameObject.SetActive(true);
    }

    void Start()
    {
        Spawn();
    }

}