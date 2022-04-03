using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MissionType
{
    public enum MissionsType
    {
        goToALocation = 0,
        upToALevel = 1,
        killAPerson = 2
    }
    public MissionsType MissionTypeChoice;
    public string Name;
    public string Description;
    [HideInInspector] public bool _isMissionCompleted = false;
    [Header("if location mission")]
    public Collider2D ColliderLocationToGo;
    [Header("if level mission")]
    public int CharacterToLevelUp;
    public int LevelToGo;
    //[Header("if kill mission")]
    //liste boss
}
public class Missions : MonoBehaviour
{
    [Header("Referencing")]
    [SerializeField] private MissionUI _missionUI;
    [SerializeField] private Transform _character;
    [SerializeField] private int _missionNumber = 0;
    [Header("Missions List")]
    public List<MissionType> ListMissions;

    private void Start()
    {
        UpdateMission(_missionNumber);        
    }
    private void Update()
    {
        CheckIfMissionCompleted();
    }

    private void UpdateMission(int missionNumber)
    {
        if (missionNumber < ListMissions.Count)
        {
            _missionUI.MissionName.text = ListMissions[missionNumber].Name;
            _missionUI.MissionDescription.text = ListMissions[missionNumber].Description;
        }
    }

    private void CheckIfMissionCompleted()
    {
        if (ListMissions[_missionNumber]._isMissionCompleted)
        {
            _missionNumber++;
            UpdateMission(_missionNumber);
        }
    }
}