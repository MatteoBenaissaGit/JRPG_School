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

    private void OnEnable()
    {
        for (int i = 0; i < _charactersCompetenceList.Count; i++)
        {
            GameObject iconPrefab = Instantiate(_iconCharacterPrefab, _iconCharacterLayout);
            iconPrefab.GetComponent<Image>().sprite = _characterParent.CharactersListing[i].Icon;
            iconPrefab.GetComponent<TextMeshProUGUI>().name = _characterParent.CharactersListing[i].Name;
        }
    }

    void ShowCharacterCompetence(int characterNumber)
    {
        for (int i = 0; i < _charactersCompetenceList.Count; i++)
        {
            if (i != characterNumber)
                _charactersCompetenceList[i].SetActive(false);
            else
                _charactersCompetenceList[i].SetActive(true);
        }
    }
}
