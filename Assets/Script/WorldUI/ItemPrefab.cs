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
    [SerializeField] private ItemList _itemNumber;
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _characterParent;
    [SerializeField] private CharacterInventory _characterInventory;
    [SerializeField] private InventoryWindow _inventoryWindow;
    [SerializeField] private GameObject _getSymbol;
    [SerializeField] private TextMeshPro _numberText;
    [SerializeField] private DialogBox _dialogBox;
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
    }

    private void DistanceCheck()
    {
        float dist = Vector3.Distance(_character.transform.position, transform.position);
        if (dist < _distanceToCollect)
        {
            Outline();
            _getSymbol.SetActive(true);
            _canBeCollected = true;
            if (Input.GetKeyUp(KeyCode.E))
                CollectItem();
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
        int numberOfItemInInventory = 0;
        for (int i = 0; i < _characterInventory.ItemList.Count; i++)
        {
            if (i != (int)_itemNumber && _characterInventory.ItemList[i].NumberOfItem > 0)
                numberOfItemInInventory++;
        }

        if (_canBeCollected && numberOfItemInInventory < _inventoryWindow.NumberOfSlots)
        {
            _characterInventory.ItemList[(int)_itemNumber].NumberOfItem += _quantity;
            Destroy(gameObject);
        }
        else
        {
            string text = "Mon sac est plein ! Je ne peux plus rien porter.";
            _dialogBox.EnableDialogBox(true, _characterParent.GetComponent<CharactersParametersList>().CharactersListing[0].Name, 
            text, _characterParent.GetComponent<CharactersParametersList>().CharactersListing[0].Icon);
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
