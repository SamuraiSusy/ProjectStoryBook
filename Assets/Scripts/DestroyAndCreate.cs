using UnityEngine;
using System.Collections;

// tuhoa nykyin objekti, luo sen jälkeen uusi
// voi enabloida objektin
public class DestroyAndCreate : MonoBehaviour
{
    public float timer;
    public bool exterminate;

    public GameObject newObject;
    public bool createNew;

    private GameObject enablebleObject;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void DestoryGO()
    {
        Destroy(this.gameObject, timer);
    }

    //objekti, paikka
    public void CreateGO()
    {
        Instantiate(newObject);
    }

    public void EnableGameContent(string tag)
    {
        enablebleObject = GameObject.FindGameObjectWithTag(tag);
        enablebleObject.SetActive(true);
    }
}
