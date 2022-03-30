using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private int _characterNumber;
    [SerializeField] private CharactersParametersList _charactersParent;
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

    private void OnEnable()
    {
        GenerateCompetences();
    }
    public void GenerateCompetences()
    {      
        for (int i = 0; i < _competencesList.Count; i++)
        {
            Destroy(_competencesList[i]);
        }
        for (int i = 0; i < _subLayoutList.Count; i++)
        {
            Destroy(_subLayoutList[i]);
        }
        _competencesList.Clear();
        _subLayoutList.Clear();
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
                competence.GetComponent<CompetenceIcon>().Name.text = _rowsOfCompetences[z].Competences[i].Name;
                competence.GetComponent<CompetenceIcon>().Description.text = _rowsOfCompetences[z].Competences[i].Description;
                competence.GetComponent<CompetenceIcon>().LockedText.GetComponent<TextMeshProUGUI>().text = $"level to unlock : {_rowsOfCompetences[z].Competences[i].LevelToUnlock}";

                //locked or unlocked              
                if (_charactersParent.CharactersListing[_characterNumber - 1].Level >= _rowsOfCompetences[z].Competences[i].LevelToUnlock)
                {
                    competence.GetComponent<CompetenceIcon>().LockedText.SetActive(false);
                    competence.GetComponent<CompetenceIcon>().UnlockedText.SetActive(true);
                }
                _competencesList.Add(competence);
                //lines
                if (_rowsOfCompetences.Count >= z+1)
                {
                    switch (_rowsOfCompetences[z + 1].Competences.Count)
                    {
                        case 1:
                            if (_rowsOfCompetences[z].Competences.Count == 1)
                            {
                                competence.GetComponent<CompetenceIcon>().SingleLine.SetActive(true);
                            }
                            else
                            {
                                if (i == 0)
                                    competence.GetComponent<CompetenceIcon>().RightLine.SetActive(true);
                                if (i == 1)
                                    competence.GetComponent<CompetenceIcon>().LeftLine.SetActive(true);
                            }
                            break;
                        case 2:
                            if (_rowsOfCompetences[z].Competences.Count == 1)
                                competence.GetComponent<CompetenceIcon>().DoubleLine.SetActive(true);
                            else
                            {
                                competence.GetComponent<CompetenceIcon>().SingleLine.SetActive(true);
                            }
                            break;
                    }
                }
            }
        }
    }
}