using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStageMission : MonoBehaviour
{
    private GameObject clearPoint;
    [SerializeField] private GameObject clearMessage;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject failMessage;

    private GameObject user;

    void Start()
    {
        clearPoint = GameObject.FindGameObjectWithTag("ClearPoint");
    }

  
    void Update()
    {
        if(user==null)user = GameObject.FindGameObjectWithTag("PlayerCenter");
        if(clearPoint.GetComponent<ClearTrigger>().GetClear()==true)
        {
            if (Time.timeScale != 0)
            { 
                GameObject.Find("StageNum(Clone)").GetComponent<StageSelectNumber>().stageClear = true;
                PlayerPrefs.SetInt("Stage" + GameObject.Find("StageNum(Clone)").GetComponent<StageSelectNumber>().selectNum, GameObject.Find("StageNum(Clone)").GetComponent<StageSelectNumber>().selectNum);
            }
            clearMessage.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);

           
            Time.timeScale = 0;
        }
        if(user != null &&user.GetComponent<UserState>().GetUserHP() <1 )
        {
            gameUI.SetActive(false);
            Invoke("End", 1.0f); 
        }
        
    }

    private void End()
    {
       
        failMessage.gameObject.SetActive(true);
        Time.timeScale = 0;
        //Destroy(this.gameObject);
    }
}
