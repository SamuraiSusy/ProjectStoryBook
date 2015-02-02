using UnityEngine;
using System.Collections;

public class CollectItem : MonoBehaviour
{
    private bool foundItem;

	// Use this for initialization
	void Start ()
    {
        foundItem = false;
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
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            foundItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            foundItem = false;
        }
    }
}