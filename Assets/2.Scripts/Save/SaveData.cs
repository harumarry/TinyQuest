using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Vector3 position; // 위치
    public int hp; // 체력

    public InventorySlotSaveData[] inventorySlots; // 배열 변수 선언

    public string weaponId;
    public string armorId;

    public int weaponSlotIndex;
    public int armorSlotIndex;
}
