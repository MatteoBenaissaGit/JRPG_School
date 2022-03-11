using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryWindow : MonoBehaviour
{
    [Header("Inventory Slot List")]
    [HideInInspector] public List<GameObject> _slotsbackground;
    [HideInInspector] public List<bool> _slotsfull;
    public int NumberOfSlots;
    [Header("Inventory Referencing")]
    [SerializeField] private CharacterInventory _characterInventory;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private GameObject _slotBackgroundPrefab;
    [Header("Referencing")]
    [SerializeField] private MenuRightClic _menuRightClick;
    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void OnEnable()
    {
        CreateSlots();
        UpdateInventory();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ShowRightClick(0, true);
                _logger.Log($"clicked on {hit.collider.name}", this);
            }
        }
    }

    private void OnDisable()
    {
        _logger.Log("Cleaning inventory", this);
        for (int i = 0; i < _slotsbackground.Count; i++)
            GameObject.Destroy(_slotsbackground[i]); 
        _slotsbackground.Clear();
        _slotsfull.Clear();
    }

    private void CreateSlots()
    {
        for (int i = 0; i < NumberOfSlots; i++)
        {
            _slotsbackground.Add(Instantiate(_slotBackgroundPrefab, transform));
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
                GameObject itemprefab = Instantiate(_itemPrefab, _slotsbackground[CheckFirstEmptySlot()].transform);
                itemprefab.GetComponent<ItemSlot>().Image.sprite = _characterInventory.ItemList[i].Sprite;
                itemprefab.GetComponent<ItemSlot>().Number.text = _characterInventory.ItemList[i].NumberOfItem.ToString();
                _slotsfull[CheckFirstEmptySlot()] = true;
            }
        }
    }

    private int CheckFirstEmptySlot()
    {
        for (int i = 0; i < _slotsfull.Count; i++)
        {
            if (!_slotsfull[i])
            {
                return i;
                break;
            }
        }
        return -1;
    }

    public void ShowRightClick(int itemNumber, bool isNotUsable)
    {
        _menuRightClick.UpdateRightClickInfos(itemNumber, isNotUsable);
        _menuRightClick.gameObject.SetActive(true);
    }
}
