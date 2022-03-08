using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private CharacterCombatAttributes _selectedChar;

    public List<CharacterCombatAttributes> ListChars;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    //private int _selectedPlayerIndex = 0;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
       // _logger.Log($"HP of {this.name} : {Character.HP}", this);
        UpdateCharSprite();
    }
    //public void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

    //        if (hit.collider != null)
    //        {
    //            CharacterCombatAttributes characterPicked = hit.collider.gameObject.GetComponent<CharacterCombatAttributes>();

    //            if (characterPicked != null)
    //            {
    //                if (_selectedChar != null)
    //                    characterPicked.UnOutline();

    //                _selectedChar = characterPicked;
    //                characterPicked.Outline();
    //            }
    //        }
    //    }
    //}
    void UpdateCharSprite()
    {
        foreach (var character in ListChars)
        {
            character.CombatSpriteRenderer.sprite = character.CombatSprite;   
        }
    }
}
