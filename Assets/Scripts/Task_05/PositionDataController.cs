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
            SaveData data = new SaveData(obj.name, obj.transform.position);  //Create new Class instance with object's data to serialize it
            string jsonData = JsonUtility.ToJson(data); // Convert serializable class to json
            dataList.Add(jsonData); // add json string to list
        }
        return dataList;
    }

    private void WriteData()
    {
        File.WriteAllLines(_savePath, SerializeData());  // write all json strings from list to file
    }

    private void DeserializeData()
    {
        List<string> loadedDataList = ReadData();
        if (loadedDataList == null)  // Check for existing dataList
        {
            Debug.Log("Save file could not be found!");
            return;
        }
        foreach (string data in loadedDataList)
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(data);  //Deserealize json string to Serializable class
            GameObject obj = _objectsToSave.Find(x => x.name == saveData.ObjectName); //Find objects by names and set their positions from the saved ones
            obj.transform.position = saveData.ObjectPosition;
        }
    }

    private List<string> ReadData()
    {
        if (File.Exists(_savePath))  //Try to get the existing Data List
        {
            List<string> jsonDataList = File.ReadAllLines(_savePath).ToList<string>();
            return jsonDataList;
        }
        return null;
    }
}
