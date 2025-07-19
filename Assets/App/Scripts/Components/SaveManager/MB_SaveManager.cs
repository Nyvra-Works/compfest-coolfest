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

        var currentSaveState = new SerializationWrapper(saveState);
        string jsonWrapper = JsonUtility.ToJson(currentSaveState, true);
        File.WriteAllText(_savePath, jsonWrapper);

        Debug.Log("Saved to: " + _savePath + " at " + currentSaveState.savedTime);
    }

    public void LoadGame()
    {
        if (!File.Exists(_savePath))
        {
            Debug.LogWarning("Save file not found at: " + _savePath);
            return;   
        }

        string json = File.ReadAllText(_savePath);
        var loadedData = JsonUtility.FromJson<SerializationWrapper>(json);
        Dictionary<string, string> state = loadedData.ToDictionary();

        foreach (MonoBehaviour mb in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (mb is ISaveable saveable && state.TryGetValue(saveable.GetType().ToString(), out string savedJson))
            {
                saveable.RestoreState(savedJson);
            }
        }

        Debug.Log("Game loaded." + " Last saved at: " + loadedData.savedTime);
    }

    //not really SOLID, but for simplicity in saving/loading dictionaries h3h3
    [System.Serializable]
    private class SerializationWrapper
    {
        public string savedTime;
        public List<string> keys = new();
        public List<string> values = new();

        public SerializationWrapper(Dictionary<string, string> dict)
        {
            savedTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
