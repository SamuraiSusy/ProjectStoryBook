using UnityEngine;
using System.Collections;
//POISTETAAN
public class CreateNewObject : MonoBehaviour
{
    public GUISkin skin;
    public string[] text;
    private bool collided;
    private bool show;
    private string temp;
    private int count;

    private PlayerControl playerControl;
    private Inventory inventory;
    private DestroyCreateEnable destroyCreate;

    public GameObject prefab;
    public GameObject destroiableGO;
    public float newX, newY; // new objects coordinates

    // Use this for initialization
    private void Start()
    {
        collided = false;
        show = false;
        count = 0;
        temp = text[0];

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
        destroyCreate = GetComponent<DestroyCreateEnable>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && show)
        {
            playerControl.isStopped = false;
            WhichText();
        }
    }

    // only one text this time
    private void WhichText()
    {
        if (show)
        {
            temp = text[count];
            count++;

            if (count == text.Length)
            {
                count = 0;
                temp = text[0];
                show = false;
                CreateTeleporter();
            }
        }
    }

    private void CreateTeleporter()
    {
        destroyCreate.CreateGO(prefab, new Vector3(newX, newY));
        destroyCreate.DestoryGameObject(destroiableGO, 0);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show)
            GUI.Box(boxRect, temp, "Wilhelm");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (collided && Input.GetKeyDown(KeyCode.Space))
        {
            collided = false;
            show = true;
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