using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public void OpenFirstLevel()
    {
        Application.LoadLevel(3);
    }

    public void OpenSecondLevel()
    {
        Application.LoadLevel(4);
    }

    public void OpenThirdLevel()
    {
        Application.LoadLevel(5);
    }

    public void OpenFourthLevel()
    {
        Application.LoadLevel(6);
    }

    public void OpenFifthLevel()
    {
        Application.LoadLevel(7);
    }
    
    public void backToLevels()
    {
        Application.LoadLevel(1);
    }
}

