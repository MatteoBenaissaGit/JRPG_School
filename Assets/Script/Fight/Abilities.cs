using System;
using UnityEngine;

[Serializable]
public class Abilities
{
    public string AbilityName;
    public int WhichPlayer;
    public int WhichButton;
    public int HealthChange;
    public int EgoChange;
    public int PowerChange;
    public int EloquenceChange;
    public bool CanTargetAlly;
    public bool CanTargetHimself;
    public bool CanStun;
    public Sprite ButtonSprite;
}

public class CurrentAbilities
{
    public string CurrentAbilityName;
    public int CurrentWhichPlayer;
    public int CurrentWhichButton;
    public int CurrentHealthChange;
    public int CurrentEgoChange;
    public int CurrentPowerChange;
    public int CurrentEloquenceChange;
    public bool CurrentCanTargetAlly;
    public bool CurrentCanTargetHimself;
    public bool CurrentCanStun;
    public Sprite ButtonSprite;
}
