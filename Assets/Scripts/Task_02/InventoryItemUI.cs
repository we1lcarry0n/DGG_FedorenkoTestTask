using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public int Amount { get; private set; }
    public int ID { get; private set; }

    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _itemAmountText;
    [SerializeField] private Button _removeButton;

    private int _maxAmount;
    private int _currentIndex;
    private InventoryController _controller;

    public void InitializeItemUI(InventoryController controller ,InventoryItemSO inventoryItem, int index)
    {
        ID = inventoryItem.ID;
        Amount = inventoryItem.InitialAmount;
        _itemImage.sprite = inventoryItem.Icon;
        _maxAmount = inventoryItem.MaxAmount;
        _itemAmountText.text = Amount.ToString();
        _currentIndex = index;
        _controller = controller;
    }

    public void AddAmount(int amount)
    {
        Amount += amount;
        Mathf.Clamp(Amount, 0, _maxAmount);
        UpdateQuantityUI(Amount);
    }

    public void RemoveAmount(int amount)
    {
        Amount -= amount;
        Mathf.Clamp(Amount, 0, _maxAmount);
        UpdateQuantityUI(Amount);
    }

    public void RemoveButtonClicked()
    {
        _controller.RemoveItemAtIndex(_currentIndex);
    }

    public void RemoveItemUI()
    {
        Destroy(gameObject);
    }

    private void UpdateQuantityUI(int newAmount)
    {
        _itemAmountText.text = newAmount.ToString();
    }

}
