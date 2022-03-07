using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualEffectManager : MonoBehaviour
{
    [Header("Click Effet Prefab")]
    [SerializeField] private GameObject _clickEffetPrefab;
    [Header("Followers")]
    [SerializeField] private List<GameObject> _followersList;

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
        if (Input.GetMouseButtonDown(0) && GetComponent<CharacterController>().Canmove)
            EffetLauncher(_clickEffetPrefab, Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(1, 1, 0)));
    }

    private void DepthManagement()
    {
        for (int i = 0; i < _followersList.Count; i++)
        {
            //for (int i = 0; i < length; i++)
            //{
            //    if (_followersList[i].transform.position.y < _followersList[i + 1].transform.position.y)
            //        _followersList[i].GetComponent<SpriteRenderer>().sortingOrder++;
            //}
        }
    }
}
