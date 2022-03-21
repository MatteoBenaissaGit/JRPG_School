using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public GameObject PlayerManagerObj;
    public GameObject ButtonManagerObj;

    public List<Abilities> AbilitiesList;
    [HideInInspector] public List<Sprite> UpdatedButtonSprites;
    [HideInInspector] public List<bool> UpdatedCan;

    [HideInInspector] public int UpdatedHP;
    [HideInInspector] public int UpdatedEgo;

    public void Start()
    {
        for (int i = 0; i < AbilitiesList.Count; i++)
        {
            AbilitiesList[i].AbilityIndex = i;
        }
    }

    public void SetAbilities()
    {
        foreach (var i in AbilitiesList)
        {

        }
    }
    private Abilities GetAbilitiesByID(int id)
    {
        return null;
    }

    public void NewActiveSprites()
    {
        UpdatedButtonSprites.Clear();
        int charid = PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter;
        CharacterCombatAttributes character =  PlayerManagerObj.GetComponent<PlayerManager>().ListChars[charid];
        foreach (int abilityID in character.AbilityIDs)
        {
            Sprite sprite = GetAbilitiesByID(abilityID).ButtonSprite;
            UpdatedButtonSprites.Add(sprite);
        }
    }

    //public void NewActiveStats()
    //{
    //    for (int i = 0; i < AbilitiesList.Count; i++)
    //    {
    //        if ((AbilitiesList[i].PlayerIndex == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter) &&
    //             AbilitiesList[i].ButtonIndex == ButtonManagerObj.GetComponent<ButtonManager>().ButtonCurrent)
    //        {
    //            UpdatedHP = AbilitiesList[i].HealthChange;
    //            UpdatedEgo = AbilitiesList[i].EgoChange;

    //            UpdatedCan.Add(AbilitiesList[i].CanTargetAlly);
    //            UpdatedCan.Add(AbilitiesList[i].CanTargetHimself);
    //            UpdatedCan.Add(AbilitiesList[i].CanStun);

    //            //Debug.Log(UpdatedHP);
    //        }
    //    }
    //}
}
