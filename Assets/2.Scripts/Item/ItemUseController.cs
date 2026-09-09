using UnityEngine;

public class ItemUseController : MonoBehaviour
{
    [SerializeField] ItemDetailUI itemDetailUI;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Inventory inventory;

    private void OnEnable()
    {
        itemDetailUI.ItemActionRequested += UseItem;
    }

    private void OnDisable()
    {
        itemDetailUI.ItemActionRequested -= UseItem;
    }

    void UseItem(ItemData itemData)
    {
        int slotIndex = inventory.SelectedSlotIndex;
        InventorySlot slot = inventory.GetInventorySlot(slotIndex);

        if (itemData.itemType != ItemType.Consumable) return;

        bool isHealed = playerHealth.TryHeal(itemData.healAmount);
        if (isHealed == false) return;

        inventory.TryRemoveAt(slotIndex, 1);

        if (slot.count == 0) itemDetailUI.Hide();
    }
}
