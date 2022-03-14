using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

[Serializable]
public class CharactersCommonInfos
{
    public GameObject CharactersAnim;
}
public class CW_CommonInfos : MonoBehaviour
{
    [Header("CharactersInfosList")]
    public List<CharactersCommonInfos> CharactersInfosList;
    [Header("Self referencing")]
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _life;
    [SerializeField] private Image _icon;
    [Header("Character Parent Referencing")]
    [SerializeField] private CharactersParametersList _characterParameterList;

    [HideInInspector] public List<GameObject> CharactersAnims;

    private void Start()
    {
        for (int i = 0; i < CharactersInfosList.Count; i++)
        {
            CharactersAnims.Add(CharactersInfosList[i].CharactersAnim);
            CharactersInfosList[i].CharactersAnim.SetActive(false);
        }
        CharactersInfosList[0].CharactersAnim.SetActive(true);
        _name.text = _characterParameterList.CharactersListing[0].Name;
        _icon.sprite = _characterParameterList.CharactersListing[0].Icon;
        _life.fillAmount = _characterParameterList.CharactersListing[0].Life / 100;
    }

    public void ShowCharacter(int characterNumber)
    {
        CharactersInfosList[characterNumber].CharactersAnim.SetActive(true);
        _name.text = _characterParameterList.CharactersListing[characterNumber].Name;
        _icon.sprite = _characterParameterList.CharactersListing[characterNumber].Icon;
        _life.fillAmount = _characterParameterList.CharactersListing[characterNumber].Life/100;
        for (int i = 0; i < CharactersInfosList.Count; i++)
        {
            if (i!=characterNumber)
                CharactersInfosList[i].CharactersAnim.SetActive(false);
        }
    }

    public void SwitchToNextCharacter()
    {
        CharactersAnims.Clear();
        for (int i = 0; i < CharactersInfosList.Count; i++)
        {
            CharactersAnims.Add(CharactersInfosList[i].CharactersAnim);
        }

        for (int i = 0; i < CharactersInfosList.Count; i++)
        {
            int animatorNumber = SpriteChangeNumberGetter(i);
            CharactersInfosList[i].CharactersAnim = CharactersAnims[animatorNumber];
        }
    }
    private int SpriteChangeNumberGetter(int i)
    {
        int animatorNumber = i + 1;
        if (i + 1 >= CharactersInfosList.Count)
            animatorNumber = 0;
        return animatorNumber;
    }
}
