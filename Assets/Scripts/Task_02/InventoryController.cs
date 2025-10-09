using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _uiItemPrefab;
    [SerializeField] private Transform _uiContainer;
    [SerializeField] private List<InventoryItemSO> _possibleItems;

    private List<InventoryItemUI> _itemsInInventory = new List<InventoryItemUI>();

    public void AddNewItem()
    {
        InventoryItemSO newItemScriptable = GetRandomItem();
        InventoryItemUI alredyInInventoryUI = IsItemArleadyInInventory(newItemScriptable);
        if (alredyInInventoryUI != null && newItemScriptable.IsStackable)
        {
            alredyInInventoryUI.AddAmount(1);
        }
        else
        {
            GameObject newItemObject = Instantiate(_uiItemPrefab, _uiContainer);
            InventoryItemUI newUIItem = newItemObject.GetComponent<InventoryItemUI>();
            _itemsInInventory.Add(newUIItem);
            newUIItem.InitializeItemUI(this, newItemScriptable, _itemsInInventory.Count - 1);
        }
    }

    public void RemoveItemAtIndex(int itemIndex)
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

    private InventoryItemUI IsItemArleadyInInventory(InventoryItemSO item)
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

    private InventoryItemSO GetRandomItem()
    {
        return _possibleItems[Random.Range(0, _possibleItems.Count)];
    }

}
