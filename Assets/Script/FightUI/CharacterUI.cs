using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{

    public Material MaterialOutline;
    public Material MaterialDefault;

    public void Outline()
    {
        GetComponent<SpriteRenderer>().material = MaterialOutline;
    }

    public void UnOutline()
    {
        GetComponent<SpriteRenderer>().material = MaterialDefault;
    }

}