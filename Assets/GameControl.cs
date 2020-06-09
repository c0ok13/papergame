using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    public GameObject[] objects;

    [SerializeField]
    private GameObject winText;

    // Start is called before the first frame update
    public static bool youWin;
    void Start()
    {
        winText.SetActive(false);
        youWin = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        bool loopCheck = true;
        foreach (Transform picture in pictures)
        {
            if(!(picture.gameObject.GetComponent<MovePiece>().locked)){
                loopCheck = false;
            }
        }

        if(loopCheck){
            youWin = true;
            winText.SetActive(true);    
        }
        /*if( pictures[0].rotation.z == 00 && pictures[0].gameObject.GetComponent<MovePiece>().locked &&
            pictures[1].rotation.z == 00 && pictures[1].gameObject.GetComponent<MovePiece>().locked &&
            pictures[2].rotation.z == 00 && pictures[2].gameObject.GetComponent<MovePiece>().locked &&
            pictures[3].rotation.z == 00 && pictures[3].gameObject.GetComponent<MovePiece>().locked
        )
        {
            youWin = true;
            winText.SetActive(true);
        }*/
    }
}
