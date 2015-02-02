using UnityEngine;
using System.Collections;

public class Potion : Item {

    private string potionName;
    private string potionDescription;
    private int potionID;

    public enum PotionTypes
    {
        HP,
        MANA
    }
    private PotionTypes potionType;

    public string PotionName
    {
        get { return potionName; }
        set { potionName = value; }
    }
    public string PotionDescription
    {
        get { return potionDescription; }
        set { potionDescription = value; }
    }
    public int PotionID
    {
        get { return potionID; }
        set { potionID = value; }
    }
    public PotionTypes PotionType
    {
        get { return potionType; }
        set { potionType = value; }
    }
}