using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_TrashCollector : MB_AbstractPuzzleBase, IPuzzleTimeLimit
{
    [SerializeField] private GameObject _gameObjectTriggerer;

    [Header("Puzzle Time Limit")]
    [SerializeField] private float _puzzleDuration;
    public float PuzzleDuration => _puzzleDuration;

    [Header("Trash Collection Containers")]
    [SerializeField] private GameObject _organicTrashContainer;
    [SerializeField] private GameObject _anorganicTrashContainer;

    [Header("Trash Objects")]
    [SerializeField] private List<GameObject> _organicTrashObjects;
    [SerializeField] private List<GameObject> _anorganicTrashObjects;

    private bool isOrganicTrashCollected = false;
    private bool isAnorganicTrashCollected = false;

    private readonly Dictionary<GameObject, Vector3> _initialPositions = new();

    private void Awake()
    {
        foreach (var trash in _organicTrashObjects)
        {
            _initialPositions[trash] = trash.transform.position;
        }

        foreach (var trash in _anorganicTrashObjects)
        {
            _initialPositions[trash] = trash.transform.position;
        }
    }

    public override void TriggerPuzzle()
    {
        if (_gameObjectTriggerer != null)
        {
            if (!isPuzzleFinished)
            {
                Debug.Log("Triggering Trash Collection Puzzle...");
                MB_PuzzleTimerManager.Instance.StartTimer(this);
                TrashCollection();
            }
            else
            {
                Debug.Log("Puzzle already finished.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject Trigger is not assigned.");
        }
    }

    public override void ResetPuzzle()
    {
        isPuzzleFinished = false;
        StopAllCoroutines();

        isOrganicTrashCollected = false;
        isAnorganicTrashCollected = false;

        _organicTrashObjects.Clear();
        _anorganicTrashObjects.Clear();

        foreach (var kvp in _initialPositions)
        {
            if (kvp.Key != null)
            {
                kvp.Key.transform.position = kvp.Value;
            }
        }

        foreach (var obj in _initialPositions.Keys)
        {
            if (obj.CompareTag("OrganicTrash"))
            {
                _organicTrashObjects.Add(obj);
            }
            else if (obj.CompareTag("AnorganicTrash"))
            {
                _anorganicTrashObjects.Add(obj);
            }
        }

        Debug.Log("Trash Collection Puzzle has been reset.");
    }

    public void TrashCollection()
    {
        StartCoroutine(OrganicTrashCollection());
        StartCoroutine(AnorganicTrashCollection());
        StartCoroutine(CheckCompletion());
    }

    IEnumerator OrganicTrashCollection()
    {
        while (_organicTrashObjects.Count > 0)
        {
            for (int i = _organicTrashObjects.Count - 1; i >= 0; i--)
            {
                GameObject trash = _organicTrashObjects[i];
                if (trash.TryGetComponent(out Collider col) &&
                    col.CompareTag("OrganicTrashContainer"))
                {
                    Debug.Log($"Collected organic trash: {trash.name}");
                    trash.transform.position = _organicTrashContainer.transform.position;
                    _organicTrashObjects.RemoveAt(i);
                }
            }

            yield return null;
        }

        Debug.Log("All organic trash collected!");
        isOrganicTrashCollected = true;
    }

    IEnumerator AnorganicTrashCollection()
    {
        while (_anorganicTrashObjects.Count > 0)
        {
            for (int i = _anorganicTrashObjects.Count - 1; i >= 0; i--)
            {
                GameObject trash = _anorganicTrashObjects[i];
                if (trash.TryGetComponent(out Collider col) &&
                    col.CompareTag("AnorganicTrashContainer"))
                {
                    Debug.Log($"Collected anorganic trash: {trash.name}");
                    trash.transform.position = _anorganicTrashContainer.transform.position;
                    _anorganicTrashObjects.RemoveAt(i);
                }
            }

            yield return null;
        }

        Debug.Log("All anorganic trash collected!");
        isAnorganicTrashCollected = true;
    }

    IEnumerator CheckCompletion()
    {
        while (!(isOrganicTrashCollected && isAnorganicTrashCollected))
        {
            yield return null;
        }

        Debug.Log("All trash collected!");
        OnPuzzleFinished();
    }

    public void OnPuzzleTimeout()
    {
        Debug.Log("Puzzle timed out! Resetting puzzle.");
        ResetPuzzle();
    }
}
