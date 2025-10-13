using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _uiItemPrefab;
    [SerializeField] private Transform _uiContainer;
    [SerializeField] private List<InventoryItemSO> _possibleItems;

    private List<InventoryItemUI> _itemsInInventory = new List<InventoryItemUI>();

    public void AddNewItem()  //Function to add new item to inventory
    {
        InventoryItemSO newItemScriptable = GetRandomItem();
        InventoryItemUI alredyInInventoryUI = IsItemArleadyInInventory(newItemScriptable);
        if (alredyInInventoryUI != null && newItemScriptable.IsStackable)  // If object is stackable - remove amount
        {
            alredyInInventoryUI.AddAmount(1);
        }
        else  // Create new Object on scene and call Initialize item on it's Class
        {
            GameObject newItemObject = Instantiate(_uiItemPrefab, _uiContainer);
            InventoryItemUI newUIItem = newItemObject.GetComponent<InventoryItemUI>();
            _itemsInInventory.Add(newUIItem);
            newUIItem.InitializeItemUI(this, newItemScriptable, _itemsInInventory.Count - 1);
        }
    }

    public void RemoveItemAtIndex(int itemIndex)  // Remove item from List or reduce amount by it's index that is assigned on initialization
    {
        InventoryItemUI itemUIAtIndex = _itemsInInventory[itemIndex];
        if (itemUIAtIndex.Amount > 1)
        {
            itemUIAtIndex.RemoveAmount(1);
        }
        else
        {
            _itemsInInventory.RemoveAt(itemIndex);
            itemUIAtIndex.RemoveItemUI();
        }
    }

    private InventoryItemUI IsItemArleadyInInventory(InventoryItemSO item)  //Check if item is already in inventory by item's ID
    {
        foreach (InventoryItemUI itemUI in _itemsInInventory)
        {
            if (itemUI.ID == item.ID)
            {
                return itemUI;
            }
        }
        return null;
    }

    private InventoryItemSO GetRandomItem()  // Function to get random Scriptable object from list
    {
        return _possibleItems[Random.Range(0, _possibleItems.Count)];
    }

}
