using UnityEngine;

[CreateAssetMenu(
    fileName = "NewItemData", 
    menuName = "TinyQuest/Item Data")]

public class ItemData : ScriptableObject
{
    // 기본 정보 -> 아이콘/타입 -> 중첩 -> 효과 수치 (순서)
    public string itemId;
    public string displayName;

    [TextArea]
    public string description;

    public Sprite icon;
    public ItemType itemType;

    [Min(1)]
    public int maxStack;

    public int healAmount;
    public int attackBonus;
    public int defenseBonus; 
}
