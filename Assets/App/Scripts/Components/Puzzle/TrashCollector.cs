using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour, IPuzzleTrigger
{
    [SerializeField] private GameObject _gameObjectTriggerer;

    [Header("Trash Collection Containers")]
    [SerializeField] private GameObject _organicTrashContainer;
    [SerializeField] private GameObject _anorganicTrashContainer;

    [Header("Trash Objects")]
    [SerializeField] private List<GameObject> _organicTrashObjects;
    [SerializeField] private List<GameObject> _anorganicTrashObjects;

    private bool isOrganicTrashCollected = false;
    private bool isAnorganicTrashCollected = false;

    [SerializeField] private bool isPuzzleFinished = false;

    public static event Action OnTrashCollectorFinished;

    public void TriggerPuzzle()
    {
        if (_gameObjectTriggerer != null)
        {
            if (!isPuzzleFinished)
            {
                Debug.Log("Triggering Trash Collection Puzzle...");
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

    public void ResetPuzzle()
    {
        
    }

    public void OnPuzzleFinished()
    {
        StopAllCoroutines();
        isPuzzleFinished = true;
        OnTrashCollectorFinished?.Invoke();
        Debug.Log("Puzzle Finished!");
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

}
