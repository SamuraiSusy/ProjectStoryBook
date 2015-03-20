using UnityEngine;
using System.Collections;

public class MessagePlaceholders : MonoBehaviour
{
    public string[][] dialogues;
    public string[] dialogue;
    public string[] dialogue2;

    public string[][] choises;
    public string[] dialogue2Yes, dialogue2No;

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
        choises = new string[2][];

        choises[0] = dialogue2Yes;
        choises[1] = dialogue2No;
    }

    private void SetDialogue()
    {
        // always left one empty string at the end
        dialogue = new string[]
        {
            "lol",
            "moi",
            "terve",
            "heippa",
            "moikka",
            "xd",
            "derp",
            "herp",
            "rofl",
            "kappa",
            "i",
            "h",
            "g",
            "f",
            "e",
            "d",
            "c",
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
            "pitais tasa koht keksii joku loppukyssari et voi testat valikkoi,",
            "mut oon tosi huono keksii nait.",
            "mut kyl taa mun mielest demonstroi aika hyval taval.",
            "mita mielta sina olet?",
            "naa aakkoset o nii kivoi ilma aakkosii",
            "lol",
            "onko koodari menettanyt jarkensa?",
            "$"
        };

        dialogue2Yes = new string[]
        {
            "vastasit sitte kylla",
            "se o iha ok juttu"
        };

        dialogue2No = new string[]
        {
            "jaa ei vai",
            "noh ok sitte...",
            "en oo vihane tai mtn :("
        };
    }
}