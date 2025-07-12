using System;
using UnityEngine;

public class MB_GamePause : MonoBehaviour
{
    public Action OnPauseEnter;
    public Action OnPauseExit;
    [SerializeField] bool useEsc = true;
    bool isPaused = false;
    void Start()
    {
        OnPauseEnter += () => { isPaused = true; Time.timeScale = 0; };
        OnPauseExit += () => { isPaused = false; Time.timeScale = 1; };
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            OnPauseEnter?.Invoke();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused)
        {
            OnPauseExit?.Invoke();
        }
    }
}
