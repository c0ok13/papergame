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

    public void OpenFirstLevel2()
    {
        Application.LoadLevel(9);
    }

    public void OpenSecondLevel2()
    {
        Application.LoadLevel(10);
    }

    public void OpenThirdLevel2()
    {
        Application.LoadLevel(11);
    }

    public void OpenFourthLevel2()
    {
        Application.LoadLevel(12);
    }

    public void OpenFifthLevel2()
    {
        Application.LoadLevel(13);
    }

    public void backToLevels()
    {
        Application.LoadLevel(1);
    }

    public void backToLevels2()
    {
        Application.LoadLevel(8);
    }
}

