using UnityEngine;

[CreateAssetMenu(
    fileName = "NewItemData", 
    menuName = "TinyQuest/Item Data")]

public class ItemData : ScriptableObject
{
    public string itemId;
    public string displayName;
    public ItemType itemType;

    [Min(1)]
    public int maxStack;

    [TextArea]
    public string description;
}
