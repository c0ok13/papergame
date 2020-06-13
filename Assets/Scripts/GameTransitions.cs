using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameTransitions : MonoBehaviour
{
    public GameObject pause;

    public string nextScene;

    public void backLevels()
    {
        Application.LoadLevel(2);
    }

    public void backLevels2()
    {
        Application.LoadLevel(8);
    }

    public void backLevels3()
    {
        Application.LoadLevel(14);
    }

    public void openPause()
    {
        pause.SetActive(!pause.activeSelf);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void restardLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        MovePiece.piecePos = -1;
    }
}
 