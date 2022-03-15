using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    public GameObject PlayerManagerObj;
    public GameObject AbilitiesObj;

    int _buttonCurrent;


    public void ClickScript()
    {
        for (int i = 0; i < AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList.Count; i++)
        {
            if ((AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList[i].WhichButton == _buttonCurrent) &&
                (AbilitiesObj.GetComponent<AbilitiesManager>().AbilitiesList[i].WhichPlayer == PlayerManagerObj.GetComponent<PlayerManager>().SelectedCharacter))
            {

            }
        }
    }

    public void OnClick0()
    {
        _buttonCurrent = 0;
        ClickScript();
    }

    public void OnClick1()
    {
        _buttonCurrent = 1;
        ClickScript();
    }

    public void OnClick2()
    {
        _buttonCurrent = 2;
        ClickScript();
    }
}
