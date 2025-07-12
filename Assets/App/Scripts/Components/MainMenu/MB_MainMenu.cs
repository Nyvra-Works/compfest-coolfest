using UnityEngine;

public class MB_MainMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _creditsPanel;

    public void OnNewGameButtonClicked()
    {
        Debug.Log("Play button clicked");
    }

    public void OnLoadGameButtonClicked()
    {
        Debug.Log("Load button clicked");
    }

    public void OnOptionsButtonClicked()
    {
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
        _creditsPanel.SetActive(false);
    }

    public void OnCreditsButtonClicked()
    {
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }

    public void OnBackButtonClicked()
    {
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
        _creditsPanel.SetActive(false);
    }
}
