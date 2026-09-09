using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI displayNameText;
    [SerializeField] TextMeshProUGUI descriptionText;

    [SerializeField] Button actionButton;
    [SerializeField] TextMeshProUGUI actionButtonText;

    [SerializeField] EquipmentManager equipmentManager;
    [SerializeField] Inventory inventory;

    public event Action<ItemData> ItemActionRequested;

    ItemData selectedItemData;

    private void Awake()
    {
        actionButton.onClick.AddListener(OnActionButtonClicked);
    }

    public void Show(ItemData itemData)
    {
        selectedItemData = itemData;

        itemIcon.sprite = itemData.icon;
        displayNameText.text = itemData.displayName;
        descriptionText.text = itemData.description;

        switch (itemData.itemType)
        {
            case ItemType.Consumable:
                actionButton.gameObject.SetActive(true);
                actionButtonText.text = "사용";
                break;
            case ItemType.Material:
                actionButton.gameObject.SetActive(false);
                break;
            case ItemType.Weapon:
                if (inventory.SelectedSlotIndex == equipmentManager.WeaponSlotIndex)
                {
                    actionButtonText.text = "해제";
                }
                else
                {
                    actionButtonText.text = "장착";
                }
                actionButton.gameObject.SetActive(true);
                break;
            case ItemType.Armor:
                if (inventory.SelectedSlotIndex == equipmentManager.ArmorSlotIndex)
                {
                    actionButtonText.text = "해제";
                }
                else
                {
                    actionButtonText.text = "장착";
                }
                actionButton.gameObject.SetActive(true);
                break;
        }

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void OnActionButtonClicked()
    {
        ItemActionRequested?.Invoke(selectedItemData);
    }
}
