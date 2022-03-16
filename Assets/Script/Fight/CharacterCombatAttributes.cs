using System;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public GameObject CharacterObject;
    public string Name;
    public int HP;
    public int Ego;
    public int Power;
    public int Eloquence;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
}

