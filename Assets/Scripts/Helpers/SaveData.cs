using System;
using UnityEngine;

[Serializable]
public class SaveData  
{
    // This is the class that stores data of objects to serialize them
    public SaveData(string objectName, Vector3 objectPosition)
    {
        this.ObjectName = objectName;
        this.ObjectPosition = objectPosition;
    }

    public string ObjectName;
    public Vector3 ObjectPosition;
}
