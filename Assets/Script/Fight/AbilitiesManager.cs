using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public List<Abilities> AbilitiesList;
    public GameObject PlayerManagerObj;

    [HideInInspector] public List<Sprite> UpdatedButtonSprites;
    [HideInInspector] public List<int> UpdatedStats;
    //[HideInInspector] public bool UpdatedCanTargetAlly;
    //[HideInInspector] public bool UpdatedCanTargetHimself;
    //[HideInInspector] public bool UpdatedCanStun;

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
        UpdatedStats.Clear();

        for (int i = 0; i < UpdatedStats.Count; i++)
        {
            if (AbilitiesList[i].WhichPlayer == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter)
            {
                UpdatedStats.Add(AbilitiesList[i].HealthChange);
            }
        }
    }

    //public void ClickFunction()
    //{
    //    for (int i = 0; i < AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList.Count; i++)
    //    {
    //        if ((AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList[i].WhichButton == _buttonCurrent) &&
    //            (AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList[i].WhichPlayer == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter))
    //        {

    //        }
    //    }
    //}
}
