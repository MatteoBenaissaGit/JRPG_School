using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    enum SelectionMode
    {
        Default,
        Attack,
        Buff
    }

    SelectionMode _currentMode;

    private CharacterUI _selectedUI;

    public List<CharacterCombatAttributes> ListChars;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
       // _logger.Log($"HP of {this.name} : {Character.HP}", this);
        UpdateCharSprite();
    }
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                CharacterUI characterPicked = hit.collider.gameObject.GetComponent<CharacterUI>();

                if (characterPicked != null)
                {
                    for (int i = 0; i < ListChars.Count; i++)
                    {
                        ListChars[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
                    }
                    characterPicked.Outline();
                }

            }
        }
    }
    void UpdateCharSprite()
    {
        foreach (var character in ListChars)
        {
            character.CombatSpriteRenderer.sprite = character.CombatSprite;   
        }
    }
}
