using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> AbilitiesButtons;

    public GameObject AbilitiesObj;
    public GameObject PlayerManagerObj;

    public Sprite DefaultButtonSprite;

    public int ButtonCurrent;

    private void Start()
    {
        ResetDefaultSprites();
    }

    public void WhenButtonClicked()
    {
        AbilitiesObj.GetComponent<AbilitiesManager>().NewActiveStats();
        PlayerManagerObj.GetComponent<PlayerManager>().SetAttackMode();
    }

    public void ResetDefaultSprites()
    {
        foreach (var button in AbilitiesButtons)
        {
            button.image.sprite = DefaultButtonSprite;
        }
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
        WhenButtonClicked();
    }

    public void OnClick1()
    {
        ButtonCurrent = 1;
        WhenButtonClicked();
    }

    public void OnClick2()
    {
        ButtonCurrent = 2;
        WhenButtonClicked();
    }
}
