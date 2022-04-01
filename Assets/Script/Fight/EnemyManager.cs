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
        EndOfTurn,
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

        UpdateCharSprite();
        _currentMode = SelectionMode.Waiting;

        StockStartStats();

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
            UpdateAttack();
        }
        else if (_currentMode == SelectionMode.EndOfTurn)
        {
            EndOfTurn();
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
        characterPicked.Outline();

        _timeToWait = 1;

        _currentMode = SelectionMode.Attack;
    }

    private void UpdateCheckRound()
    {
        _timeToWait = 1;
        if (_numberOfPlayedEnemies == _numberOfPlayableEnemies)
        {
            NewRound();
        }
        else
            _currentMode = SelectionMode.EnemyPick;
    }

    public void StockStartStats()
    {
        for (int i = 0; i < ListEnemies.Count; i++)
        {
            ListEnemies[i].StartEgo = ListEnemies[i].Ego;
            ListEnemies[i].StartHP = ListEnemies[i].HP;
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

        CharacterCombatAttributes targetedPlayer = PlayerManagerObj.GetComponent<PlayerManager>().ListChars[Defender.CharacterIndex];

        if (picker <= ListEnemies[SelectedEnemyID].CriticalPercentage)
        {
            updatedHP = updatedHP * 2;
            updatedEgo = updatedEgo * 2;
        }

        if (targetedPlayer.Ego > targetedPlayer.StartEgo / 2)
        {
            updatedHP = updatedHP / 2;
        }

        targetedPlayer.HP -= updatedHP;
        targetedPlayer.Ego -= updatedEgo;
        targetedPlayer.CharaHealthBar.GetComponent<Bars>().SetHealth(targetedPlayer.HP);
        targetedPlayer.CharaEgoBar.GetComponent<Bars>().SetHealth(targetedPlayer.Ego);

        _timeToWait = 1;
        _currentMode = SelectionMode.EndOfTurn;
    }

    public void Buff(CharacterUI Defender)
    {
        int updatedHP = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedHP;
        int updatedEgo = AbilitiesManagerObj.GetComponent<AbilitiesManager>().UpdatedEgo;

        ListEnemies[Defender.CharacterIndex].HP += updatedHP;
        ListEnemies[Defender.CharacterIndex].Ego += updatedEgo;

        if (ListEnemies[Defender.CharacterIndex].Ego > ListEnemies[Defender.CharacterIndex].StartEgo)
            ListEnemies[Defender.CharacterIndex].Ego = ListEnemies[Defender.CharacterIndex].StartEgo;

        if (ListEnemies[Defender.CharacterIndex].HP > ListEnemies[Defender.CharacterIndex].StartHP)
            ListEnemies[Defender.CharacterIndex].HP = ListEnemies[Defender.CharacterIndex].StartHP;

        _timeToWait = 1;
        _currentMode = SelectionMode.EndOfTurn;
    }

    public void NewRound()
    {
        _numberOfPlayableEnemies = 0;

        for (int i = 0; i < ListEnemies.Count; i++)
        {
            Color newColor = ListEnemies[i].CombatSpriteRenderer.color;
            newColor.a = 1f;

            ListEnemies[i].CombatSpriteRenderer.color = newColor;

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
        Color tempColor = ListEnemies[SelectedEnemyID].CombatSpriteRenderer.color;
        tempColor.a = TransparencyValue;

        ListEnemies[SelectedEnemyID].CombatSpriteRenderer.color = tempColor;

        for (int i = 0; i < ListEnemies.Count; i++)
        {
            ListEnemies[i].CharacterObject.GetComponent<CharacterUI>().UnOutline();
        }

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

    public void UpdateAttack()
    {
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
    public void StunEnemy(CharacterUI StunnedChara)
    {
        Color tempColor = ListEnemies[StunnedChara.CharacterIndex].CombatSpriteRenderer.color;
        tempColor.a = TransparencyValue;

        ListEnemies[StunnedChara.CharacterIndex].CombatSpriteRenderer.color = tempColor;

        ListEnemies[StunnedChara.CharacterIndex].HasPlayed = true;
        ListEnemies[StunnedChara.CharacterIndex].IsStuned = true;
        _numberOfPlayedEnemies++;

        for (int i = 0; i < _enemyPickerList.Count; i++)
        {
            if (StunnedChara.CharacterIndex == _enemyPickerList[i])
                _enemyPickerList.RemoveAt(i);
        }
    }
}