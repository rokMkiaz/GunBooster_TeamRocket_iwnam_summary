using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]private GameObject playStart;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject subCamera;

    [SerializeField] private List<GameObject> stage;
    [SerializeField] GameObject UI;



  private GameObject stageNum;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        subCamera.SetActive(false);
        //TEST Mode
        //playStart = GameObject.Find("PlayerStart");
        //Instantiate(player, playStart.transform.position, playStart.transform.rotation);
    }

    void Start()
    {
        stageNum = GameObject.Find("StageNum(Clone)");
        stage[stageNum.GetComponent<StageSelectNumber>().selectNum].SetActive(true);
    

        playStart = GameObject.Find("PlayerStart");
        Instantiate(player, playStart.transform.position, playStart.transform.rotation);

        UI.SetActive(true);
    }

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
     
            if (GameObject.FindGameObjectWithTag("PlayerCenter").gameObject.GetComponent<UserState>().GetUserHP() < 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("Target"),0.5f);
                Destroy(GameObject.FindGameObjectWithTag("Respawn"),0.5f);
 
                Destroy(GameObject.FindGameObjectWithTag("Player"),0.5f);
          
            }
        }
    }
    private void SetSubCamera()
    {
        subCamera.SetActive(true);
    }
    private void CameraDestroy()
    {
     
        Destroy(Camera.main);
    }

}
