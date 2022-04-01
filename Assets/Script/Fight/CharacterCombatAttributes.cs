using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterCombatAttributes
{
    public GameObject CharacterObject;
    public Bars CharaHealthBar;
    public Bars CharaEgoBar;
    public string Name;
    public int HP;
    public int Ego;
    public int Power;
    public int Eloquence;
    public int CriticalPercentage;
    public Sprite CombatSprite;
    public SpriteRenderer CombatSpriteRenderer;
    public bool HasPlayed;
    public bool IsStuned;
    public List<int> AbilityIDs;
    
    [HideInInspector] public bool IsDead;
    [HideInInspector] public int StartEgo;
    [HideInInspector] public int StartHP;
}

