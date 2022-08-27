using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectNumber : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public int selectNum;

    public bool stageClear=false;
    public struct ClearNumList
    {

        public int stageNumber;
        public bool stageClearTrue;
    };
    public List<ClearNumList> clearNumLists=null;
    private void Awake()
    {
        clearNumLists=new List<ClearNumList>();
    }


    private void Update()
    {
        
        if (stageClear == true)
        {
            ClearNumList CN = new ClearNumList();
            CN.stageNumber = selectNum;
            CN.stageClearTrue = stageClear;

            clearNumLists.Add(CN);

            stageClear=false;

            for (int i = 0; i < clearNumLists.Count; i++)
            {
                Debug.Log(clearNumLists[i].stageNumber);
            }
        };
    }


}
