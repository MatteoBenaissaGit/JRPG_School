using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class InventoryWindow : MonoBehaviour
{
    [Header("Inventory Slot List")]
    [HideInInspector] public List<GameObject> _slotsbackground;
    [HideInInspector] public List<GameObject> _items;
    [HideInInspector] public List<bool> _slotsfull;
    public int NumberOfSlots;
    public List<ItemSlot> ItemInSlotList;
    [Header("Inventory Referencing")]
    [SerializeField] private CharacterInventory _characterInventory;
    [SerializeField] private GameObject _inventoryItemPrefab;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private GameObject _slotBackgroundPrefab;
    [SerializeField] private GameObject _inventoryItemGrid;
    [SerializeField] private GameObject _inventoryGrid;
    [Header("RightClick Referencing")]
    [SerializeField] private MenuRightClic _menuRightClick;
    [Header("ItemDrop Referencing")]
    [SerializeField] private GameObject _itemParent;
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _characterParent;
    [SerializeField] private DialogBox _dialogBox;
    [SerializeField] [Range(0.1f,2f)] private float _distanceDrop;

    private int _itemRightClicked;


    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void OnEnable()
    {
        CreateSlots();
        UpdateInventory();
    }

    private void Update()
    {
        RightClickCheck();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    private void ClearInventory()
    {
        _logger.Log("Cleaning inventory", this);
        for (int i = 0; i < _slotsbackground.Count; i++)
            GameObject.Destroy(_slotsbackground[i]);
        for (int i = 0; i < _items.Count; i++)
            GameObject.Destroy(_items[i]);
        _slotsbackground.Clear();
        _slotsfull.Clear();
        _items.Clear();
    }

    private void CreateSlots()
    {
        for (int i = 0; i < NumberOfSlots; i++)
        {
            _slotsbackground.Add(Instantiate(_slotBackgroundPrefab, _inventoryGrid.transform));
            _slotsfull.Add(false);
        }
    }

    public void UpdateInventory()
    {
        _logger.Log("Update Inventory", this);
        for (int i = 0; i < _characterInventory.ItemList.Count; i++)
        {
            if (_characterInventory.ItemList[i].NumberOfItem > 0)
            {
                _logger.Log($"Showing {_characterInventory.ItemList[i].NumberOfItem} {_characterInventory.ItemList[i].Item} in Slot {CheckFirstEmptySlot()}", this);
                GameObject itemprefab = Instantiate(_inventoryItemPrefab, _inventoryItemGrid.transform);
                itemprefab.GetComponent<ItemSlot>().Image.sprite = _characterInventory.ItemList[i].InventorySprite;
                itemprefab.GetComponent<ItemSlot>().Description = _characterInventory.ItemList[i].Description;
                itemprefab.GetComponent<ItemSlot>().Number.text = _characterInventory.ItemList[i].NumberOfItem.ToString();
                itemprefab.GetComponent<ItemSlot>().IsUsable= _characterInventory.ItemList[i].IsUsable;
                itemprefab.GetComponent<ItemSlot>().Item = (ItemSlot.Items)i;
                itemprefab.transform.position = _slotsbackground[CheckFirstEmptySlot()].transform.position;
                ItemInSlotList.Add(itemprefab.GetComponent<ItemSlot>());
                _items.Add(itemprefab);
                _slotsfull[CheckFirstEmptySlot()] = true;
            }
        }
    }

    private int CheckFirstEmptySlot()
    {
        for (int i = 0; i < _slotsfull.Count; i++)
        {
            if (!_slotsfull[i])
                return i;
        }
        return -1;
    }

    private void RightClickCheck()
    {
        for (int i = 0; i < ItemInSlotList.Count; i++)
        {
            if (ItemInSlotList[i].IsRightClicked && (Input.GetMouseButtonDown(1)))
            {
                _itemRightClicked = (int)ItemInSlotList[i].Item;
                _logger.Log($"RightClick on {ItemInSlotList[i].Item} (item nb : {(int)ItemInSlotList[i].Item})", this);
                ShowRightClick(int.Parse(ItemInSlotList[i].Number.text), ItemInSlotList[i].IsUsable);
            }
        }
    }

    public void ShowRightClick(int itemNumber, bool isNotUsable)
    {
        _menuRightClick.UpdateRightClickInfos(itemNumber, isNotUsable);
        _menuRightClick.gameObject.SetActive(true);
    }


    private void DropItem(int numberOfItemDropped, int itemNumber)
    {
        GameObject itemdropped = Instantiate(_itemPrefab, _itemParent.transform);
        Vector3 size = itemdropped.transform.localScale;
        itemdropped.transform.position = _character.transform.position;
        itemdropped.transform.localScale = Vector3.zero;
        itemdropped.GetComponent<ItemPrefab>().ItemNumber = (ItemPrefab.ItemList)itemNumber;
        itemdropped.GetComponent<ItemPrefab>().Character = _character;
        itemdropped.GetComponent<ItemPrefab>().CharacterParent = _characterParent;
        itemdropped.GetComponent<ItemPrefab>().CharacterInventory = _characterParent.GetComponent<CharacterInventory>();
        itemdropped.GetComponent<ItemPrefab>().InventoryWindow = gameObject.GetComponent<InventoryWindow>();
        itemdropped.GetComponent<ItemPrefab>().DialogBox = _dialogBox;
        itemdropped.GetComponent<ItemPrefab>().Quantity = numberOfItemDropped;
        itemdropped.GetComponent<SpriteRenderer>().sprite = _characterInventory.ItemList[itemNumber].InGameSprite;

        float distanceDrop = Random.Range(0, _distanceDrop);
        itemdropped.transform.DOMove(Vector3.Scale(transform.position, new Vector3(distanceDrop, distanceDrop, distanceDrop)), 1);
        itemdropped.transform.DOScale(size, 1);
        _logger.Log($"item {itemNumber} : {numberOfItemDropped} dropped", this);

        _characterInventory.ItemList[itemNumber].NumberOfItem -= numberOfItemDropped;
        ClearInventory();
        CreateSlots();
        UpdateInventory();
    }
    public void ButtonThrowOne()
    {
        DropItem(1, _itemRightClicked);
    }
    public void ButtonThrowAll()
    {
        DropItem(_characterInventory.ItemList[_itemRightClicked].NumberOfItem, _itemRightClicked);
    }
}
