using UnityEngine;
using System.Collections;
// POISTETAAN
// TESTISCRIPTI
public class Androgyyni : MonoBehaviour {

    private DestroyCreateEnable destroyCreateEnable;

    public GameObject destroiableGO;

    private bool collided;
	// Use this for initialization
	void Start ()
    {
        destroyCreateEnable = GetComponent<DestroyCreateEnable>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(collided && Input.GetKeyDown(KeyCode.Space))
        {
            destroyCreateEnable.DestoryGameObject(destroiableGO, 0);
        }
	
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            collided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = false;
        }
    }
}
