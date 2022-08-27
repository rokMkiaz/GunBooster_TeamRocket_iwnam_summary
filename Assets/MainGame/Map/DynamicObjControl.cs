using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjControl : MonoBehaviour
{
    public List<GameObject> wall;
    public List<GameObject> activeComponents;

    private void Start()
    {
        for (int i = 0; i < activeComponents.Count; i++)
        {
            if (activeComponents[i] != null)
            {
                activeComponents[i].SetActive(false);
            }
        }
    }


    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "PlayerCenter")
        {
            for (int i = 0; i < wall.Count; i++)
            {
                if (wall[i] != null)
                {
                    wall[i].GetComponent<Rigidbody>().isKinematic = false;
                    wall[i].GetComponent<Rigidbody>().useGravity = true;
                }
            }

            for (int i = 0; i < activeComponents.Count; i++)
            {
                if(activeComponents[i]!=null)
                {
                    activeComponents[i].SetActive(true);
                }
            }
        }
    }

}
