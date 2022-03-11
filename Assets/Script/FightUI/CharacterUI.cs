using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{

    public Material MaterialOutline;
    public Material MaterialDefault;

    public bool IsActive;

    public void Outline()
    {
        GetComponent<SpriteRenderer>().material = MaterialOutline;
        IsActive = true;
    }

    public void UnOutline()
    {
        GetComponent<SpriteRenderer>().material = MaterialDefault;
        IsActive = false;
    }

}