using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Settings : MonoBehaviour
{
    [SerializeField] private GameObject trapEffect;


    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlayerCenter") != null)
        {
            if (trapEffect.transform.position != GameObject.FindGameObjectWithTag("PlayerCenter").gameObject.transform.position) trapEffect.SetActive(false); ;
        }

    }
  
    private void OnTriggerStay(Collider player)
    {

        if (player.gameObject.tag == "PlayerCenter")
        {
            trapEffect.transform.position=player.transform.position;
            trapEffect.SetActive(true);
        }


    }


}
