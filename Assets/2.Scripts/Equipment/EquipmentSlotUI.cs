using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentSlotUI : MonoBehaviour
{
    Image icon;
    TextMeshProUGUI itemName;

    private void Awake()
    {
        icon = transform.Find("Icon").GetComponent<Image>();
        itemName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
    }

    public void SetItem(ItemData itemData)
    {
        icon.sprite = itemData.icon;
        itemName.text = itemData.displayName;
    }

    public void Clear()
    {
        icon.sprite = null;
        itemName.text = null;
    }
}
