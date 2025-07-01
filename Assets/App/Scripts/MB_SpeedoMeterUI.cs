using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MB_SpeedoMeterUI : MonoBehaviour
{
    TextMeshProUGUI displayText;
    [SerializeField] Rigidbody subject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        if (displayText == null)
        {
            Debug.LogError("MB_SpeedoMeterUI: TextMeshProUGUI component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = "Speed: " + subject.linearVelocity.magnitude.ToString("F2") + " m/s";
    }
    
}
