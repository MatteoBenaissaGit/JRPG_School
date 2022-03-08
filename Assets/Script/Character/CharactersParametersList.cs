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
    }
}
