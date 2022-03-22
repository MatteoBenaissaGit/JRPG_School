using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public GameObject PlayerManagerObj;
    public GameObject EnemyManagerObj;
    public GameObject ButtonManagerObj;

    public List<Abilities> AbilitiesList;

    [HideInInspector] public List<Sprite> UpdatedButtonSprites;

    //[HideInInspector] public bool UpdatedCanTargetAlly;
    //[HideInInspector] public bool UpdatedCanTargetHimself;
    //[HideInInspector] public bool UpdatedCanStun;

    [HideInInspector] public int UpdatedHP;
    [HideInInspector] public int UpdatedEgo;

    public void Start()
    {
        for (int i = 0; i < AbilitiesList.Count; i++)
        {
            AbilitiesList[i].AbilityIndex = i;
        }
    }

    private Abilities GetAbilitiesByID(int id)
    {
       return AbilitiesList[id];
    }

    public void NewButtonSprites()
    {
        UpdatedButtonSprites.Clear();

        int charid = PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID;
        CharacterCombatAttributes character =  PlayerManagerObj.GetComponent<PlayerManager>().ListChars[charid];

        foreach (int abilityID in character.AbilityIDs)
        {
            Sprite sprite = GetAbilitiesByID(abilityID).ButtonSprite;
            UpdatedButtonSprites.Add(sprite);
        }
    }
    public void NewActiveStats()
    {
        if (PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID < 0)
        {
            int charid = PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID;
            CharacterCombatAttributes character = PlayerManagerObj.GetComponent<PlayerManager>().ListChars[charid];

            foreach (int abilityID in character.AbilityIDs)
            {
                if (ButtonManagerObj.GetComponent<ButtonManager>().ButtonCurrent == GetAbilitiesByID(abilityID).ButtonIndex)
                {
                    UpdatedHP = character.HP + GetAbilitiesByID(abilityID).HealthChange;
                    UpdatedEgo = character.Ego + GetAbilitiesByID(abilityID).EgoChange;
                }
            }
        }

        //if (PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID < 0)
        //{
        //    int charid = PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacterID;
        //    CharacterCombatAttributes character = PlayerManagerObj.GetComponent<PlayerManager>().ListChars[charid];

        //    foreach (int abilityID in character.AbilityIDs)
        //    {
        //        if (ButtonManagerObj.GetComponent<ButtonManager>().ButtonCurrent == GetAbilitiesByID(abilityID).ButtonIndex)
        //        {
        //            UpdatedHP = character.HP + GetAbilitiesByID(abilityID).HealthChange;
        //            UpdatedEgo = character.Ego + GetAbilitiesByID(abilityID).EgoChange;
        //        }
        //    }
        //}
    }
}
