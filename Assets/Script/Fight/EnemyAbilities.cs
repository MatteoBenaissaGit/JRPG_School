using System;
using UnityEngine;

[Serializable]
public class EnemyAbilities
{
    public GameObject EnemyObject;
    public string Name;
    public int HP;
    public int Ego;
    public int Power;
    public int Eloquence;
    public Sprite EnemySprite;
    public SpriteRenderer EnemySpriteRenderer;
    [HideInInspector] public bool IsAlly = false;
}
