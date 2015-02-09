using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public enum ItemTypes
    {
        PUZZLE,
        CONSUMABLE,
        INFORMATIVE
    }

    public string itemName;
    public string itemDescription;
    public int itemID;
    public Texture2D itemIcon;
    public ItemTypes itemType;

    public Item(){}

    public Item(string name, int id, string desc, ItemTypes type)
    {
        itemName = name;
        itemDescription = desc;
        itemID = id;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);
        itemType = type;
    }
}