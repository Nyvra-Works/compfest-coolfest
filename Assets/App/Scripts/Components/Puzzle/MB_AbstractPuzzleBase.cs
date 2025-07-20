using System;
using UnityEngine;

public abstract class MB_AbstractPuzzleBase : MonoBehaviour, IPuzzleTrigger
{
    [SerializeField] protected bool isPuzzleFinished = false;
    public bool IsPuzzleFinished => isPuzzleFinished;

    [SerializeField] protected string puzzleName;
    public string PuzzleName => puzzleName;

    public static event Action<MB_AbstractPuzzleBase> OnThisPuzzleFinished;

    public abstract void TriggerPuzzle();
    public abstract void ResetPuzzle();

    public virtual void OnPuzzleFinished()
    {
        if (isPuzzleFinished) return;

        isPuzzleFinished = true;
        Debug.Log("Puzzle finished!");
        OnThisPuzzleFinished?.Invoke(this);
    }
}
