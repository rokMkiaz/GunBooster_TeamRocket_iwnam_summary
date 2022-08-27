using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //저장 입출입
using System;

public class StageData : MonoBehaviour
{
    [SerializeField]private List<GameObject> stageUI;

    public int activeStage=1;
    private void Awake()
    {
        for(int i=1;i<stageUI.Count+1;i++)
        {
            if (PlayerPrefs.GetInt("Stage" + i) != 0)
            {
                stageUI[i].SetActive(true);
                activeStage=i+1;

                Debug.Log(activeStage);
            }
        }
   
    }


}
