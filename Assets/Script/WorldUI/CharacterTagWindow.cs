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

    public void MakeLeaderButton()
    {
        IsLeader = true;
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
}
