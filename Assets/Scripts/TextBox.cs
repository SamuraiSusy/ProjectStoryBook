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

    private float boxW, boxH, boxL, boxT;

    private bool collided, show;

    // for case 2
    private bool showExaminedObject;
    public Texture2D objectTexture;

    // for cases 3-5
    private DestroyCreateEnable destroyCreateEnable;
    public GameObject[] prefabs; // kaikki uudet objektit
    public GameObject[] destroyableGOs; // kaikki tuhottavat objektit
    public Vector3[] prefabsPositions; // pitää olla saman verran kuin uusia objekteja
    public float destroyAfter = 0; // jos objektin tuhoamisessa pitää olla viive

    // for cases 4-6
    private bool showButtons; // luo buttonit
    public string[] buttons; // buttonien määrän voi valita, mutta ainut tuettu määrä on 2
    private bool isTrue; // tuleeko itemi inventoryyn, luodaanko / poistetaanko obj..
    private int selected;
    public int itemID; // mikä itemi kerätään / tarvitaan
    private Inventory inventory;

    // for cases 5-6
    private FadeOut fadeOut;


	// Use this for initialization
	private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        current = "";
        count = 0;

        boxW = 1.14f;
        boxH = 3.6f;
        boxL = 16.56f;
        boxT = 1.55f;

        collided = false;
        show = false;

        showExaminedObject = false;

        destroyCreateEnable = GameObject.FindGameObjectWithTag("Holder").GetComponent<DestroyCreateEnable>();

        showButtons = false;
        isTrue = false;
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

        if (boxCase == 4 || boxCase == 5 || boxCase == 6 && showButtons)
            WhichButton();
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
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    showExaminedObject = true;
                    current = text[count];
                    count++;

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        showExaminedObject = false;

                        show = false;
                    }
                }
                break;
            case 3:
                // normi teksti, jonka loputtua objekti
                // tuhoutuu, luo uuden objektin / objekteja
                if (Input.GetKeyUp(KeyCode.Space) && show) // esim outo mies
                {
                    current = text[count];
                    count++;

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        if(destroyableGOs.Length != 0)
                        {
                            for (int i = 0; i < destroyableGOs.Length; i++)
                                destroyCreateEnable.DestoryGameObject(destroyableGOs[i], destroyAfter);
                        }

                        if(prefabs.Length != 0)
                        {
                            for (int j = 0; j < prefabs.Length; j++)
                                destroyCreateEnable.CreateGO(prefabs[j], prefabsPositions[j]);
                        }

                            show = false;
                    }
                }
                break;
            case 4:
                // haluaako pelaaja poimia itemin
                // poimimisen jälkeen luo uuden / uusia objekteja
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
                    current = text[count];
                    count++;

                    if(count == text.Length - 1)
                    {
                        showButtons = true;
                    }

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        if(isTrue)
                        {
                            if (destroyableGOs.Length != 0)
                            {
                                for (int i = 0; i < destroyableGOs.Length; i++)
                                    destroyCreateEnable.DestoryGameObject(destroyableGOs[i], destroyAfter);
                            }

                            if (prefabs.Length != 0)
                            {
                                for (int j = 0; j < prefabs.Length; j++)
                                    destroyCreateEnable.CreateGO(prefabs[j], prefabsPositions[j]);
                            }
                        }

                        isTrue = false;
                        show = false;
                    }
                }
                break;
            case 5:
                // haluaako pelaaja poimia itemin
                // poimimisen jälkeen luo uuden / uusia objekteja
                // fade out
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
                    fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();
                    current = text[count];
                    count++;

                    if (count == text.Length - 1)
                    {
                        showButtons = true;
                    }

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        if (isTrue)
                        {
                            // odottaa sekunnin, ennen kuin kutsuu
                            // objektien luomisen / poistamisen
                            StartCoroutine(Example());
                        }

                        isTrue = false;
                        show = false;
                    }
                }
                break;
            case 6: // EI VIELÄ VALMIS, PITÄÄ MIETTIÄ ENEMMÄN!!
                // tarkistetaan, onko pelaajalla esine
                // jos on, pääsee etenemää -> esim tuhotaan nyk objekti, luodaan uusi
                // fade out
                if (Input.GetKeyUp(KeyCode.Space) && show)
                {
                    inventory = GameObject.FindGameObjectWithTag("Holder").GetComponent<Inventory>();
                    fadeOut = GameObject.FindGameObjectWithTag("Holder").GetComponent<FadeOut>();
                    current = text[count];
                    count++;

                    if (count == text.Length - 1)
                    {
                        showButtons = true;
                    }

                    if (count == text.Length)
                    {
                        count = 0;
                        current = "";
                        player.isStopped = false;

                        if (isTrue)
                        {
                            // odottaa sekunnin, ennen kuin kutsuu
                            // objektien luomisen / poistamisen
                            StartCoroutine(Example());
                        }

                        isTrue = false;
                        show = false;
                    }
                }
                break;
            default:
                Debug.Log("there was error with text box, propably case does not exist");
                break;
        }
    }

    private IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        if (destroyableGOs.Length != 0)
        {
            for (int i = 0; i < destroyableGOs.Length; i++)
                destroyCreateEnable.DestoryGameObject(destroyableGOs[i], destroyAfter);
        }

        if (prefabs.Length != 0)
        {
            for (int j = 0; j < prefabs.Length; j++)
                destroyCreateEnable.CreateGO(prefabs[j], prefabsPositions[j]);
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect boxRect = new Rect(Screen.width / boxL, Screen.height / boxT,
            Screen.width / boxW, Screen.height / boxH);
        if(show)
            GUI.Box(boxRect, current, "Wilhelm");

        if(showExaminedObject && objectTexture != null) // case 2
        {
            Rect objectRect = new Rect(Screen.width / 1.5f, Screen.height / 15f, // muuta tarvittaessa
                Screen.width / (objectTexture.width / 600), Screen.height / (objectTexture.height / 600));
            GUI.Box(objectRect, objectTexture, "Icon");
        }

        if (showButtons)
            CreateButtons();

    }

    private void CreateButtons()
    {
        Rect yesRect = new Rect(Screen.width / 8, Screen.height / 1.2f, Screen.width / 8, Screen.height / 8.5f);
        Rect noRect = new Rect(Screen.width / 3.5f, Screen.height / 1.2f, Screen.width / 8, Screen.height / 8.5f);

        GUI.SetNextControlName(buttons[0]);
        if (GUI.Button(yesRect, buttons[0], "CustomButton"))
        {
            if (boxCase == 5 || boxCase == 6)
                fadeOut.StartFading();

            isTrue = true;

            if(boxCase == 4 || boxCase == 5)
                inventory.AddItem(itemID);

            //if(boxCase == 6)

            showButtons = false;
        }

        GUI.SetNextControlName(buttons[1]);
        if (GUI.Button(noRect, buttons[1], "CustomButton"))
        {
            showButtons = false;
        }

        GUI.FocusControl(buttons[selected]);
    }

    private int ButtonSelection(string[] buttonsArray, int selectedItem, string direction)
    {
        if (direction == "up")
        {
            if (selectedItem == 0)
            {
                selectedItem = buttonsArray.Length - 1;
            }
            else
            {
                selectedItem -= 1;
            }
        }

        if (direction == "down")
        {
            if (selectedItem == buttonsArray.Length - 1)
            {
                selectedItem = 0;
            }
            else
            {
                selectedItem += 1;
            }
        }
        return selectedItem;
    }

    private void WhichButton()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selected = ButtonSelection(buttons, selected, "up");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selected = ButtonSelection(buttons, selected, "down");
        }
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
