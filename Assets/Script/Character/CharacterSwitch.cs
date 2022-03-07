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
    public List<CharactersAttribute> CharactersList;
    [HideInInspector] public List<AnimatorController> ControllersList;
    [HideInInspector] public List<string> NamesList;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        for (int i = 0; i < CharactersList.Count; i++)
        {
            ControllersList.Add(CharactersList[i].AnimatorController);
            NamesList.Add(CharactersList[i].Name);
        }
    }

    public void SwitchToNextCharacter()
    {
        ControllersList.Clear();
        NamesList.Clear();
        for (int i = 0; i < CharactersList.Count; i++)
        {
            ControllersList.Add((AnimatorController)CharactersList[i].Animator.runtimeAnimatorController);
            NamesList.Add(CharactersList[i].Name);
        }

        for (int i = 0; i < CharactersList.Count; i++)
        {
            int animatorNumber = SpriteChangeNumberGetter(i);
            CharactersList[i].Animator.runtimeAnimatorController = ControllersList[animatorNumber];
            CharactersList[i].AnimatorController = ControllersList[animatorNumber];
            CharactersList[i].Name = NamesList[animatorNumber];

            _logger.Log($"Change {i+1}/{CharactersList.Count} : Changing sprite {i} to sprite {animatorNumber}", this);
        }
    }

    private int SpriteChangeNumberGetter(int i)
    {
        int animatorNumber = i + 1;
        if (i + 1 >= CharactersList.Count)
            animatorNumber = 0;
        return animatorNumber;
    }
}
