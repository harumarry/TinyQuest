using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;
    public GameObject selected;
    public int slotIndex;

    Button button;

    public event Action<int> SlotClicked;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnSlotClicked);
    }

    private void OnDisable()
    {
        selected.SetActive(false);
    }

    void OnSlotClicked()
    {
        SlotClicked?.Invoke(slotIndex);
    }
}
