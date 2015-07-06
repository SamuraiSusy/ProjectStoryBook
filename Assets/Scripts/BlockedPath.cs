using UnityEngine;
using System.Collections;
// POISTETAAN
public class BlockedPath : MonoBehaviour
{
    public GUISkin skin;
    // kiinnitä ykso jokaiseen objektiin!!!11!
    public string[] text; // jätä viimeinen kenttä(indeksi) tyhjäksi
    private bool show;
    private string current;
    private int count;

    private bool collided;

    private PlayerControl playerControl;
    private Examine examine;
    private DestroyCreateEnable destroyCreateEnable;

    // new strange man and enable teleporter to the next level
    public GameObject prefab, prefab2;
    public GameObject destroiableGO, destroiableGO2;

    // Use this for initialization
    private void Start()
    {
        show = false;
        current = text[0];
        count = 0;

        collided = false;

        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        examine = GetComponent<Examine>();
        destroyCreateEnable = GetComponent<DestroyCreateEnable>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (show)
            playerControl.isStopped = true;

        if (Input.GetKeyUp(KeyCode.Space) && show)
        {
            examine.showExaminedItem = true;
            current = text[count];
            count++;

            if (count == text.Length)
            {
                count = 0;
                current = text[0];
                show = false;
                examine.showExclamation = false;
                playerControl.isStopped = false;
                EnablePath();
            }
        }

        if (!show)
        {
            examine.showExaminedItem = false;
        }
    }

    // enables the next level and changes androgyyni's dialogue
    private void EnablePath()
    {
        // starnge man
        destroyCreateEnable.CreateGO(prefab, new Vector3(11.77f, -0.77f));
        destroyCreateEnable.DestoryGameObject(destroiableGO, 0);
        // teleporter
        destroyCreateEnable.CreateGO(prefab2, new Vector3(6.07f, -1.63f));
        destroyCreateEnable.DestoryGameObject(destroiableGO2, 0);
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(300, 300, 150, 100);
        if (show)
            GUI.Box(boxRect, current, "Wilhelm");
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
        if (collided && Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.Space))
        {
            show = true;
            collided = false;
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
