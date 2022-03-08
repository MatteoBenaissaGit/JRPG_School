using System;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public string Name;
    public int HP;
    public int Damage;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
    public bool IsCharaActive;

    public Material MaterialOutline;
    public Material MaterialDefault;

    public GameObject CharacterUI;
    public void Outline()
    {
        CharacterUI.GetComponent<SpriteRenderer>().material = MaterialOutline;
    }

    public void UnOutline()
    {
        CharacterUI.GetComponent<SpriteRenderer>().material = MaterialDefault;
    }
}

