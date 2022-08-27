using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    private GameObject Door;
    
    private bool clear = false;

    void Start()
    {
        Door = GameObject.Find("Door");
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "PlayerCenter")
        {
            Door.SetActive(false);
            clear = true;
        }
    }


    public bool GetClear()
    {
        return clear;
    }
}
