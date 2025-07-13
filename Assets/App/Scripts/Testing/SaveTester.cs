using UnityEngine;

public class SaveTester : MonoBehaviour
{
    public GameObject playerObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 randomPos = new(Random.Range(-10f, 10f), 1f, Random.Range(-10f, 10f));

            playerObject.transform.position = randomPos;
            Debug.Log("[Testingtesting] Random position applied: " + randomPos);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            MB_SaveManager.Instance.SaveGame();
            Debug.Log("[Testingtesting] Save triggered");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MB_SaveManager.Instance.LoadGame();
            Debug.Log("[Testingtesting] Load triggered");
        }
    }
}
