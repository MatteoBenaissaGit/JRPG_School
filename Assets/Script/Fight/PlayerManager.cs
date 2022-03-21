using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    enum SelectionMode
    {
        AllyPick,
        Attack,
        Buff,
        EnemyPick
    }

    SelectionMode _currentMode;

    public List<CharacterCombatAttributes> ListChars;

    public GameObject AbilitiesManagerObj;
    public GameObject ButtonManagerObj;

    public int SelectedCharacter = -1;
    int _selectedButtons;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
        // _logger.Log($"HP of {this.name} : {Character.HP}", this);

        UpdateCharSprite();
        _currentMode = SelectionMode.AllyPick;
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
                    if (_currentMode == SelectionMode.AllyPick)
                    {
                        for (int i = 0; i < ListChars.Count; i++)
                        {
                            ListChars[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
                        }

                        characterPicked.Outline();

                        for (int i = 0; i < ListChars.Count; i++)
                        {
                            if (ListChars[i].CharacterObject.GetComponent<CharacterUI>().IsActive == true)
                            {
                                SelectedCharacter = i;
                            }
                        }
                        //_currentMode = SelectionMode.Attack;

                        AbilitiesManagerObj.GetComponent<AbilitiesManager>().NewActiveSprites();
                        ButtonManagerObj.GetComponent<ButtonManager>().UpdateSprites();
                    }

                    if (_currentMode == SelectionMode.Attack)
                    {
                        // Selectionner un joueur allié = impossible, prog le message
                    }

                    if (_currentMode == SelectionMode.Buff)
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

        if (Input.GetMouseButton(1))
        {
            SelectedCharacter = -1; //Unselects character

            for (int i = 0; i < ListChars.Count; i++)
            {
                ListChars[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
            }

            _currentMode = SelectionMode.AllyPick;
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
