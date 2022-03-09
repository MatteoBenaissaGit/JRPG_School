using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemCharacteristic
{
    public enum Items
    {
        sword = 0,
        key = 1,
        rule = 2,
        shield = 3,
        health_potion = 4
    }
    public Items Item;
    public int NumberOfItem;
    public Sprite Sprite;
}
public class CharacterInventory : MonoBehaviour
{
    [Header("Sprite List")]
    public List<Sprite> Sprites;
    public List<ItemCharacteristic> ItemList;
}
