using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public enum Items //keep the same as in CharaceterInventory
    {
        sword = 0,
        key = 1,
        rule = 2,
        shield = 3,
        health_potion = 4
    }
    [Header("variables")]
    public Items Item;
    public Image Image;
    public TextMeshProUGUI Number;
    public bool IsUsable;

    [HideInInspector] public bool IsRightClicked = false;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
            RightClicked();
    }

    private void OnMouseExit()
    {
        IsRightClicked = false;
    }

    public void RightClicked()
    {
        IsRightClicked = true;
    }
}
