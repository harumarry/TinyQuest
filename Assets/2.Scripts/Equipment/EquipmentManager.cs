using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] ItemDetailUI itemDetailUI;
    [SerializeField] EquipmentUI equipmentUI;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Inventory inventory;

    public ItemData CurrentWeapon { get; private set; }
    public ItemData CurrentArmor { get; private set; }

    public int WeaponSlotIndex { get; private set; } = -1;
    public int ArmorSlotIndex { get; private set; } = -1;

    private void OnEnable()
    {
        itemDetailUI.ItemActionRequested += HandleItemAction;
    }

    private void OnDisable()
    {
        itemDetailUI.ItemActionRequested -= HandleItemAction;
    }

    public void HandleItemAction(ItemData itemData)
    {
        switch (itemData.itemType)
        {
            case ItemType.Weapon:
                if (inventory.SelectedSlotIndex == WeaponSlotIndex)
                {
                    UnequipWeapon(); // 해제
                    equipmentUI.ClearSlot(ItemType.Weapon);
                }
                else
                {
                    EquipWeapon(itemData); // 장착
                    equipmentUI.UpdateSlot(itemData);
                }                 
                break;
            case ItemType.Armor:
                if (inventory.SelectedSlotIndex == ArmorSlotIndex)
                {
                    UnequipArmor();
                    equipmentUI.ClearSlot(ItemType.Armor);
                }
                else
                {
                    EquipArmor(itemData);
                    equipmentUI.UpdateSlot(itemData);
                }
                break;
        }  
      
        itemDetailUI.Show(itemData);
    }

    public void EquipWeapon(ItemData itemData)
    {
        if (itemData == null) return;

        if (CurrentWeapon != null)
        {
            playerStats.RemoveBonusAttack(CurrentWeapon.attackBonus);
        }

        CurrentWeapon = itemData;
        WeaponSlotIndex = inventory.SelectedSlotIndex;
      
        playerStats.AddBonusAttack(itemData.attackBonus);
    }

    public void EquipArmor(ItemData itemData)
    {
        if (itemData == null) return;

        if (CurrentArmor != null)
        {
            playerStats.RemoveBonusDefense(CurrentArmor.defenseBonus);
        }

        CurrentArmor = itemData;
        ArmorSlotIndex = inventory.SelectedSlotIndex;

        playerStats.AddBonusDefense(itemData.defenseBonus);
    }

    void UnequipWeapon()
    {
        if (CurrentWeapon != null)
        {
            playerStats.RemoveBonusAttack(CurrentWeapon.attackBonus);
        }

        CurrentWeapon = null;
        WeaponSlotIndex = -1;
    }

    void UnequipArmor()
    {
        if (CurrentArmor != null)
        {
            playerStats.RemoveBonusDefense(CurrentArmor.defenseBonus);
        }

        CurrentArmor = null;
        ArmorSlotIndex = -1;
    }

    public void SetWeaponSlotIndex(int index)
    {
        WeaponSlotIndex = index;
    }

    public void SetArmorSlotIndex(int index)
    {
        ArmorSlotIndex = index;
    }
}
