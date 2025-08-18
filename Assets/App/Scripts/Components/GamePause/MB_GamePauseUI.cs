using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MB_GamePauseUI : MonoBehaviour
{
    [SerializeField] private MB_GamePause gamePauseLogic;
    [SerializeField] private GameObject pausePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        gamePauseLogic.OnPauseEnter += PauseEnterInvoked;
        gamePauseLogic.OnPauseExit  += PauseExitInvoked;
    }
    void OnDisable()
    {
        gamePauseLogic.OnPauseEnter -= PauseEnterInvoked;
    }


    // Update is called once per frame
    void Update()
    {
    }

    void PauseEnterInvoked()
    {
        pausePanel.SetActive(true);
    }
    void PauseExitInvoked()
    {
        pausePanel.SetActive(false);
    }

    public void ResumeButtonClicked()
    {
        gamePauseLogic.OnPauseExit?.Invoke();
        // pausePanel.SetActive(false);
    }

}
