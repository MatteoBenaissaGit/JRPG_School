using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class CharactersHighlight : MonoBehaviour
{
    [Header("----Referencing----")]
    [SerializeField] private CharacterSwitch _characterSwitch;
    [Header("----Highlight Tag----")]
    [SerializeField] private GameObject _highlightTagObject;
    [SerializeField] private float _tagHeight;
    [Header("----Debug----")]
    [SerializeField] private Logger _logger;

    private void OnMouseEnter()
    {
        for (int i = 0; i < _characterSwitch.CharactersList.Count; i++)
        {
            if (_characterSwitch.CharactersList[i].AnimatorController == this.GetComponent<Animator>().runtimeAnimatorController)
            {
                _highlightTagObject.transform.position = (Vector2)transform.position + new Vector2(0,_tagHeight);
                _highlightTagObject.GetComponent<HighlightTag>().ShowHighlightTag();
                _logger.Log($"Highlight {_characterSwitch.CharactersList[i].Name}",this);
                break;
            }
        }
    }
    private void OnMouseExit()
    {
        _highlightTagObject.GetComponent<HighlightTag>().HideHighlightTag();
    }

}
