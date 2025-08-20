using System.Collections.Generic;
using App.Scripts.Components.Puzzle;
using UnityEngine;

public class SequencePuzzleManager : MB_AbstractPuzzleBase
{
    [SerializeField] private List<SequenceObject> _sequenceObjects;
    [SerializeField] private List<SequenceObject> _sequenceKey;
    private int _index;


    #region Method Overrides
    public override void ResetPuzzle()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDisable()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnable()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    private void StartSequencing()
    {
        for (int i = 0; i < _sequenceObjects.Count; i++)
        {
            _sequenceKey.Add(_sequenceObjects[i]);
        }
    }

    private void CheckSequence(SequenceObject sequenceObject)
    {
        if (_sequenceKey.Count == 0) return;

        if (sequenceObject == _sequenceKey[_index])
        {
            _index++;
            if (_index >= _sequenceKey.Count)
            {
                // Logic
            }
        }
        else
        {
            ResetPuzzle();
        }
    }

}