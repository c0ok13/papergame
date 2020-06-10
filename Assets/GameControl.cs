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

    
    private List<Vector2> initalPosition = new List<Vector2>();

    [SerializeField]
    private GameObject[] stars;

    [SerializeField]
    private GameObject nextLevel;

    [SerializeField]
    private GameObject winBorder;

    
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
        timer.GetComponent<UnityEngine.UI.Text>().text  = "" + Mathf.Round(timeLeft);
        
        foreach (Transform transform in pictures)
        {
            Debug.Log(transform.position.z);
            initalPosition.Add(transform.position);
        }
        foreach (Transform transform in pictures)
        {
            System.Random random = new System.Random();
            int index = random.Next(initalPosition.Count);
            transform.position = initalPosition[index];
            initalPosition.RemoveAt(index);
            
            Quaternion startRotation = transform.rotation ;
            Quaternion endRotation = Quaternion.Euler( new Vector3(0, 0, random.Next(0, 3) * 90) ) * startRotation ;
            transform.rotation = endRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject pause = GameObject.Find("Pause");
        if(pause == null){            
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
                if(PlayerPrefs.GetInt(levelPack + "" + (level - 1) + "") >j)
                {
                    PlayerPrefs.SetInt(levelPack + "" + (level - 1) + "", j);
                }
                winText.SetActive(true);   
                nextLevel.SetActive(true);  
                reload.SetActive(true);    
                winBorder.SetActive(true);    
            }
        }

    }
}
