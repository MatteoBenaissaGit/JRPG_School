using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CharacterHighlight : MonoBehaviour
{
    [Header("Which order is character (First = 0, Second = 1, etc...")]
    [SerializeField] private int _characternumber;
    [Header("----Referencing----")]
    [SerializeField] private CharacterController _characterController;
    [Header("----Highlight Tag----")]
    [SerializeField] private GameObject _highlightTagObject;
    [SerializeField] private float _tagHeight;
    private bool TagIsShowed = false;
    [Header("----Timer----")]
    [SerializeField] [Range(0.1f, 1.0f)] private float _timerToHighlight;
    private float _timer;
    [Header("----Debug----")]
    [SerializeField] private Logger _logger;


    private void Start()
    {
        _timer = _timerToHighlight;
    }
    private void OnMouseEnter()
    {
        _highlightTagObject.transform.DOComplete();
    }
    private void OnMouseOver()
    {
        _timer -= 0.01f;
        _highlightTagObject.transform.position = (Vector2)transform.position + new Vector2(0, _tagHeight);
        if (_timer <= 0 && !TagIsShowed && (Vector2)_characterController.transform.position == (Vector2)_characterController.GetComponent<NavMeshAgent>().destination)
        {
            _highlightTagObject.GetComponent<HighlightTag>().ShowHighlightTag(_characternumber);
            TagIsShowed = true;
        }
    }
    private void OnMouseExit()
    {
        TagIsShowed = false;
        _timer = _timerToHighlight;
        _highlightTagObject.GetComponent<HighlightTag>().HideHighlightTag();
    }

}
