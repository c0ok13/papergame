using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
         
    [SerializeField]
    private GameObject loseText;

    [SerializeField]
    private float timeLeft;
    
    public GameObject timer;
    

    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;

    
    [SerializeField]
    private GameObject[] stars;

    [SerializeField]
    private GameObject nextLevel;

    
    [SerializeField]
    private GameObject reload;

    public int levelPack;
    // Start is called before the first frame update
    public int level;
    public static bool youWin;
    void Start()
    {
        PlayerPrefs.SetInt("LevelPassed", 1);
        winText.SetActive(false);
        youWin = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeLeft -= Time.deltaTime;
        timer.GetComponent<UnityEngine.UI.Text>().text  = "" + Mathf.Round(timeLeft);
        if(timeLeft < 0)
        {
            foreach (Transform picture in pictures)
            {
                picture.gameObject.GetComponent<MovePiece>().locked = true;
            }
            timer.SetActive(false);
            loseText.SetActive(true);
            reload.SetActive(true);  
        }


        bool loopCheck = true;
        foreach (Transform picture in pictures)
        {
            if(!(picture.gameObject.GetComponent<MovePiece>().locked)){
                loopCheck = false;
            }
        }
        if(loopCheck){
            youWin = true;
            timer.SetActive(false);
            //levelLockSystem.
            if(PlayerPrefs.GetInt("LevelPassed" + levelPack) < level){
                PlayerPrefs.SetInt("LevelPassed" + levelPack, level);
            }
            int j = 0;
            for(int i = 0; i < timeLeft / 30; i++){
                stars[i].SetActive(true);
               
                j++;
                if(i == 2){
                    break;
                }
            }
            PlayerPrefs.SetInt(levelPack + "" + (level - 1) + "", j);
            winText.SetActive(true);   
            nextLevel.SetActive(true);  
            reload.SetActive(true);    
        }

    }
}
