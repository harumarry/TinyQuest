using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemDatabase",
    menuName = "TinyQuest/Item Database")]

public class ItemDatabase : ScriptableObject
{
    [SerializeField] List<ItemData> items = new();

    public ItemData GetItemById(string id)
    {
        foreach (ItemData item in items)
        {
            if (item.itemId == id)
            {
                return item;
            }
        }

        return null;
    }
}
