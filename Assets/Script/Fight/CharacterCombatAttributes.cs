using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public GameObject CharacterObject;
    public string Name;
    public int HP;
    public int Ego;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
    public List<int> AbilityIDs;
}

