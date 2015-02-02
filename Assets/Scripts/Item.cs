using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public enum ItemTypes
    {
        CONSUMABLE,
        CHEST,
        INFORMATIVE
    }

    public string itemName;
    public string itemDescription;
    public int itemID;
    public Texture2D itemIcon;
    public ItemTypes itemType;
}