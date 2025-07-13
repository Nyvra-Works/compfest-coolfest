using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MB_SaveManager : MonoBehaviour
{
    public static MB_SaveManager Instance;
    private string _savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _savePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        Dictionary<string, string> saveState = new();

        foreach (MonoBehaviour mb in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is ISaveable saveable)
            {
                string json = JsonUtility.ToJson(saveable.CaptureState());
                saveState[saveable.GetType().ToString()] = json;
            }
        }

        string jsonWrapper = JsonUtility.ToJson(new SerializationWrapper(saveState), true);
        File.WriteAllText(_savePath, jsonWrapper);

        Debug.Log("Saved to: " + _savePath);
    }

    public void LoadGame()
    {
        if (!File.Exists(_savePath)) return;

        string json = File.ReadAllText(_savePath);
        Dictionary<string, string> state = JsonUtility.FromJson<SerializationWrapper>(json).ToDictionary();

        foreach (MonoBehaviour mb in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is ISaveable saveable && state.TryGetValue(saveable.GetType().ToString(), out string savedJson))
            {
                saveable.RestoreState(savedJson); // Pass JSON string directly
            }
        }

        Debug.Log("Game loaded.");
    }

    [System.Serializable]
    private class SerializationWrapper
    {
        public List<string> keys = new();
        public List<string> values = new();

        public SerializationWrapper(Dictionary<string, string> dict)
        {
            foreach (var pair in dict)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public Dictionary<string, string> ToDictionary()
        {
            var result = new Dictionary<string, string>();
            for (int i = 0; i < keys.Count; i++)
            {
                result[keys[i]] = values[i];
            }
            return result;
        }
    }
}
