using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public List<Item> items = new List<Item>();
 
	// Use this for initialization
	private void Start ()
    {
        items.Add(new Item("Hair pin", 1, "An old bobby pin."));
        items.Add(new Item("Left scissor half", 2, "Left"));
        items.Add(new Item("Right scissor half", 3, "Right"));
        items.Add(new Item("Scissors", 4, "Together again."));
        items.Add(new Item("Chalk", 5, "A small chalk"));
        items.Add(new Item("Item6", 6, "item 6"));
        items.Add(new Item("Item7", 7, "item 7"));
        items.Add(new Item("Item8", 8, "item 8"));
        items.Add(new Item("Item9", 9, "item 9"));
        items.Add(new Item("Item10", 10, "item 10"));
        items.Add(new Item("Item11", 11, "item 11"));
	}
}
// pinni, saksi1, saksi2, sakset, vaateet??