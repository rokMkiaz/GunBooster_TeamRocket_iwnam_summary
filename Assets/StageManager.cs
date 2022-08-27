using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject stageNum;

 
    void Start()
    {
        if (GameObject.Find("StageNum(Clone)") == null)
        {
            Instantiate(stageNum, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

            GameObject.Find("StageNum(Clone)").GetComponent<StageSelectNumber>().selectNum = this.GetComponent<StageData>().activeStage;
            
            //DemoPlay 시 지우기
            SceneManager.LoadScene("MainStageScene");
            DontDestroyOnLoad(GameObject.Find("StageNum(Clone)"));
        }
    }


}
