using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public string name;
    public string description;
    public int id;
    public Texture2D icon;

    public Item() { }

    public Item(string name, int id, string desc)
    {
        this.name = name;
        this.description = desc;
        this.id = id;
        icon = Resources.Load<Texture2D>("ItemIcons/" + name);
        Debug.Log("item " + id);
    }
}