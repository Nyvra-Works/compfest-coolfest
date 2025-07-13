using UnityEngine;

public class MB_PlayerSave : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        string json = (string)state;
        SerializableVector3 pos = JsonUtility.FromJson<SerializableVector3>(json);
        transform.position = pos.ToVector3();
    }

}
