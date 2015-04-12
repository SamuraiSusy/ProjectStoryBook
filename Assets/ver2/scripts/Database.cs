using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public List<Itemm> items = new List<Itemm>();
 
	// Use this for initialization
	private void Start ()
    {
        items.Add(new Itemm("Item1", 0,"item 1"));
        items.Add(new Itemm("Item2", 1, "item 2"));
	}
}
