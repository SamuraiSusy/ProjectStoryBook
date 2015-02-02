using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory;
    private ItemDatabase itemDatabase;

	// Use this for initialization
	void Start ()
    {
        //itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddToInventory()
    {

    }
}
