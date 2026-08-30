using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<InventorySlot> slots = new List<InventorySlot>(12);

    public event Action InventoryChanged;

    public int SelectedSlotIndex {  get; private set; } = -1;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    // 아이템을 추가하는 함수
    public int AddItem(ItemData itemData, int count)
    {
        int remainingCount = count; // 남아있는 수량

        foreach (InventorySlot slot in slots) // 1. 기존 중첩 슬롯부터 먼저 채우고
        {
            if (slot.itemData == itemData && slot.count < itemData.maxStack) // 중첩 슬롯
            {
                int availableSpace = itemData.maxStack - slot.count; // 빈 공간 (최대 수량 - 현재 개수)
                int addCount = Mathf.Min(availableSpace, remainingCount); // 빈 공간 vs 남은 수량 중 작은 거 선택
                slot.count += addCount;
                remainingCount -= addCount;
            }
        }

        foreach (InventorySlot slot in slots) // 2. 그래도 수량이 남으면 빈 슬롯 채우기
        {
            if (remainingCount > 0)
            {
                if (slot.itemData == null && slot.count == 0) // 빈 슬롯
                {
                    slot.itemData = itemData;
                    int addCount = Mathf.Min(itemData.maxStack, remainingCount);
                    slot.count = addCount;
                    remainingCount -= addCount;
                }
            }
        }    

        if ( remainingCount != count)
        {
            InventoryChanged?.Invoke();
        }

        return remainingCount;
    }

    public bool TryRemoveAt(int slotIndex, int amount)
    {
        InventorySlot slot = slots[slotIndex];

        if (slot.itemData != null && slot.count >= amount)
        {
            slot.count -= amount;

            if (slot.count == 0)
            {
                slot.itemData = null;
            }

            InventoryChanged?.Invoke();

            return true;
        }

        return false;
    }

    public InventorySlot GetInventorySlot(int i)
    {
        return slots[i];
    }

    public void SelectSlot(int index)
    {
        SelectedSlotIndex = index;
    }
}
