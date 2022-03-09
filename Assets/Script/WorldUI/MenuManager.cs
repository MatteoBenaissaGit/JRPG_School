using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private List<GameObject> Windows;
    [SerializeField] private InventoryWindow _inventoryWindow;

    [SerializeField] private Logger _logger;

    private void Start()
    {
        for (int i = 1; i < Windows.Count; i++)
        {
            Windows[i].SetActive(false);
        }
        Menu.SetActive(false);
    }

    public void ShowOrHideMenu()
    {
        if (!Menu.active)
            Menu.SetActive(true);
        else if (Menu.active)
            Menu.SetActive(false);
        _logger.Log($"Menu is {Menu.active}", this);
    }

    public void NextWindow()
    {
        for (int i = 0; i < Windows.Count; i++)
        {
            if (Windows[i].active)
            {
                Windows[i].SetActive(false);
                int numberToCheck = 0;
                if (i + 1 < Windows.Count)
                    numberToCheck = i + 1;

                _logger.Log($"{Menu.active}", this);

                Windows[numberToCheck].SetActive(true);
                break;
                _logger.Log($"Next Window({Windows[numberToCheck]})", this);
            }
        }

    }
    public void PreviousWindow()
    {
        for (int i = 0; i < Windows.Count; i++)
        {
            if (Windows[i].active)
            {
                Windows[i].SetActive(false);
                int numberToCheck = 0;
                if (i - 1 < 0)
                    numberToCheck = Windows.Count-1;
                else
                    numberToCheck = i-1;
                Windows[numberToCheck].SetActive(true);
                break;
            }
        }
    }
}
