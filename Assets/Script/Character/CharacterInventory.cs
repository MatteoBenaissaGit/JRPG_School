using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemCharacteristic
{
    public enum Items
    {
        dictionnaire = 0,
        monocle = 1,
        pull_de_promo = 2,
        telephone = 3,
        mot_doux = 4,
        mirroir = 5,
        cosmetique = 6,
        règle_en_métal = 7,
        tazer = 8,
        lampe_torche = 9,
    }
    public Items Item;
    public string Description;
    public int NumberOfItem;
    public Sprite InventorySprite;
    public Sprite InGameSprite;
    public bool IsUsable;
}
public class CharacterInventory : MonoBehaviour
{
    [Header("Sprite List")]
    public List<ItemCharacteristic> ItemList;
}
