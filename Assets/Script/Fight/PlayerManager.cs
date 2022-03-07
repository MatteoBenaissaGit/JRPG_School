using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private CharacterCombatAttributes _selectedChar;
    public List<CharacterCombatAttributes> ListChars;

    public SpriteRenderer PlayerSpriteRenderer;

    private int selectedPlayerIndex = 0;

    private void Start()
    {
        _selectedChar = ListChars[selectedPlayerIndex];
        UpdateCharSprite();
        Debug.Log(_selectedChar.HP);
    }
    public void OnClickNextCharacter()
    {
        IncreaseIndex();
        _selectedChar = ListChars[selectedPlayerIndex];
        UpdateCharSprite();
        Debug.Log(_selectedChar.HP);
    }

    void UpdateCharSprite()
    {
       PlayerSpriteRenderer.sprite = _selectedChar.PlayerSprite;
    }

    void IncreaseIndex()
    {
        selectedPlayerIndex = (selectedPlayerIndex + 1) % ListChars.Count;
    }
}
