using UnityEngine;
using System.Collections;

// taulukko eri alueiden stringeille
// taulukko jokaiselle stringille, joka loppuu kysymykseen
// taulukko juu/ei vastauksille
public class testaus : MonoBehaviour
{
    private ChangeBoxContent change;
    private ChoiseButtons buttons;
    public bool show;
    private int arrayID, count;
    public string teksti;
    //public string[] curTeksti;
    public string[] alue1;

    public string[] alue1kysymys1;
    public string[] alue1valinnat1kylla;
    public string[] alue1valinnat1ei;

    public string[] alue1kysymys2;
    public string[] alue1valinnat2;

    private string testi1, testi2;
    private string mita1, mita2, mita3;
    private string kysymys1;
    private string kysymys1vastkylla1, kysymys1vastkylla2;
    private string kysymys1vastei1, kysymys1vastei2;
    // Use this for initialization
    void Start()
    {
        change = GameObject.FindGameObjectWithTag("Player").GetComponent<ChangeBoxContent>();
        buttons = GameObject.FindGameObjectWithTag("MessageBox").GetComponent<ChoiseButtons>();

        arrayID = 0;
        count = 0;
        teksti = "";

        testi1 = "testi1";
        testi2 = "testi2";
        mita1 = "test3";
        mita2 = "test4";
        mita3 = "test5";
        kysymys1 = "oisko mitaa?";
        kysymys1vastkylla1 = "jei happy";
        kysymys1vastkylla2 = "happy";
        kysymys1vastei1 = "oh nou";
        kysymys1vastei2 = ":( u.u";

        alue1 = new string[5];
        alue1[0] = testi1;
        alue1[1] = testi2;
        alue1[2] = mita1;
        alue1[3] = mita2;
        alue1[4] = mita3;

        alue1kysymys1 = new string[1];
        alue1kysymys1[0] = kysymys1;

        alue1valinnat1kylla = new string[2];
        alue1valinnat1kylla[0] = kysymys1vastkylla1;
        alue1valinnat1kylla[1] = kysymys1vastkylla2;

        alue1valinnat1ei = new string[2];
        alue1valinnat1ei[0] = kysymys1vastei1;
        alue1valinnat1ei[1] = kysymys1vastei2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.Q))
            show = !show;

        if (show && Input.GetKeyUp(KeyCode.Space))
        {
            aluenormi(alue1);
            //count++;
        }
    }

    private void OnGUI()
    {
        if (show)
            func1();
    }

    private void func1()
    {
        GUI.TextField(new Rect(10, 10, 100, 100), teksti);
    }

    // saamarin funktio kaataa koko unityn.....
    private void aluenormi(string[] txtarray)
    {
        //for (int i = 0; i < txtarray.Length; i++)
        //{
        //    if (count < txtarray.Length)
        //    {
        //        teksti = PrintMessages(txtarray, count);
        //        count++;
        //    }
        //    else
        //    {
        //        show = false;
        //        count = 0;
        //       // arrayID = 0;
        //        teksti = "";
        //    }
        //}

        while(count < txtarray.Length)
        {
            if (count < txtarray.Length)
            {
                teksti = PrintMessages(txtarray, count);
            }
            else if(count >= txtarray.Length)
            {
                show = false;
                count = 0;
                // arrayID = 0;
                teksti = "";
            }
        }
    }

    private void alue1kysymykset(string[] kysymysarray, string[] yesarray, string[] noarray)
    {
        int j = 0;
        for(int i = 0; i < kysymysarray.Length; i++)
        {
            if(count < kysymysarray.Length)
            {
                teksti = kysymysarray[i];
                count++;
            }

            if(count == kysymysarray.Length)
            {

            }
        }
    }
    private string PrintMessages(string[] messageArray, int messageID)
    {
        teksti = "";
        teksti += messageArray[messageID];

        return teksti;
    }
}