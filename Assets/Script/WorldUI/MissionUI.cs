using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MissionUI : MonoBehaviour
{
    [Header("Referencing")]
    public TextMeshProUGUI MissionName;
    public TextMeshProUGUI MissionDescription;
    public GameObject MissionInfos;

    private bool _isOver = false;
    private float _moveDistance = 150;
    private float basY;

    private void Start()
    {
        basY = transform.localPosition.y;
    }

    private void OnMouseEnter()
    {
        if (!_isOver)
        {
            MissionInfos.transform.DOComplete();
            basY = transform.localPosition.y;
            MissionInfos.transform.DOLocalMoveY(transform.localPosition.y + _moveDistance, 1);
            _isOver = true;
        }
    }
    private void OnMouseExit()
    {
        if (_isOver)
        {
            MissionInfos.transform.DOComplete();
            MissionInfos.transform.DOLocalMoveY(basY, 1);
            _isOver = false;
        }
    }
}
