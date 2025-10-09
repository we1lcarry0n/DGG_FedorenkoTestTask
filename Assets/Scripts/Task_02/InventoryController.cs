using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private List<InventoryItemSO> _possibleItems;

    private List<InventoryItemSO> _itemsInInventory = new List<InventoryItemSO>();

    public void AddNewItem(InventoryItemSO newItem)
    {
        if (IsItemArleadyInInventory(newItem) && newItem.IsStackable)
        {
            newItem.AddAmount(1);
            // Update GUI
            ShowDebugInv();
        }
        else
        {
            _itemsInInventory.Add(newItem);
            // Update GUI
            ShowDebugInv();
        }
    }

    public void RemoveItemAtIndex(int itemIndex)
    {
        if (_itemsInInventory[itemIndex].Amount > 1)
        {
            _itemsInInventory[itemIndex].RemoveAmount(1);
            // Update GUI
            ShowDebugInv();
        }
        else
        {
            _itemsInInventory.RemoveAt(itemIndex);
            // Update GUI
            ShowDebugInv();
        }
    }

    private bool IsItemArleadyInInventory(InventoryItemSO item)
    {
        return _itemsInInventory.Contains(item);
    }

    private InventoryItemSO GetRandomItem()
    {
        return _possibleItems[Random.Range(0, _possibleItems.Count)];
    }

    private void ShowDebugInv()
    {
        string inventory = "";
        foreach (InventoryItemSO item in _itemsInInventory)
        {
            inventory += $"{item.Name} : {item.Amount}, ";
        }
        Debug.Log(inventory);
    }
}
