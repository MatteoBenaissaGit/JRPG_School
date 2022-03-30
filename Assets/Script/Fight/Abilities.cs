using System;
using UnityEngine;

[Serializable]
public class Abilities
{
    public string AbilityName;
    public int HealthChange;
    public int EgoChange;
    public bool CanTargetAlly;
    public bool CanTargetHimself;
    public bool CanStun;
    public Sprite ButtonSprite;
    [HideInInspector] public int AbilityIndex;
}
