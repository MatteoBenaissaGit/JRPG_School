using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetHealth(int health)
    {
        HealthSlider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;
    }
}
