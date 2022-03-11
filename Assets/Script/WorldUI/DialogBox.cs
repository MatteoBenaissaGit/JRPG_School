using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogBox : MonoBehaviour
{
    [Header("Self-Referencing")]
    public Image Image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Dialog;
    [Header("Variables")]
    [SerializeField] [Range(0.01f,2f)] private float _timeToEnableDialogBox;
    [SerializeField] private Vector2 _punchAnimForce;
    [SerializeField] [Range(0.01f,1f)] private float _punchAnimTime;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void UpdateDialogBoxInfos(bool disableOrNot, string name, string dialog, Sprite icon)
    {
        Image.sprite = icon;
        Name.text = name;
        Dialog.text = dialog;
        if (transform.localScale != Vector3.zero)
            transform.DOPunchScale(_punchAnimForce, _punchAnimTime);
    }

    public void EnableDialogBox(bool disableOrNot, string name, string dialog, Sprite icon)
    {
        UpdateDialogBoxInfos(disableOrNot, name,  dialog, icon);
        transform.DOComplete();
        transform.DOScale(1, _timeToEnableDialogBox);
        if (disableOrNot)
            StartCoroutine(DisableDialogBox(3f));
    }
    public IEnumerator DisableDialogBox(float timeToDisableBox)
    {
        yield return new WaitForSeconds(timeToDisableBox);
        transform.DOComplete();
        transform.DOScale(0, _timeToEnableDialogBox/2);
    }
}
