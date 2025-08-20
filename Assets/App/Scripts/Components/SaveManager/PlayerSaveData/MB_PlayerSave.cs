using UnityEngine;

public class MB_PlayerSave : MonoBehaviour, ISaveable
{
    public PlayerSaveData playerData = new();

    void Start()
    {
        InitState();
    }

    void InitState()
    {
        playerData.position = new SerializableVector3(transform.position);
    }

    public object CaptureState()
    {
        playerData.position = new SerializableVector3(transform.position);
        return playerData;
    }

    public void RestoreState(object state)
    {
        string json = (string)state;
        playerData = JsonUtility.FromJson<PlayerSaveData>(json);

        transform.position = playerData.position.ToVector3();
    }
}
