using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Inventory/InventoryItem")]
[Serializable]
public class InventoryItemSO : ScriptableObject
{
    [field : SerializeField] public string Name { get; private set; }
    [field : SerializeField] public int ID { get; private set; }
    [field : SerializeField] public Sprite Icon { get; private set; }
    [field : SerializeField] public bool IsStackable { get; private set; }
    [field : SerializeField] public int MaxAmount { get; private set; }
    [field: SerializeField] public int InitialAmount { get; private set; }

}
