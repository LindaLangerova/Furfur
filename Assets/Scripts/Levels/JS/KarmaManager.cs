﻿using UnityEngine;
using UnityEngine.UI;

public class KarmaManager : MonoBehaviour
{
    public Slider Slider;

    public void GetKarma(int karma)
    {
        Slider.value += karma;
    }
}