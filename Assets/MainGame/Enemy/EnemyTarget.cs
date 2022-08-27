using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField]private GameObject enemySearch;


    // Update is called once per frame
    void Update()
    {
        if(enemySearch.gameObject.GetComponent<Search>().GetPlayerSearch()==true)
        {
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerCenter").transform.position;
        }

    }


}
