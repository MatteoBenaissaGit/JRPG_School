using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualEffectManager : MonoBehaviour
{
    [Header("Referencing")]
    [SerializeField] private GameObject _clickEffetPrefab;  

    private void Update()
    {
        ClickEffetChecker();
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
}
