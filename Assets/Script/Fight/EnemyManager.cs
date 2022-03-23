using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public List<CharacterCombatAttributes> ListEnnemy;


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
    public void StockStartEgo()
    {
        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            ListEnnemy[i].StartEgo = ListEnnemy[i].Ego;
        }
    }
}