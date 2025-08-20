using UnityEngine;

namespace App.Scripts.Components.Puzzle
{
    public class MB_TrashObject : MonoBehaviour
    {
        public TrashTypeEnum trashType;
        public Transform initTransform;
        public bool isCollected { get; private set; }
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Start()
        {
            initTransform.position = transform.position;
        }
        
        public void Collect()
        {
            isCollected = true;
            _collider.enabled = false;
        }
        
        public void OnPuzzleReset()
        {
            isCollected = false;
            transform.position = initTransform.position;
        }
    }
}