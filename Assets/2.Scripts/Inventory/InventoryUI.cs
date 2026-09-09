using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemDetailUI itemDetailUI;

    [SerializeField] List<InventorySlotUI> inventorySlotUIs = new();

    private void Awake()
    {
        for (int i = 0; i < inventorySlotUIs.Count; i++)
        {
            inventorySlotUIs[i].slotIndex = i;
        }
    }

    private void OnEnable()
    {
        inventory.InventoryChanged += RefreshUI;

        foreach (InventorySlotUI slotUI in inventorySlotUIs)
        {
            slotUI.SlotClicked += SelectionIndicator;
        }

        RefreshUI();
    }

    private void OnDisable()
    {
        inventory.InventoryChanged -= RefreshUI;

        foreach (InventorySlotUI slotUI in inventorySlotUIs)
        {
            slotUI.SlotClicked -= SelectionIndicator;
        }
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

    public void SelectionIndicator(int index)
    {
        foreach (InventorySlotUI slotUI in inventorySlotUIs)
        {
            slotUI.selected.SetActive(false);
        }

        inventory.SelectSlot(index); // 인벤토리에도 선택 인덱스를 전달
        InventorySlot selectedSlot = inventory.GetInventorySlot(index);

        if (selectedSlot.itemData != null)
        {
            itemDetailUI.Show(selectedSlot.itemData);
        }
        else
        {
            itemDetailUI.Hide();
        }

        inventorySlotUIs[index].selected.SetActive(true);
    }
}
