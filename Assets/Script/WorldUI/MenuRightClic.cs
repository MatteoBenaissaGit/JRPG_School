using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRightClic : MonoBehaviour
{
    [Header("Button referencing")]
    [SerializeField] private Button _throwOne;
    [SerializeField] private Button _throwAll;
    [SerializeField] private Button _use;
    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _throwOne.interactable = true;
        _throwAll.interactable = true;
        _use.interactable = true;
    }

    private void OnMouseExit()
    {
        gameObject.SetActive(false);
    }

    public void UpdateRightClickInfos(int numberOfItem, bool IsUsable)
    {
        _logger.Log($"RightClickMenu Enabled", this);
        _logger.Log($"{numberOfItem} of this item that are usable : {IsUsable}", this);
        transform.position = Vector3.Scale(Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition), new Vector3(1,1,0));      
        if (numberOfItem <= 0)
        {
            _throwOne.interactable = false;
            _throwAll.interactable = false;
        }
        if (!IsUsable)
            _use.interactable = false;
        gameObject.SetActive(true);
    }
}
