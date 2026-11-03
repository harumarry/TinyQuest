using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] ItemDatabase itemDatabase;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] EquipmentUI equipmentUI;

    [SerializeField] Button saveButton;
    [SerializeField] Button loadButton;

    string path;

    private void Awake()
    {
        // Path.Combine = 폴더 경로와 파일 이름을 안전하게 합쳐주는 함수
        // Application.persistentDataPath = 게임의 안전한 저장 위치를 알려주는 Unity 제공 경로
        path = Path.Combine(Application.persistentDataPath, "save.json");

        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

    void Save()
    {
        SaveData saveData = new();

        saveData.position = playerHealth.transform.position;
        saveData.hp = playerHealth.CurrentHp;

        saveData.inventorySlots = new InventorySlotSaveData[12]; // 배열 생성

        for (int i = 0; i < saveData.inventorySlots.Length; i++)
        {
            saveData.inventorySlots[i] = new InventorySlotSaveData(); // 객체 생성
            InventorySlot slot = inventory.GetInventorySlot(i);

            saveData.inventorySlots[i].itemId = slot.itemData?.itemId;
            saveData.inventorySlots[i].count = slot.count;
        }


        saveData.weaponId = equipmentManager.CurrentWeapon?.itemId;
        saveData.armorId = equipmentManager.CurrentArmor?.itemId;

        saveData.weaponSlotIndex = equipmentManager.WeaponSlotIndex;
        saveData.armorSlotIndex = equipmentManager.ArmorSlotIndex;

        // File.WriteAllText() = 문자열을 실제 파일로 저장
        // JsonUtility.ToJson() = C# 객체를 JSON 문자열로 변환   
        File.WriteAllText(path, JsonUtility.ToJson(saveData, true)); // prettyPrint = 줄바꿈 + 들여쓰기


    }

    void Load()
    {
        // File.ReadAllText = 파일 안에 있는 모든 내용을 문자열(string)로 한 번에 읽어옴       
        string json = File.ReadAllText(path);
        // JsonUtility.FromJson() = JSON 문자열을 C# 객체로 변환
        SaveData loadData = JsonUtility.FromJson<SaveData>(json);

        playerHealth.transform.position = loadData.position;
        playerHealth.SetHp(loadData.hp);

        for (int i = 0; i < loadData.inventorySlots.Length; i++)
        {
            string itemid = loadData.inventorySlots[i].itemId;
            InventorySlot slot = inventory.GetInventorySlot(i);

            slot.itemData = itemDatabase.GetItemById(itemid);
            slot.count = loadData.inventorySlots[i].count;
        }

        equipmentManager.EquipWeapon(itemDatabase.GetItemById(loadData.weaponId));
        equipmentManager.EquipArmor(itemDatabase.GetItemById(loadData.armorId));


        equipmentManager.SetWeaponSlotIndex(loadData.weaponSlotIndex);
        equipmentManager.SetArmorSlotIndex(loadData.armorSlotIndex);


        inventoryUI.RefreshUI();

        if (equipmentManager.CurrentWeapon != null)
        {
            equipmentUI.UpdateSlot(equipmentManager.CurrentWeapon);
        }
        else
        {
            equipmentUI.ClearSlot(ItemType.Weapon);
        }
        if (equipmentManager.CurrentArmor != null)
        {
            equipmentUI.UpdateSlot(equipmentManager.CurrentArmor);
        }
        else
        {
            equipmentUI.ClearSlot(ItemType.Armor);
        }
    }
}
