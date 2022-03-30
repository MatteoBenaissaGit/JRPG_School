using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompetenceIcon : MonoBehaviour
{
    [Header("Infos")]
    public GameObject Infos;
    [Header("Subobjects Referencing")]
    public Image Icon;
    public GameObject SingleLine;
    public GameObject DoubleLine;
    public GameObject RightLine;
    public GameObject LeftLine;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public GameObject LockedText;
    public GameObject UnlockedText;

    private void Start()
    {
        Infos.SetActive(false);
    }
    private void OnMouseEnter()
    {
        Infos.SetActive(true);
    }
    private void OnMouseExit()
    {
        Infos.SetActive(false);
    }
}
