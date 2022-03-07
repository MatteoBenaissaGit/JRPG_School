using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private CharacterCombatAttributes _selectedChar;
    public List<CharacterCombatAttributes> ListChars;

    public SpriteRenderer PlayerSpriteRenderer;
    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private int _selectedPlayerIndex = 0;

    private void Start()
    {
        _selectedChar = ListChars[_selectedPlayerIndex];
        UpdateCharSprite();
        _logger.Log($"HP of {this.name} : {_selectedChar.HP}", this);
    }
    public void OnClickNextCharacter()
    {
        IncreaseIndex();
        _selectedChar = ListChars[_selectedPlayerIndex];
        UpdateCharSprite();
        _logger.Log($"HP of {this.name} : {_selectedChar.HP}",this);
    }

    void UpdateCharSprite()
    {
       PlayerSpriteRenderer.sprite = _selectedChar.PlayerSprite;
    }

    void IncreaseIndex()
    {
        _selectedPlayerIndex = (_selectedPlayerIndex + 1) % ListChars.Count;
    }
}
