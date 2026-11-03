using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentSlotUI : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI itemName;

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
