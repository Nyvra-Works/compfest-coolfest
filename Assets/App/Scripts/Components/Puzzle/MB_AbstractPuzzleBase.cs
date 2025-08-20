using System;
using PuzzleInteraction.Controllers;
using UnityEngine;

namespace App.Scripts.Components.Puzzle
{
    public abstract class MB_AbstractPuzzleBase : MB_AbstractController
    {
        [SerializeField] protected bool isPuzzleFinished = false;
        public bool IsPuzzleFinished => isPuzzleFinished;
    
        public static event Action<MB_AbstractPuzzleBase> OnThisPuzzleFinished;
    
        public abstract void ResetPuzzle();

        public virtual void OnPuzzleFinished()
        {
            if (isPuzzleFinished) return;

            isPuzzleFinished = true;
            Debug.Log("Puzzle finished!");
            OnThisPuzzleFinished?.Invoke(this);
        }
    }
}
