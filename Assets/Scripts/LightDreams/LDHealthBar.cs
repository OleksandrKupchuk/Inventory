﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LDHealthBar : MonoBehaviour
{
    public void AddHealth(int value)
    {
        GetComponent<Slider>().value += value;
    }
}
