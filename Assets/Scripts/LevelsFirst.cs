﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsFirst : MonoBehaviour
{
    public void OpenBasicLevels()
    {
        Application.LoadLevel(2);
    }

    public void OpenSimpleLevels()
    {
        Application.LoadLevel(3);
    }

    public void OpenAdvancedLevels()
    {
        Application.LoadLevel(4);
    }

    public void returnToMenu()
    {
        Application.LoadLevel(0);
    }
}
