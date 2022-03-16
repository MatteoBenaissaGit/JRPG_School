using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> AbilitiesButtons;

 
    public GameObject AbilitiesObj;

    int _buttonCurrent;


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
        _buttonCurrent = 0;
        ClickFunction();
    }

    public void OnClick1()
    {
        _buttonCurrent = 1;
        ClickFunction();
    }

    public void OnClick2()
    {
        _buttonCurrent = 2;
        ClickFunction();
    }
}
