using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] List<InventorySlotUI> inventorySlotUIs = new();

    private void OnEnable()
    {
        inventory.InventoryChanged += RefreshUI;
    }

    private void OnDisable()
    {
        inventory.InventoryChanged -= RefreshUI;
    }

    public void RefreshUI()
    {
        for (int i = 0; i < inventorySlotUIs.Count; i++)
        {
            InventorySlotUI slotUI = inventorySlotUIs[i];
            InventorySlot slot = inventory.GetInventorySlot(i);

            if (slot.itemData != null)
            {
                slotUI.icon.sprite = slot.itemData.icon;
                slotUI.countText.text = slot.count.ToString();
            }
            else
            {
                slotUI.icon.sprite = null;
                slotUI.countText.text = "0";
            }
        }      
    }
}
