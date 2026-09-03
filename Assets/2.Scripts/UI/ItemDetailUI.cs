using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    // 아이콘, displayName, description, 사용 버튼
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI displayNameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Button useButton;

    public event Action UseRequested;

    private void Awake()
    {
        useButton.onClick.AddListener(OnUseButtonClicked);
    }

    // 아이템을 선택했을 때 index가 정해지고 아이템 정보를 넘기고
    public void Show(ItemData itemData)
    {
        itemIcon.sprite = itemData.icon;
        displayNameText.text = itemData.displayName;
        descriptionText.text = itemData.description;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void OnUseButtonClicked()
    {
        UseRequested?.Invoke();
    }
}
