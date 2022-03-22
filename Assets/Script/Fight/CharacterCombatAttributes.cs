using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public GameObject CharacterObject;
    public string Name;
    public bool IsAlly;
    public int HP;
    public int Ego;
    public int Power;
    public int Eloquence;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
    public List<int> AbilityIDs;
}

