using System;
using UnityEngine;

namespace App.Scripts.Components.Puzzle
{
    public class MB_TrashContainer : MonoBehaviour
    {
        [SerializeField] private TrashTypeEnum _trashType;
        public Action OnTrashCollected;
        public Action OnTrashWrongPlace;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<MB_TrashObject>(out var trashType))
            {
                if (trashType.trashType == _trashType) OnTrashCollected?.Invoke();
                else OnTrashWrongPlace?.Invoke();
            }
        }
    }
}