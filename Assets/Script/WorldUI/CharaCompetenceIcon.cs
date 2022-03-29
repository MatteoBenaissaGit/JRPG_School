using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharaCompetenceIcon : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Name;
    public bool IsClicked = false;
    private void OnMouseDown()
    {
        IsClicked = true;
    }
}
