using System.Collections.Generic;
using System.Linq;
using PuzzleInteraction.InteractionReceiver;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace App.Scripts.Components.Puzzle
{
    public class TrashPuzzleManager : MB_AbstractPuzzleBase, IPuzzleTimeLimit
    {
        [SerializeField] private List<MB_TrashContainer> _trashContainer;
        [SerializeField] private List<MB_TrashObject> _trashObject;

        private List<MB_TrashObject> _collectedTrash;

        #region Method Overrides
        protected void OnEnable()
        {
            foreach (var trash in _trashContainer)
            {
                trash.OnTrashCollected += CollectTrash;
                trash.OnTrashWrongPlace += RemoveTrash;
            }
        }

        protected void OnDisable()
        {
            foreach (var trash in _trashContainer)
            {
                trash.OnTrashCollected -= CollectTrash;
                trash.OnTrashWrongPlace -= RemoveTrash;
            }
        }

        public override void ResetPuzzle()
        {
            foreach (var trash in _collectedTrash.ToList())
            {
                _trashObject.Add(trash);
                _collectedTrash.Remove(trash);
                trash.OnPuzzleReset();
            }
        }
        
        public float PuzzleDuration { get; }
        
        public void OnPuzzleTimeout()
        {
            ResetPuzzle();
        }
        #endregion
        
        private void CollectTrash()
        {
            foreach (var trash in _trashObject.ToList())
            {
                trash.Collect();
                _collectedTrash.Add(trash);
                _trashObject.Remove(trash);

                if (_trashObject.Count == 0) 
                { 
                    OnPuzzleFinished();
                }
            }
        }

        private void RemoveTrash()
        {
            foreach (var trash in _trashObject.ToList())
            {
                trash.OnPuzzleReset();
            }
        }
    }
}