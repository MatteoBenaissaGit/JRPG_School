using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> AbilitiesButtons;

 
    public GameObject AbilitiesObj;

    public int ButtonCurrent;


    public void ClickFunction()
    {
        AbilitiesObj.GetComponent<AbilitiesManager>().NewActiveStats();
    }

    public void UpdateSprites()
    {
        for (int i = 0; i < AbilitiesButtons.Count; i++)
        {
            AbilitiesButtons[i].image.sprite = AbilitiesObj.GetComponent<AbilitiesManager>().UpdatedButtonSprites[i];
        }
    }

    public void OnClick0()
    {
        ButtonCurrent = 0;
        ClickFunction();
    }

    public void OnClick1()
    {
        ButtonCurrent = 1;
        ClickFunction();
    }

    public void OnClick2()
    {
        ButtonCurrent = 2;
        ClickFunction();
    }
}
