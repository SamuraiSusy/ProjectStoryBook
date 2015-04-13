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
	}
}
