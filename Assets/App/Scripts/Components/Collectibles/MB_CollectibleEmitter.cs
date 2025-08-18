using System;
using PuzzleInteraction.InteractionReceiver;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MB_CollectibleEmitter : MonoBehaviour {
    [SerializeField] MB_CollectiblePool _collectiblePool;
    [SerializeField] int _number;

    [SerializeField] MB_WorldButton _button;

    void OnEnable()
    {
        _button.OnIsActiveTrue += EmitCollectible;
    }

    void OnDisable()
    {
        _button.OnIsActiveTrue -= EmitCollectible;
    }

    public void EmitCollectible()
    {
        for (int i = 0; i < _number; i++)
        {
            var obj = _collectiblePool.Get();
            obj.transform.position = transform.position + Vector3.right * UnityEngine.Random.Range(-1f, 1f) + Vector3.forward * UnityEngine.Random.Range(-1f, 1f);
        }
    }
}