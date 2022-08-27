using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageNumber : MonoBehaviour
{
    public TextMeshProUGUI text;

    int num;
    
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<TextMeshProUGUI>();
        num = GameObject.Find("StageNum(Clone)").GetComponent<StageSelectNumber>().selectNum;
        text.text = "Stage "+num;
    }


}

