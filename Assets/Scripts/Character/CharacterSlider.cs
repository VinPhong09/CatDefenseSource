using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CharacterSlider
{
    public SliderType sliderType;
    public Slider slider;
}
public enum SliderType
{
    HealthBar,
    ExpBar,
    EnergyBar,
}
