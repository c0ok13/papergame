using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransitions : MonoBehaviour
{
    public GameObject pause;

    public void backLevels()
    {
        Application.LoadLevel(2);
    }

    public void openPause()
    {
        pause.SetActive(!pause.activeSelf);
    }
}
 