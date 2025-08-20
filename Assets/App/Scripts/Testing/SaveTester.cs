using UnityEngine;

public class SaveTester : MonoBehaviour
{
    public GameObject playerObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            MB_SaveManager.Instance.SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MB_SaveManager.Instance.LoadGame();
        }
    }
}
