using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CompetenceCharacteristic
{
    public string Name;
    public Sprite Icon;
    public string Description;
    public int LevelToUnlock;
    public float EgoGain;
    public float EloquenceGain;
    public float PuissanceGain;
}
[Serializable]
public class RowsOfCompetences
{
    public List<CompetenceCharacteristic> Competences = new List<CompetenceCharacteristic>();
}
public class CompetenceWindowGenerator : MonoBehaviour
{
    [Header("Logger")]
    [SerializeField] private Logger _logger;
    [Header("Competence Icon Prefab")]
    [SerializeField] private GameObject _competenceIconPrefab;
    [Header("Layouts (self+Prefab)")]
    [SerializeField] private GameObject _verticalLayout;
    [SerializeField] private GameObject _subHorizontalLayout;
    [Header("Number of Competence Rows")]
    [SerializeField] private List<RowsOfCompetences> _rowsOfCompetences;

    private List<GameObject> _subLayoutList = new List<GameObject>();
    private List<GameObject> _competencesList = new List<GameObject>();
    private void Awake()
    {
        for (int z = 0; z < _rowsOfCompetences.Count; z++)
        {
            GameObject layout = Instantiate(_subHorizontalLayout, this.transform);
            _subLayoutList.Add(layout);
            for (int i = 0; i < _rowsOfCompetences[z].Competences.Count; i++)
            {
                _logger.Log($"Competence {_rowsOfCompetences[z].Competences[i].Name}, nb{i + 1} of row {z} diplayed", this);
                GameObject competence = Instantiate(_competenceIconPrefab, layout.transform);
                competence.GetComponent<CompetenceIcon>().Icon.sprite = _rowsOfCompetences[z].Competences[i].Icon;
                competence.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                _competencesList.Add(competence);
            }
        }   
    }
}