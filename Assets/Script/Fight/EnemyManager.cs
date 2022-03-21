using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public List<CharacterCombatAttributes> ListEnnemy;

    public GameObject AbilitiesManagerObj;

    public int SelectedCharacter = -1;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
        // _logger.Log($"HP of {this.name} : {Character.HP}", this);

        //UpdateCharSprite();
    }
    public void Update()
    {

    }
}