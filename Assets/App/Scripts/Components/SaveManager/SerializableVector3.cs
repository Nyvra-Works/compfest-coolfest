using UnityEngine;

// SerializableVector3 is used to serialize Vector3 positions for saving and loading game state.
// It can be used for storing player position, enemies, and etc.
[System.Serializable]
public class SerializableVector3
{
    public float x, y, z;

    public SerializableVector3(Vector3 pos)
    {
        x = pos.x;
        y = pos.y;
        z = pos.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}
