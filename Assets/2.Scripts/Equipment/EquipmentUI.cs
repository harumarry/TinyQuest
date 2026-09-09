using NUnit.Framework.Interfaces;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] EquipmentSlotUI weaponSlotUI;
    [SerializeField] EquipmentSlotUI armorSlotUI;

    public void UpdateSlot(ItemData itemData)
    {
        switch (itemData.itemType)
        {
            case ItemType.Weapon:
                weaponSlotUI.SetItem(itemData);
                break;
            case ItemType.Armor:
                armorSlotUI.SetItem(itemData);
                break;
        }   
    }

    public void ClearSlot(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                weaponSlotUI.Clear();
                break;
            case ItemType.Armor:
                armorSlotUI.Clear();
                break;
        }
    }
}
