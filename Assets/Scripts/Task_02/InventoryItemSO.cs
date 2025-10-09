using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Inventory/InventoryItem")]
[Serializable]
public class InventoryItemSO : ScriptableObject
{
    [field : SerializeField] public string Name { get; private set; }
    [field : SerializeField] public Sprite Icon { get; private set; }
    [field : SerializeField] public bool IsStackable { get; private set; }
    [field : SerializeField] public int MaxAmount { get; private set; }
    [field : SerializeField] public int Amount { get; private set; }

    public void AddAmount(int amount)
    {
        Amount += amount;
        Mathf.Clamp(Amount, 0, MaxAmount);
    }

    public void RemoveAmount(int amount)
    {
        Amount -= amount;
        Mathf.Clamp(Amount, 0, MaxAmount);
    }

}
