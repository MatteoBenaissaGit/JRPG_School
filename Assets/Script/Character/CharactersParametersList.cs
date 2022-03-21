using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterParameter
{
    public string Name;
    public float Life;
    public int Level = 0;
    public float ExperiencePoint;
    public float ExperiencePointToUpgrade;
    public Sprite Icon;
    public Animator Animator;
    public AnimatorController AnimatorController;
}
public class CharactersParametersList : MonoBehaviour
{
    public List<CharacterParameter> CharactersListing;
    [SerializeField] private HighlightTag _highlightTag;

    public void UpdateTagInformations(int character_number)
    {
        _highlightTag.Name.text = CharactersListing[character_number].Name;
        _highlightTag.Life.fillAmount = CharactersListing[character_number].Life/100;
        _highlightTag.Icon.sprite = CharactersListing[character_number].Icon;
        _highlightTag.Experience.fillAmount = CharactersListing[character_number].ExperiencePoint/CharactersListing[character_number].ExperiencePointToUpgrade;
        _highlightTag.Level.text = CharactersListing[character_number].Level.ToString();
    }

    public void AddExperience(int character_number, int experience)
    {
        CharactersListing[character_number].ExperiencePoint += experience;

        if (CharactersListing[character_number].ExperiencePoint >= CharactersListing[character_number].ExperiencePointToUpgrade)
        {
            CharactersListing[character_number].ExperiencePoint -= CharactersListing[character_number].ExperiencePointToUpgrade;
            CharactersListing[character_number].ExperiencePointToUpgrade = (int)(CharactersListing[character_number].ExperiencePointToUpgrade * 1.5f);
            CharactersListing[character_number].Level++;
        }
    }

    public void TESTEXP()
    {
        AddExperience(0, 1);
    }
}
