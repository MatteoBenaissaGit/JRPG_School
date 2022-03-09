using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HighlightTag : MonoBehaviour
{
    [Header("Highlight Tag Elements Referecing")]
    public Image Icon;
    public TextMeshProUGUI Name;
    public Image Life;
    public Image Background;

    [Header("Effect Variables")]
    [SerializeField] [Range(0.1f,3.0f)] private float _scaleMultiplicator;
    [SerializeField] [Range(0.1f, 1.0f)] private float _scaleDuration;

    [Header("Character's parameter List")]
    [SerializeField] private CharactersParametersList _charactersParameterList;

    [Header("Character's parameter List")]
    [SerializeField] private Logger _logger;

    private void Awake()
    {
        transform.localScale = Vector3.zero;    
    }

    public void ShowHighlightTag(int character_number)
    {
        _charactersParameterList.UpdateTagInformations(character_number);
        transform.DOScale(new Vector3(_scaleMultiplicator, _scaleMultiplicator, _scaleMultiplicator), _scaleDuration);
    }
    public void HideHighlightTag()
    {
        transform.DOKill();
        transform.DOScale(Vector3.zero, _scaleDuration/2);
    }
}
