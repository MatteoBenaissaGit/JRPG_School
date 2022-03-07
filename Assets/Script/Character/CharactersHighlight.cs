using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersHighlight : MonoBehaviour
{
    //[Header("----Referencing----")]
    //[SerializeField] private GameObject _character;
    [Header("----Debug----")]
    [SerializeField] private Logger _logger;

    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        _logger.Log($"Mouse is over ", this);
    }
}
