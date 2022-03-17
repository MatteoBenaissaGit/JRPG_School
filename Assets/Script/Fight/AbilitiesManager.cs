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
    [HideInInspector] public int UpdatedPower;
    [HideInInspector] public int UpdatedEloquence;
    


    public void NewActiveSprites()
    {
        UpdatedButtonSprites.Clear();

        for (int i = 0; i < AbilitiesList.Count; i++)
        {
            if (AbilitiesList[i].WhichPlayer == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter)
            {
                UpdatedButtonSprites.Add(AbilitiesList[i].ButtonSprite);
            }
        }
    }

    public void NewActiveStats()
    {
        for (int i = 0; i < AbilitiesList.Count; i++)
        {
            if ((AbilitiesList[i].WhichPlayer == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter) && 
                 AbilitiesList[i].WhichButton == ButtonManagerObj.GetComponent<ButtonManager>().ButtonCurrent)
            {
                UpdatedHP = AbilitiesList[i].HealthChange;
                UpdatedEgo = AbilitiesList[i].EgoChange;
                UpdatedPower = AbilitiesList[i].PowerChange;
                UpdatedEloquence = AbilitiesList[i].EloquenceChange;

                UpdatedCan.Add(AbilitiesList[i].CanTargetAlly);
                UpdatedCan.Add(AbilitiesList[i].CanTargetHimself);
                UpdatedCan.Add(AbilitiesList[i].CanStun);

                //Debug.Log(UpdatedHP);
            }
        }
    }
}
