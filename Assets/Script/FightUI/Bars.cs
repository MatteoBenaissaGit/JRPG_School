using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetHealth(int value)
    {
        HealthSlider.value = value;
    }

    public void SetMaxHealth(int value)
    {
        HealthSlider.maxValue = value;
        HealthSlider.value = value;
    }
}
