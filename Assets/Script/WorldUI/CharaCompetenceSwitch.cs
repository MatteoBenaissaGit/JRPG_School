using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharaCompetenceSwitch : MonoBehaviour
{

    [Header("Characters Competence Windows List")] 
    [SerializeField] private List<GameObject> _charactersCompetenceList;
    [Header("Referencing")]
    [SerializeField] private Transform _iconCharacterLayout;
    [SerializeField] private GameObject _iconCharacterPrefab;
    [Header("Character Parent Referencing")]
    [SerializeField] private CharactersParametersList _characterParent;

    private List<GameObject> _iconsList = new List<GameObject>();

    private void OnEnable()
    {
        ShowCharacterCompetence(0);
        for (int i = 0; i < _iconsList.Count; i++)
        {
            Destroy(_iconsList[i]);
        }
        _iconsList.Clear();
        for (int i = 0; i < _charactersCompetenceList.Count; i++)
        {
            GameObject iconPrefab = Instantiate(_iconCharacterPrefab, _iconCharacterLayout);
            _iconsList.Add(iconPrefab);
            iconPrefab.GetComponent<CharaCompetenceIcon>().Icon.sprite = _characterParent.CharactersListing[i].Icon;
            iconPrefab.GetComponent<CharaCompetenceIcon>().Name.text = _characterParent.CharactersListing[i].Name;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _charactersCompetenceList.Count; i++)
        {
            if (_iconsList[i].GetComponent<CharaCompetenceIcon>().IsClicked)
            {
                ShowCharacterCompetence(i);
                _iconsList[i].GetComponent<CharaCompetenceIcon>().IsClicked = false;
            }
        }
    }

    void ShowCharacterCompetence(int characterNumber)
    {
        for (int i = 0; i < _charactersCompetenceList.Count; i++)
        {
            if (i != characterNumber)
                _charactersCompetenceList[i].SetActive(false);
            else
            {
                _charactersCompetenceList[i].SetActive(true);
            }
        }
    }
}
