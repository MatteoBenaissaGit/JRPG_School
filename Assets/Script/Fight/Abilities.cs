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
