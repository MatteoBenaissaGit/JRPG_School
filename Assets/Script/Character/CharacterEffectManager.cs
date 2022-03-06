using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffectManager : MonoBehaviour
{
    [Header("Referencing")]
    [SerializeField] private GameObject _clickEffetPrefab;  

    private void Update()
    {
        ClickEffetLauncher();
    }

    private void ClickEffetLauncher()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<CharacterController>().Canmove)
        {
            GameObject clickeffect = Instantiate(_clickEffetPrefab);
            clickeffect.transform.position = Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(1, 1, 0));
        }
    }
}
