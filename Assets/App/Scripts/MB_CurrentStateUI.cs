using TMPro;
using UnityEngine;

public class MB_CurrentStateUI : MonoBehaviour
{
    [SerializeField] MB_PlayerStateContext _stateContext;
    [SerializeField] TextMeshProUGUI _currentStateText;

    private void Update() {
        _currentStateText.text = _stateContext.currentState.ToString();
    }
}