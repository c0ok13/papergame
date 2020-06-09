using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartPlay : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void OpenGallery()
    {
        Application.LoadLevel(1);
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
