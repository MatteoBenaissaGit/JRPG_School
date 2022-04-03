using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPrefab : MonoBehaviour
{
    public enum ItemList //keep the same as ItemList in CharacterInventory
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
    [Header("Materials")]
    [SerializeField] private Material _materialOutline;
    [SerializeField] private Material _materialDefault;
    [Header("Referencing")]
    public ItemList ItemNumber;
    public GameObject Character;
    public GameObject CharacterParent;
    public CharacterInventory CharacterInventory;
    public InventoryWindow InventoryWindow;
    [SerializeField] private GameObject _getSymbol;
    [SerializeField] private TextMeshPro _numberText;
    public DialogBox DialogBox;
    [Header("Variables")]
    public int Quantity;


    private float _distanceToCollect = 2;
    private bool _canBeCollected = false;

    private void Start()
    {
        _numberText.text = Quantity.ToString();
        _getSymbol.SetActive(false);
    }
    private void Update()
    {
        DistanceCheck();  
    }

    private void DistanceCheck()
    {
        float dist = Vector2.Distance(Character.transform.position, transform.position);
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
        for (int i = 0; i < CharacterInventory.ItemList.Count; i++)
        {
            if (i != (int)ItemNumber && CharacterInventory.ItemList[i].NumberOfItem > 0)
                numberOfItemInInventory++;
        }

        if (_canBeCollected && numberOfItemInInventory < InventoryWindow.NumberOfSlots)
        {
            CharacterInventory.ItemList[(int)ItemNumber].NumberOfItem += Quantity;
            Destroy(gameObject);
        }
        else
        {
            string text = "Mon sac est plein ! Je ne peux plus rien porter.";
            DialogBox.EnableDialogBox(true, CharacterParent.GetComponent<CharactersParametersList>().CharactersListing[0].Name, 
            text, CharacterParent.GetComponent<CharactersParametersList>().CharactersListing[0].Icon);
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
