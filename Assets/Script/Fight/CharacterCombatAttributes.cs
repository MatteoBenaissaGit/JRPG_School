using System;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public GameObject Object;
    public string Name;
    public int HP;
    public int Damage;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
    public bool IsCharaActive;
}

