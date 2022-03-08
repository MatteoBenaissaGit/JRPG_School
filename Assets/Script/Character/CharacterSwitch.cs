using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[Serializable]
public class CharactersAttribute
{
    public string Name;
    public Animator Animator;
    public AnimatorController AnimatorController;
}
public class CharacterSwitch : MonoBehaviour
{
    [SerializeField] private CharactersParametersList _characterParametersList;
    [HideInInspector] public List<AnimatorController> ControllersList;
    [HideInInspector] public List<string> NamesList;
    [HideInInspector] public List<Sprite> IconList;
    [HideInInspector] public List<float> LifeList;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        for (int i = 0; i < _characterParametersList.CharactersListing.Count; i++)
        {
            ControllersList.Add(_characterParametersList.CharactersListing[i].AnimatorController);
            NamesList.Add(_characterParametersList.CharactersListing[i].Name);
            IconList.Add(_characterParametersList.CharactersListing[i].Icon);
            LifeList.Add(_characterParametersList.CharactersListing[i].Life);
        }
    }

    public void SwitchToNextCharacter()
    {
        ControllersList.Clear();
        NamesList.Clear();
        IconList.Clear();
        LifeList.Clear();
        for (int i = 0; i < _characterParametersList.CharactersListing.Count; i++)
        {
            ControllersList.Add((AnimatorController)_characterParametersList.CharactersListing[i].Animator.runtimeAnimatorController);
            NamesList.Add(_characterParametersList.CharactersListing[i].Name);
            IconList.Add(_characterParametersList.CharactersListing[i].Icon);
            LifeList.Add(_characterParametersList.CharactersListing[i].Life);
        }

        for (int i = 0; i < _characterParametersList.CharactersListing.Count; i++)
        {
            int animatorNumber = SpriteChangeNumberGetter(i);
            _characterParametersList.CharactersListing[i].Animator.runtimeAnimatorController = ControllersList[animatorNumber];
            _characterParametersList.CharactersListing[i].AnimatorController = ControllersList[animatorNumber];
            _characterParametersList.CharactersListing[i].Name = NamesList[animatorNumber];
            _characterParametersList.CharactersListing[i].Icon = IconList[animatorNumber];
            _characterParametersList.CharactersListing[i].Life = LifeList[animatorNumber];

            _logger.Log($"Change {i+1}/{_characterParametersList.CharactersListing.Count} : Changing sprite {i} to sprite {animatorNumber}", this);
        }
    }

    private int SpriteChangeNumberGetter(int i)
    {
        int animatorNumber = i + 1;
        if (i + 1 >= _characterParametersList.CharactersListing.Count)
            animatorNumber = 0;
        return animatorNumber;
    }
}
