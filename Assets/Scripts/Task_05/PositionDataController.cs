using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PositionDataController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsToSave;

    private string _savePath;

    public void SavePosition()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "PositionSaveData.json");
        WriteData();
    }

    public void LoadPosition()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "PositionSaveData.json");
        DeserializeData();
    }

    private List<string> SerializeData()
    {
        List<string> dataList = new List<string>();
        foreach (GameObject obj in _objectsToSave)
        {
            SaveData data = new SaveData(obj.name, obj.transform.position);
            string jsonData = JsonUtility.ToJson(data);
            dataList.Add(jsonData);
        }
        return dataList;
    }

    private void WriteData()
    {
        File.WriteAllLines(_savePath, SerializeData());
    }

    private void DeserializeData()
    {
        List<string> loadedDataList = ReadData();
        if (loadedDataList == null)
        {
            Debug.Log("Save file could not be found!");
            return;
        }
        foreach (string data in loadedDataList)
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(data);
            GameObject obj = _objectsToSave.Find(x => x.name == saveData.ObjectName);
            obj.transform.position = saveData.ObjectPosition;
        }
    }

    private List<string> ReadData()
    {
        if (File.Exists(_savePath))
        {
            List<string> jsonDataList = File.ReadAllLines(_savePath).ToList<string>();
            return jsonDataList;
        }
        return null;
    }
}
