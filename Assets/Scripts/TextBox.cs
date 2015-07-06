using UnityEngine;
using System.Collections;
// switch case, et voidaa käyttää samaa scriptii kaikis boxéis

public class TextBox : MonoBehaviour
{
    private PlayerControl player; // pelaaja ei voi liikkuu kun tekstiboksi o näkyvis

    public GUISkin skin;
    public int boxCase; // mimmone boksi o?
    public string[] text; // viimine indeksi ain tyhjäks
    private string current;
    private int count;

    private float boxW = 1.16f;
    private float boxH = 3f;
    private float boxL = 12.29f;
    private float boxT = 1.56f;

    private bool collided, show;

    // for cases 3-5
    private DestroyCreateEnable destroyCreateEnable;
    public GameObject[] gos; // kaikki uudet objektit
    public GameObject[] destroyableGOs; // kaikki tuhottavat objektit
    public Vector3[] gosPositions; // pitää olla saman verran kuin uusia objekteja
    public float destroyAfter = 0; // jos objektin tuhoamisessa pitää olla viive


	// Use this for initialization
	private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        current = "";
        count = 0;

        collided = false;
        show = false;

        destroyCreateEnable = GameObject.FindGameObjectWithTag("Holder").GetComponent<DestroyCreateEnable>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (collided)
            player.ShowExclamation(true);
        else
            player.ShowExclamation(false);

        if(show)
        {
            player.isStopped = true;
            Control();
        }
	}

    private void Control()
    {
        switch(boxCase)
        {
            case 1:
                // normi boxi
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    current = text[count];
                    count++;

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        show = false;
                    }
                }
                break;
            case 2:
                // normi boxi, jonka aikana näkyy kuva
                break;
            case 3:
                // normi teksti, jonka loputtua objekti
                // tuhoutuu, luo uuden objektin / objekteja
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    current = text[count];
                    count++;

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        for (int i = 0; i < destroyableGOs.Length; i++)
                            destroyCreateEnable.DestoryGameObject(destroyableGOs[i], destroyAfter);

                        for (int j = 0; j < gos.Length; j++)
                            destroyCreateEnable.CreateGO(gos[j], gosPositions[j]);

                            show = false;
                    }
                }
                break;
            case 4:
                // haluaako pelaaja poimia itemin
                // poimimisen jälkeen luo uuden / uusia objekteja
                break;
            case 5:
                // tarkistetaan, onko pelaajalla esine
                // jos on, pääsee etenemää -> esim tuhotaan nyk objekti, luodaan uusi
                // jos ei, sulkee tekstiboksin ja resettaa
                break;
            default:
                Debug.Log("there was error with text box");
                break;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(Screen.width / boxL, Screen.height / boxT,
            Screen.width / boxW, Screen.height / boxH);
        if(show)
            GUI.Box(boxRect, current, "Wilhelm");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            collided = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (collided && Input.GetKeyDown(KeyCode.Space))
        {
            show = true;
            //collided = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            collided = false;
            //examine.enabled = false;
        }
    }
}
