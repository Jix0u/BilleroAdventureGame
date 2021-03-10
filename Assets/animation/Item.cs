using System.Collections.Generic;
using UnityEngine;


public class Item
{
    public string itemType;
    public int amount;
    public Item(string itemType, int amount)
    {
        this.itemType = itemType;
        this.amount = amount;
    }
}