using UnityEngine;
using System;
using System.Collections;

public class MB_PuzzleTimerManager : MonoBehaviour
{
    public static MB_PuzzleTimerManager Instance { get; private set; }

    public static event Action<float> OnTimerStarted;
    public static event Action OnTimerEnded;

    private Coroutine _currentTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void StartTimer(IPuzzleTimeLimit puzzle)
    {
        if (_currentTimer != null)
        {
            StopCoroutine(_currentTimer);
        }

        _currentTimer = StartCoroutine(TimerRoutine(puzzle));
    }

    private IEnumerator TimerRoutine(IPuzzleTimeLimit puzzle)
    {
        float timer = puzzle.PuzzleDuration;
        OnTimerStarted?.Invoke(timer);

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        OnTimerEnded?.Invoke();
        StopCoroutine(_currentTimer);
        _currentTimer = null;
        puzzle.OnPuzzleTimeout();
    }
}
