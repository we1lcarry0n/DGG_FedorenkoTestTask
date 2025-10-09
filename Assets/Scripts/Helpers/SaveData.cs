using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public SaveData(string objectName, Vector3 objectPosition)
    {
        this.ObjectName = objectName;
        this.ObjectPosition = objectPosition;
    }

    public string ObjectName;
    public Vector3 ObjectPosition;
}
