using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderHP : MonoBehaviour
{
    public Text texts;
    public int myhp;
    public Slider slider;

    void Start()
    {
        
    }
    public void OnSliderChanged(float value)
    {

    }

    public void updating()
    {
        texts.text = myhp.ToString();
    }

    public void setmaxhealth()
    {
        slider.value = 0;
        slider.maxValue = 5;
    }

    public void sethealth(int health)
    {
        slider.value = health;
    }
}
