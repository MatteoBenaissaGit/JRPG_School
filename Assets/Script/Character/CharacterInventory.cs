using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public enum Items
    {
        sword = 0,
        key = 1,
        rule = 2,
        shield = 3,
        health_potion = 4
    }
    public Items item;
    public int numberOfItem;
}
public class CharacterInventory : MonoBehaviour
{
    public List<Item> ItemList;
}
