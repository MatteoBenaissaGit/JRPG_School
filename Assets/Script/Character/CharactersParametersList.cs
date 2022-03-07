using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterParameter
{
    public string Name;
    public float Life;
    public Sprite Icon;
}
public class CharactersParametersList : MonoBehaviour
{
    public List<CharacterParameter> CharactersListing;
    [SerializeField] private CharacterSwitch _characterswitchlist;
    [SerializeField] private HighlightTag _highlightTag;

    public void UpdateCharactersInformations()
    {
        for (int i = 0; i < CharactersListing.Count; i++)
        {
            CharactersListing[i].Name = _characterswitchlist.CharactersList[i].Name;
            _highlightTag.Name.text = CharactersListing[i].Name;//faire en sorte de recupérer le numéro de celui qu'on affiche pour pouvoir mettre le bon nom
            //CharactersListing[i].Life = ?;
            _highlightTag.Icon.sprite = CharactersListing[i].Icon;
        }
    }
}
