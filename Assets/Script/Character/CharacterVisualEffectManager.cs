using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualEffectManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int _charactersOrderInLayer;
    [Header("Effects")]
    [SerializeField] private GameObject _clickEffetPrefab;
    [Header("Characters List (Put Character and Followers here)")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private List<GameObject> _charactersList;
    [Header("----Debug----")]
    [SerializeField] private Logger _logger;

    private void Update()
    {
        ClickEffetChecker();
        DepthManagement();
    }

    private void EffetLauncher(GameObject effectPrefab, Vector3 position)
    {
        GameObject effectObject = Instantiate(effectPrefab);
        effectObject.transform.position = position;
    }

    private void ClickEffetChecker()
    {
        if (Input.GetMouseButtonDown(0) && _characterController.Canmove)
            EffetLauncher(_clickEffetPrefab, Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(1, 1, 0)));
    }

    private static int CompareDinosCharacterByTransformY(GameObject x, GameObject y)
    {
        return (x.transform.position.y > y.transform.position.y) ? -1 : 1;
    }
    private void DepthManagement()
    {
        _charactersList.Sort(CompareDinosCharacterByTransformY);
        for (int i = 0; i < _charactersList.Count; i++)
            _charactersList[i].GetComponent<SpriteRenderer>().sortingOrder = _charactersOrderInLayer + i;
    }
}
