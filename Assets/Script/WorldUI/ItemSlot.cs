using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public enum Items //keep the same as in CharaceterInventory
    {
        dictionnaire = 0,
        monocle = 1,
        pull_de_promo = 2,
        telephone = 3,
        mot_doux = 4,
        mirroir = 5,
        cosmetique = 6,
        règle_en_métal = 7,
        tazer = 8,
        lampe_torche = 9,
    }
    [Header("variables")]
    public Items Item;
    public Image Image;
    public TextMeshProUGUI Number;
    public string Description;
    public bool IsUsable;

    [HideInInspector] public bool IsRightClicked = false;

    [SerializeField] private GameObject _descriptionBox;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;

    private void Start()
    {
        _name.text = Item.ToString();
        _description.text = Description;
        _descriptionBox.SetActive(false);
    }

    private void OnMouseOver()
    {
        _descriptionBox.SetActive(true);

        if (Input.GetMouseButtonDown(1))
            RightClicked();
    }

    private void OnMouseExit()
    {
        _descriptionBox.SetActive(false);

        IsRightClicked = false;
    }

    public void RightClicked()
    {
        IsRightClicked = true;
    }
}
