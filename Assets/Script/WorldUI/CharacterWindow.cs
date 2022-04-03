using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWindow : MonoBehaviour
{
    [SerializeField] private GameObject _layout;
    [SerializeField] private GameObject _characterTagWindow;
    [SerializeField] private CharactersParametersList _characterParentParametersList;
    [SerializeField] private CharacterSwitch _character;
    [SerializeField] private CW_CommonInfos _cwCommonInfos;

    [HideInInspector] public List<GameObject> CharacterTagWindowList;

    private int _switchnumber = 0;

    private void OnEnable()
    {
        AddCharactersTagWindow();
    }

    private void Update()
    {
        if (enabled)
        {
            ChangeLeader();
            CheckClickInfo();
        }
    }

    private void AddCharactersTagWindow()
    {
        for (int i = 0; i < CharacterTagWindowList.Count; i++)
        {
            Destroy(CharacterTagWindowList[i]);
        }
        CharacterTagWindowList.Clear();
        for (int i = 0; i < _characterParentParametersList.CharactersListing.Count; i++)
        {
            GameObject characterTagWindow = Instantiate(_characterTagWindow, _layout.transform);
            CharacterTagWindowList.Add(characterTagWindow);
            characterTagWindow.GetComponent<CharacterTagWindow>().Name.text = _characterParentParametersList.CharactersListing[i].Name;
            characterTagWindow.GetComponent<CharacterTagWindow>().Icon.sprite = _characterParentParametersList.CharactersListing[i].Icon;
            characterTagWindow.GetComponent<CharacterTagWindow>().Life.fillAmount = _characterParentParametersList.CharactersListing[i].Life / 100;
            characterTagWindow.GetComponent<CharacterTagWindow>().CharacterWindow = gameObject.GetComponent<CharacterWindow>();
        }
    }

    public void ChangeLeader()
    {
        for (int i = 0; i < CharacterTagWindowList.Count; i++)
        {
            if (CharacterTagWindowList[i].GetComponent<CharacterTagWindow>().IsLeader)
            {
                for (int O = 0; O < i; O++)
                {
                    _character.SwitchToNextCharacter();
                    _cwCommonInfos.SwitchToNextCharacter();
                    if (_switchnumber < 2)
                        _switchnumber++;
                    else
                        _switchnumber = 0;

                }
                CharacterTagWindowList[i].GetComponent<CharacterTagWindow>().IsLeader = false;
                AddCharactersTagWindow();
            }
        }
    }

    public void CheckClickInfo()
    {
        for (int i = 0; i < CharacterTagWindowList.Count; i++)
        {
            if (CharacterTagWindowList[i].GetComponent<CharacterTagWindow>().IsClicked)
            {
                int nbchar = i + _switchnumber;
                if (nbchar > 2)
                    nbchar = nbchar%3;
                _cwCommonInfos.ShowCharacter(nbchar, i);
                CharacterTagWindowList[i].GetComponent<CharacterTagWindow>().IsClicked = false;
            }
        }
    }
}
