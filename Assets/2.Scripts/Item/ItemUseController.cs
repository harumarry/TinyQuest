using UnityEngine;

public class ItemUseController : MonoBehaviour
{
    [SerializeField] ItemDetailUI itemDetailUI;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Inventory inventory;

    private void OnEnable()
    {
        itemDetailUI.UseRequested += UseSelectedItem;
    }

    private void OnDisable()
    {
        itemDetailUI.UseRequested -= UseSelectedItem;
    }

    void UseSelectedItem()
    {
        int slotIndex = inventory.SelectedSlotIndex;
        InventorySlot slot = inventory.GetInventorySlot(slotIndex);

        if (slot.itemData.itemType != ItemType.Consumable) return;

        bool isHealed = playerHealth.TryHeal(slot.itemData.healAmount);
        if (isHealed == false) return;

        inventory.TryRemoveAt(slotIndex, 1);

        if (slot.count == 0) itemDetailUI.Hide();
    }
}
