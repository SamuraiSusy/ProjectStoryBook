using UnityEngine;
using System.Collections;

[System.Serializable]
public class Itemm
{
    public string name;
    public string description;
    public int id;
    public Texture2D icon;

    public Itemm() { }

    public Itemm(string name, int id, string desc)
    {
        this.name = name;
        this.description = desc;
        this.id = id;
        icon = Resources.Load<Texture2D>("ItemIcons/" + name);
    }
}