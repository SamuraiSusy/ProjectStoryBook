using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public List<Item> items = new List<Item>();
 
	// Use this for initialization
	private void Start ()
    {
        items.Add(new Item("Item1", 1,"item 1"));
        items.Add(new Item("Item2", 2, "item 2"));
        items.Add(new Item("Item3", 3, "item 3"));
        items.Add(new Item("Item4", 4, "item 4"));
        items.Add(new Item("Item5", 5, "item 5"));
        items.Add(new Item("Item6", 6, "item 6"));
        items.Add(new Item("Item7", 7, "item 7"));
	}
}
