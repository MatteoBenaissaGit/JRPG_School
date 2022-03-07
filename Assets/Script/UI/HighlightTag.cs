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
    [SerializeField] private float _scaleMultiplicator;
    [SerializeField] private float _scaleDuration;

    [Header("Character's parameter List")]
    [SerializeField] private CharactersParametersList _charactersParameterList;

    private void Awake()
    {
        transform.localScale = Vector3.zero;    
    }

    public void ShowHighlightTag()
    {
        _charactersParameterList.UpdateCharactersInformations();
        transform.DOScale(new Vector3(_scaleMultiplicator, _scaleMultiplicator, _scaleMultiplicator), _scaleDuration);
    }
    public void HideHighlightTag()
    {
        transform.DOScale(Vector3.zero, _scaleDuration);
    }
}
