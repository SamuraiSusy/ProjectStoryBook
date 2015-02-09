using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        // create all the items of the game here, remember to change id
        items.Add(new Item("Small Potion", 0, "A small potion", Item.ItemTypes.CONSUMABLE));
        items.Add(new Item("Old Book", 1, "An old book found on the ground", Item.ItemTypes.INFORMATIVE));
        items.Add(new Item("Smiley Face", 2, "It smiles to you", Item.ItemTypes.PUZZLE));
        items.Add(new Item("Odd Smile", 3, "It's a funny looking smile face", Item.ItemTypes.PUZZLE));
        items.Add(new Item("Creepy Smile", 4, "It's a really creepy looking face", Item.ItemTypes.PUZZLE));
    }
}