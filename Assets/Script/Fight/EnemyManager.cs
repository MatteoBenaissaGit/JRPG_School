using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public List<CharacterCombatAttributes> ListEnemies;

    enum SelectionMode
    {
        CheckIfNewRound,
        EnemyPick,
        Attack,
        Waiting
    }

    SelectionMode _currentMode;

    [Header("---Debug---")]
    [SerializeField] private Logger _logger;

    public GameObject AbilitiesManagerObj;
    public GameObject PlayerManagerObj;

    public float TransparencyValue;
    [HideInInspector] public int ActiveEnemyAbility;

    List<int> _enemyPickerList = new List<int>();
    [HideInInspector] public List<int> TargetableEnemiesList = new List<int>();

    int _numberOfPlayableEnemies = 0;
    int _numberOfPlayedEnemies = 0;

    public int SelectedEnemyID = -1;
    int _selectedEnemyIndex = -1;

    float _timeToWait;

    private void Start()
    {
        //Character = ListChars[_selectedPlayerIndex];
        // _logger.Log($"HP of {this.name} : {Character.HP}", this);

        //UpdateCharSprite();
        _currentMode = SelectionMode.Waiting;

        StockStartEgo();

        foreach (var item in ListEnemies)
        {
            _numberOfPlayableEnemies++;
            _enemyPickerList.Add(_numberOfPlayableEnemies - 1);
            TargetableEnemiesList.Add(_numberOfPlayableEnemies - 1);
        }

    }

    public void Update()
    {

        _timeToWait -= Time.deltaTime;

        if (_timeToWait > 0)
            return;

        if (_currentMode == SelectionMode.CheckIfNewRound)
        {
            UpdateCheckRound();
        }

        else if (_currentMode == SelectionMode.EnemyPick)
        {
            UpdateEnemyPick();
        }
        else if (_currentMode == SelectionMode.Attack)
        {
            Debug.Log("lol jatak");

            int abilityPicker = Random.Range(0, ListEnemies[SelectedEnemyID].AbilityIDs.Count);

            ActiveEnemyAbility = ListEnemies[SelectedEnemyID].AbilityIDs[abilityPicker];
            AbilitiesManagerObj.GetComponent<AbilitiesManager>().NewActiveEnemyStats();


            if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == true &&
                AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == true)
            {
                int picker = Random.Range(0, TargetableEnemiesList.Count);
                int characterBuffed = TargetableEnemiesList[picker];

                CharacterUI characterPicked = ListEnemies[characterBuffed].CharacterObject.GetComponent<CharacterUI>();
                Buff(characterPicked);
            }

            else
            {
                if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == true)
                {
                    CharacterUI characterPicked = ListEnemies[SelectedEnemyID].CharacterObject.GetComponent<CharacterUI>();
                    Buff(characterPicked);
                }
                if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == true)
                {
                    List<int> NewBuffList = new List<int>(TargetableEnemiesList);
                    NewBuffList.RemoveAt(SelectedEnemyID);
                    int picker = Random.Range(0, NewBuffList.Count);
                    int characterBuffed = NewBuffList[picker];

                    CharacterUI characterPicked = ListEnemies[characterBuffed].CharacterObject.GetComponent<CharacterUI>();
                    Buff(characterPicked);
                }
            }

            if (AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetHimself == false &&
                AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedCanTargetAlly == false)
            {
                int picker = Random.Range(0, PlayerManagerObj.GetComponent<PlayerManager>().TargetableAlliesList.Count);
                int playerAttackedID = PlayerManagerObj.GetComponent<PlayerManager>().TargetableAlliesList[picker];

                CharacterUI characterPicked = PlayerManagerObj.GetComponent<PlayerManager>().ListChars[playerAttackedID].CharacterObject.GetComponent<CharacterUI>();
                AttackOnPlayer(characterPicked);
            }
        }

        if (_currentMode == SelectionMode.Waiting)
        {

        }

    }

    private void UpdateEnemyPick()
    {
        int picker = Random.Range(0, _enemyPickerList.Count);
        _selectedEnemyIndex = picker;
        SelectedEnemyID = _enemyPickerList[picker];

        CharacterUI characterPicked = ListEnemies[SelectedEnemyID].CharacterObject.GetComponent<CharacterUI>();

        _timeToWait = 1;



        Debug.Log(SelectedEnemyID);

        _currentMode = SelectionMode.Attack;
    }

    private void UpdateCheckRound()
    {
        if (_numberOfPlayedEnemies == _numberOfPlayableEnemies)
        {
            NewRound();
        }
        else
            _currentMode = SelectionMode.EnemyPick;
    }

    public void StockStartEgo()
    {
        for (int i = 0; i < ListEnemies.Count; i++)
        {
            ListEnemies[i].StartEgo = ListEnemies[i].Ego;
        }
    }

    void UpdateCharSprite()
    {
        foreach (var character in ListEnemies)
        {
            character.CombatSpriteRenderer.sprite = character.CombatSprite;
        }
    }

    public void AttackOnPlayer(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        int picker = Random.Range(1, 100);

        if (picker <= ListEnemies[SelectedEnemyID].CriticalPercentage)
        {
            updatedHP = updatedHP * 2;
            updatedEgo = updatedEgo * 2;
        }

        if (PlayerManagerObj.GetComponent<PlayerManager>().ListChars[Defender.CharacterIndex].Ego >
            PlayerManagerObj.GetComponent<PlayerManager>().ListChars[Defender.CharacterIndex].StartEgo / 2)
        {
            updatedHP = updatedHP / 2;
        }

        PlayerManagerObj.GetComponent<PlayerManager>().ListChars[Defender.CharacterIndex].HP -= updatedHP;
        PlayerManagerObj.GetComponent<PlayerManager>().ListChars[Defender.CharacterIndex].Ego -= updatedEgo;

        for (int i = 0; i < ListEnemies.Count; i++)
        {
            ListEnemies[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        EndOfTurn();
    }

    public void Buff(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        ListEnemies[Defender.CharacterIndex].HP += updatedHP;
        ListEnemies[Defender.CharacterIndex].Ego += updatedEgo;

        for (int i = 0; i < ListEnemies.Count; i++)
        {
            ListEnemies[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

        _currentMode = SelectionMode.Waiting;

        EndOfTurn();
    }

    public void NewRound()
    {
        _numberOfPlayableEnemies = 0;

        for (int i = 0; i < ListEnemies.Count; i++)
        {
            //Color newColor = ListEnemies[i].CombatSpriteRenderer.color;
            //newColor.a = 1f;

            //ListEnemies[i].CombatSpriteRenderer.color = newColor;

            ListEnemies[i].HasPlayed = false;
            _numberOfPlayedEnemies--;

            _numberOfPlayableEnemies++;
            _enemyPickerList.Add(_numberOfPlayableEnemies - 1);
        }

        if (_numberOfPlayedEnemies == 0)
            _currentMode = SelectionMode.EnemyPick;
    }

    public void EndOfTurn()
    {
        //Color tempColor = ListEnemies[SelectedEnemyID].CombatSpriteRenderer.color;
        //tempColor.a = TransparencyValue;

        //ListEnemies[SelectedEnemyID].CombatSpriteRenderer.color = tempColor;

        ListEnemies[SelectedEnemyID].HasPlayed = true;
        _numberOfPlayedEnemies++;

        _enemyPickerList.RemoveAt(_selectedEnemyIndex);

        _currentMode = SelectionMode.Waiting;

        PlayerManagerObj.GetComponent<PlayerManager>().PlayersTurnToPlay();

    }

    public void EnemiesTurnToPlay()
    {
        _currentMode = SelectionMode.CheckIfNewRound;
    }

}