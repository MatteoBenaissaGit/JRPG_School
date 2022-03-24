using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public List<CharacterCombatAttributes> ListEnnemy;

    enum SelectionMode
    {
        EnemyPick,
        Attack,
        CheckIfNewRound,
        Waiting
    }

    SelectionMode _currentMode;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    public GameObject AbilitiesManagerObj;
    public GameObject EnemyManagerObj;

    public float TransparencyValue;
    [HideInInspector] public int ActiveEnemyAbility;

    int _numberOfAbilities;

    int _numberOfEnemies = 0;
    int _numberOfPlayedEnemies = 0;

    public int SelectedEnemyID = -1;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
        // _logger.Log($"HP of {this.name} : {Character.HP}", this);

        UpdateCharSprite();
        _currentMode = SelectionMode.Waiting;
        StockStartEgo();

        foreach (var item in ListEnnemy)
        {
            _numberOfEnemies++;
        }
    }

    public void Update()
    {
        if (_currentMode == SelectionMode.EnemyPick)
        {
            int picker = Random.Range(0, _numberOfEnemies - 1);
            SelectedEnemyID = picker;

            while (ListEnnemy[SelectedEnemyID].HasPlayed == true)
            {
                int newPicker = Random.Range(0, _numberOfEnemies - 1);
                SelectedEnemyID = newPicker;
            }
        }

        if (_currentMode == SelectionMode.Attack)
        {
            foreach (int abilityID in ListEnnemy[SelectedEnemyID].AbilityIDs)
            {
                _numberOfAbilities++;
            }

            int abilityPicker = Random.Range(0, _numberOfAbilities - 1);
            ActiveEnemyAbility = ListEnnemy[SelectedEnemyID].AbilityIDs[abilityPicker];

            AbilitiesManagerObj.GetComponent<AbilitiesManager>().NewActiveEnemyStats();

            //if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == false && characterPicked.IsAlly == false
            //&& characterPicked.CharacterIndex != SelectedEnemyID)
            //{
            //    Buff(characterPicked);
            //}

            //if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == true && characterPicked.IsAlly == true
            //    && characterPicked.CharacterIndex == SelectedEnemyID)
            //{
            //    Buff(characterPicked);
            //}

            //if (characterPicked.IsAlly == false)
            //{
            //    if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == false
            //        && AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == false)
            //    {
            //        AttackOnAlly(characterPicked);
            //    }
            //}
        }

    }

    public void StockStartEgo()
    {
        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            ListEnnemy[i].StartEgo = ListEnnemy[i].Ego;
        }
    }

    void UpdateCharSprite()
    {
        foreach (var character in ListEnnemy)
        {
            character.CombatSpriteRenderer.sprite = character.CombatSprite;
        }
    }

    public void AttackOnAlly(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        int picker = Random.Range(1, 100);

        if (picker <= ListEnnemy[SelectedEnemyID].CriticalPercentage)
        {
            updatedHP = updatedHP * 2;
            updatedEgo = updatedEgo * 2;
        }

        if (EnemyManagerObj.GetComponent<EnemyManager>().ListEnnemy[Defender.CharacterIndex].Ego >
            EnemyManagerObj.GetComponent<EnemyManager>().ListEnnemy[Defender.CharacterIndex].StartEgo / 2)
        {
            updatedHP = updatedHP / 2;
        }

        EnemyManagerObj.GetComponent<EnemyManager>().ListEnnemy[Defender.CharacterIndex].HP -= updatedHP;
        EnemyManagerObj.GetComponent<EnemyManager>().ListEnnemy[Defender.CharacterIndex].Ego -= updatedEgo;

        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            ListEnnemy[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        _currentMode = SelectionMode.EnemyPick;

        EndOfTurn();
    }




    public void Buff(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        ListEnnemy[Defender.CharacterIndex].HP += updatedHP;
        ListEnnemy[Defender.CharacterIndex].Ego += updatedEgo;

        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            ListEnnemy[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        _currentMode = SelectionMode.EnemyPick;

        EndOfTurn();
    }

    public void StockNumberOfEnemies()
    {
        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            _numberOfEnemies++;
        }
    }

    public void NewRound()
    {
        for (int i = 0; i < ListEnnemy.Count; i++)
        {
            Color newColor = ListEnnemy[i].CombatSpriteRenderer.color;
            newColor.a = 1f;

            ListEnnemy[i].CombatSpriteRenderer.color = newColor;

            ListEnnemy[i].HasPlayed = false;
            _numberOfPlayedEnemies--;
        }

        if (_numberOfPlayedEnemies == 0)
            _currentMode = SelectionMode.EnemyPick;
    }

    public void EndOfTurn()
    {
        Color tempColor = ListEnnemy[SelectedEnemyID].CombatSpriteRenderer.color;
        tempColor.a = TransparencyValue;

        ListEnnemy[SelectedEnemyID].CombatSpriteRenderer.color = tempColor;

        ListEnnemy[SelectedEnemyID].HasPlayed = true;
        _numberOfPlayedEnemies++;

        _currentMode = SelectionMode.CheckIfNewRound;

    }
}