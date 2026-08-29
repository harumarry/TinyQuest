using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;

    Button button;
    int slotIndex;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSlotClicked);
    }

    void OnSlotClicked()
    {
        // 인벤토리 UI 에 인덱스 전달
        // 본인 슬롯 인덱스를 어떻게 알아내는지..
    }
}
