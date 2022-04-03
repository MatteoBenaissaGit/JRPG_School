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
    [SerializeField] private Image _exeperience;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _ego;
    [SerializeField] private TextMeshProUGUI _eloquence;
    [SerializeField] private TextMeshProUGUI _puissance;
    [Header("Character Parent Referencing")]
    [SerializeField] private CharactersParametersList _characterParameterList;

    [HideInInspector] public List<GameObject> CharactersAnims;

    private void OnEnable()
    {
        for (int i = 0; i < CharactersInfosList.Count; i++)
        {
            CharactersAnims.Add(CharactersInfosList[i].CharactersAnim);
            CharactersInfosList[i].CharactersAnim.SetActive(false);
        }
        UpdateCharacterCommonInfos(0, 0);

    }

    public void ShowCharacter(int characterNumber, int inumber)
    {
        UpdateCharacterCommonInfos(characterNumber, inumber);
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

    private void UpdateCharacterCommonInfos(int characterNumber, int i)
    {
        CharactersInfosList[characterNumber].CharactersAnim.SetActive(true);
        _name.text = _characterParameterList.CharactersListing[i].Name;
        _icon.sprite = _characterParameterList.CharactersListing[i].Icon;
        _life.fillAmount = _characterParameterList.CharactersListing[i].Life / 100;
        _level.text = _characterParameterList.CharactersListing[characterNumber].Level.ToString();
        _exeperience.fillAmount = _characterParameterList.CharactersListing[characterNumber].ExperiencePoint / _characterParameterList.CharactersListing[characterNumber].ExperiencePointToUpgrade;
        //Stats
        _ego.text = "Ego : " + _characterParameterList.CharactersListing[characterNumber].Ego.ToString();
        _eloquence.text = "Eloquence : " + _characterParameterList.CharactersListing[characterNumber].Eloquence.ToString();
        _puissance.text = "Puissance : " + _characterParameterList.CharactersListing[characterNumber].Puissance.ToString();
    }
}
