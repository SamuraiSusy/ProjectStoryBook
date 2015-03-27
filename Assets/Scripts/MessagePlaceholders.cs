using UnityEngine;
using System.Collections;

public class MessagePlaceholders : MonoBehaviour
{
    public string[][] dialogues;
    public string[] dialogue;
    public string[] dialogue2;

    // if you only have 2 choises, there is a bug
    // where the player presses 4 buttons
    public string[][] choises;
    public string[] dialogue2Yes, dialogue2No;
    public string[] yesserino, noperino;

    // remember to set up the arrays!
    private void Awake()
    {
        SetDialogue();
        SetDialogue2();
        SetUpDialogues();
        SetUpChoises();
    }

    private void SetUpDialogues()
    {
        dialogues = new string[2][];

        dialogues[0] = dialogue;
        dialogues[1] = dialogue2;
    }

    private void SetUpChoises()
    {
        choises = new string[4][];

        choises[0] = dialogue2Yes;
        choises[1] = dialogue2No;
        choises[2] = yesserino;
        choises[3] = noperino;
    }

    private void SetDialogue()
    {
        // always left one empty string at the end
        dialogue = new string[]
        {
            "lol",
            "moi",
            "terve",
            "b",
            "a",
            ""
        };
    }

    private void SetDialogue2()
    {
        // if after a dialogue is yes/no alternatives,
        // mark the last string to $
        dialogue2 = new string[]
        {
            "olen erittain innoissani uudesta digimon animesta.",
            "olethan kuullut moisesta upeasta ihmeesta?",
            "annie botilla on havioputki paalla.",
            "en oo seurannu niin tarkaa et tietaisin miks niin on.",
            "kyl taa placeholderie kirjottamine o nii kivvaa hommaa..",
            "$"
        };

        dialogue2Yes = new string[]
        {
            "vastasit sitte kylla",
            "se o iha ok juttu",
            ""
        };

        dialogue2No = new string[]
        {
            "jaa ei vai",
            "noh ok sitte...",
            "en oo vihane tai mtn :(",
            ""
        };

        yesserino = new string[]
        {
            "lolo",
            "jojo",
            ""
        };

        noperino = new string[]
        {
            "loporo",
            "nopero",
            ""
        };
    }
}