using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour
{
    private bool foundItem;
    private Inventory addToInventory;
    private ItemDatabase data;

	// Use this for initialization
	void Start ()
    {
        foundItem = false;
        addToInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        data = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Collect();
	}

    void Collect()
    {
        if(foundItem)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(GameObject.FindWithTag("Collectable"));
                addToInventory.AddItem(data.items[0].itemID);

                //Destroy(GameObject.FindWithTag("P1"));
                //addToInventory.AddItem(data.items[2].itemID);

                //Destroy(GameObject.FindWithTag("P2"));
                //addToInventory.AddItem(data.items[3].itemID);

                //Destroy(GameObject.FindWithTag("P3"));
                //addToInventory.AddItem(data.items[4].itemID);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable" ||
            col.gameObject.tag == "P1" ||
            col.gameObject.tag == "P2" ||
            col.gameObject.tag == "P3")
        {
            foundItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable" ||
            col.gameObject.tag == "P1" ||
            col.gameObject.tag == "P2" ||
            col.gameObject.tag == "P3")
        {
            foundItem = false;
        }
    }
}