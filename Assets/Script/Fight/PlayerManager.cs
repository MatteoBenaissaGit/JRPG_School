using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    enum SelectionMode
    {
        AllyPick,
        Attack,
        CheckIfNewRound,
        Waiting
    }

    SelectionMode _currentMode;

    public List<CharacterCombatAttributes> ListChars;

    public GameObject AbilitiesManagerObj;
    public GameObject ButtonManagerObj;
    public GameObject EnemyManagerObj;

    int _numberOfAllies = 0;
    int _numberOfPlayedAllies = 0;

    public float TransparencyValue;

    public int SelectedCharacterID = -1;
    int _selectedButtons;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
        // _logger.Log($"HP of {this.name} : {Character.HP}", this);

        UpdateCharSprite();
        _currentMode = SelectionMode.AllyPick;
        StockStartEgo();

        foreach (var item in ListChars)
        {
            _numberOfAllies++;
        }
    }
    public void Update()
    {
        if (_currentMode == SelectionMode.CheckIfNewRound)
        {
            if (_numberOfPlayedAllies == _numberOfAllies)
            {
                NewRound();
            }
            else
                _currentMode = SelectionMode.AllyPick;
        }

        if (_currentMode == SelectionMode.Waiting)
        {

        }

        if (Input.GetMouseButtonDown(0))
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

                        SelectedCharacterID = characterPicked.CharacterIndex;

                        AbilitiesManagerObj.GetComponent<AbilitiesManager>().NewButtonSprites();
                        ButtonManagerObj.GetComponent<ButtonManager>().UpdateSprites();
                    }

                    if (_currentMode == SelectionMode.Attack)
                    {
                        if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == true && characterPicked.IsAlly == true 
                            && characterPicked.CharacterIndex != SelectedCharacterID)
                        {
                            Buff(characterPicked);
                        }

                        if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == true && characterPicked.IsAlly == true 
                            && characterPicked.CharacterIndex == SelectedCharacterID)
                        {
                            Buff(characterPicked);
                        }

                        if (characterPicked.IsAlly == false)
                        {
                            if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == false
                                && AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == false)
                            {
                                AttackOnEnemy(characterPicked);
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            SelectedCharacterID = -1; //Unselects character

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

    public void SetAttackMode()
    {
        _currentMode = SelectionMode.Attack;
    }


    public void AttackOnEnemy(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        int picker = Random.Range(1, 100);

        if (picker <= ListChars[SelectedCharacterID].CriticalPercentage)
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

        for (int i = 0; i < ListChars.Count; i++)
        {
            ListChars[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        ButtonManagerObj.GetComponent<ButtonManager>().ResetDefeultSprites();
        _currentMode = SelectionMode.AllyPick;

        EndOfTurn();
    }




    public void Buff(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        ListChars[Defender.CharacterIndex].HP += updatedHP;
        ListChars[Defender.CharacterIndex].Ego += updatedEgo;

        for (int i = 0; i < ListChars.Count; i++)
        {
            ListChars[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        ButtonManagerObj.GetComponent<ButtonManager>().ResetDefeultSprites();
        _currentMode = SelectionMode.AllyPick;

        EndOfTurn();
    }

    public void StockStartEgo()
    {
        for (int i = 0; i < ListChars.Count; i++)
        {
            ListChars[i].StartEgo = ListChars[i].Ego;
        }
    }
    public void StockNumberOfAllies()
    {
        for (int i = 0; i < ListChars.Count; i++)
        {
            _numberOfAllies++;
        }
    }

    public void NewRound()
    {
        for (int i = 0; i < ListChars.Count; i++)
        {
            Color newColor = ListChars[i].CombatSpriteRenderer.color;
            newColor.a = 1f;

            ListChars[i].CombatSpriteRenderer.color = newColor;

            ListChars[i].HasPlayed = false;
            _numberOfPlayedAllies--;
        }

        if (_numberOfPlayedAllies == 0)
            _currentMode = SelectionMode.AllyPick;
    }

    public void EndOfTurn()
    {
        Color tempColor = ListChars[SelectedCharacterID].CombatSpriteRenderer.color;
        tempColor.a = TransparencyValue;

        ListChars[SelectedCharacterID].CombatSpriteRenderer.color = tempColor;

        ListChars[SelectedCharacterID].HasPlayed = true;
        _numberOfPlayedAllies++;

        _currentMode = SelectionMode.CheckIfNewRound;

    }
}
