using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClick : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainStageScene");

    }
    public void Menu()
    {
        //if(GameObject.Find("StageNum") !=null)Destroy(GameObject.Find("StageNum"));
        if (GameObject.Find("StageNum(Clone)") != null) DontDestroyOnLoad(GameObject.Find("StageNum(Clone)"));
        SceneManager.LoadScene("StageSelecter");
    }

    public void Next()
    {
        GameObject.Find("StageNum(Clone)").gameObject.GetComponent<StageSelectNumber>().selectNum++;
        SceneManager.LoadScene("MainStageScene");
    }
}

