using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPrefab : MonoBehaviour
{
    private enum ItemList //keep the same as ItemList in CharacterInventory
    {
        sword = 0,
        key = 1,
        rule = 2,
        shield = 3,
        health_potion = 4
    }
    [Header("Materials")]
    [SerializeField] private Material _materialOutline;
    [SerializeField] private Material _materialDefault;
    [Header("Referencing")]
    [SerializeField] private ItemList _itemnumber;
    [SerializeField] private GameObject _character;
    [SerializeField] private CharacterInventory _characterInventory;
    [SerializeField] private GameObject _getSymbol;
    [SerializeField] private TextMeshPro _numberText;
    [Header("Variables")]
    [SerializeField] private int _quantity;


    private float _distanceToCollect = 2;
    private bool _canBeCollected = false;

    private void Start()
    {
        _numberText.text = _quantity.ToString();
        _getSymbol.SetActive(false);
    }
    private void Update()
    {
        DistanceCheck();
        CollectItem();
    }

    private void DistanceCheck()
    {
        float dist = Vector3.Distance(_character.transform.position, transform.position);
        if (dist < _distanceToCollect)
        {
            Outline();
            _getSymbol.SetActive(true);
            _canBeCollected = true;
        }
        else
        {
            UnOutline();
            _getSymbol.SetActive(false);
            _canBeCollected = false;
        }
    }

    private void CollectItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canBeCollected)
        {
            _characterInventory.ItemList[(int)_itemnumber].NumberOfItem += _quantity;
            Destroy(gameObject);
        }
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
