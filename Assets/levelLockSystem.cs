﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelLockSystem : MonoBehaviour
{
    public Button[] levels;

    public GameObject score;

    [SerializeField]
    private GameObject[] stars;

    public int totalScore;
    public int levelPack;
    // Start is called before the first frame update
    void Start()
    {        
        totalScore = 0;
        foreach (var item in levels.Select((value, index) => new { Value = value, Index = index }))
        {
            int currentLevel = item.Index;
            Button level = item.Value;
            int starCnt = PlayerPrefs.GetInt(levelPack + "" + currentLevel + "");
            for(int i = 0; i < starCnt; i++){
                GameObject  ChildGameObject1 = stars[currentLevel].transform.GetChild(i).gameObject;
                ChildGameObject1.SetActive(true);
                totalScore++;
            }
            if(PlayerPrefs.GetInt("LevelPassed" + levelPack) < currentLevel){
                level.interactable = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<UnityEngine.UI.Text>().text  = totalScore + "/15";
    }
}
