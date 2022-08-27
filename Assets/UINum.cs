using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINum : MonoBehaviour
{
    [SerializeField] private int selectNum;
    //[SerializeField] private GameObject stageNum;


    private void Update()
    {
        //Quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Stage()
    {
        //Stage Select Scene-> MainStageScene
        GameObject.Find("StageNum(Clone)").gameObject.GetComponent<StageSelectNumber>().selectNum = this.selectNum;
        
        SceneManager.LoadScene("MainStageScene");
        DontDestroyOnLoad(GameObject.Find("StageNum(Clone)"));
        
    }
}
