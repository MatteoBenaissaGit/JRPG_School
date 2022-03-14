using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTagWindow : MonoBehaviour
{
    public Image Life;
    public TextMeshProUGUI Name;
    public Image Icon;
    [SerializeField] private GameObject _makeLeaderButton;

    [HideInInspector] public CharacterWindow CharacterWindow;
    [HideInInspector] public bool IsLeader;
    [HideInInspector] public bool IsClicked;

    [Header("Materials")]
    [SerializeField] private Material _materialOutline;
    [SerializeField] private Material _materialDefault;

    private void OnMouseDown()
    {
        IsClicked = true;
    }
    private void OnEnable()
    {
        _makeLeaderButton.SetActive(false);
    }
    private void OnMouseOver()
    {
        _makeLeaderButton.SetActive(true);
    }
    private void OnMouseExit()
    {
        _makeLeaderButton.SetActive(false);  
    }
    public void MakeLeaderButton()
    {
        IsLeader = true;
    }
    private void Outline()
    {
        GetComponent<SpriteRenderer>().material = _materialOutline;
    }
    private void UnOutline()
    {
        GetComponent<SpriteRenderer>().material = _materialDefault;
    }

}
