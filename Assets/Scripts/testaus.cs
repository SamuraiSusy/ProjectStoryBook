using UnityEngine;
using System.Collections;

public class testaus : MonoBehaviour
{
    private bool show;
    private int arrayID, count;
    private string teksti;
    private string[][] strings;
    private string[] strings1;
    private string[] strings2;
    // Use this for initialization
    void Start()
    {
        arrayID = 0;
        count = 0;
        teksti = "";

        strings1 = new string[4];
        strings1[0] = "moi";
        strings1[1] = "terve";
        strings1[2] = "ihqu";
        strings1[3] = "ihana";

        strings2 = new string[4];
        strings1[0] = "moi2";
        strings1[1] = "terve2";
        strings1[2] = "ihqu2";
        strings1[3] = "ihana2";

        strings = new string[2][];
        strings[0] = strings1;
        strings[1] = strings2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            show = !show;

        if (show && Input.GetKeyUp(KeyCode.Space))
        {
            func2();
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

    private void func2()
    {
        Debug.Log(count);
        if (count < strings[arrayID].Length)
        {
            teksti = strings[arrayID][count];
            count++;
        }
        else
        {
            show = false;
            count = 0;
            arrayID = 0;
            teksti = "";
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "test1")
    //    {
    //        arrayID = 0;
    //    }

    //    if (col.gameObject.tag == "test2")
    //    {
    //        arrayID = 1;
    //    }
    //}
}