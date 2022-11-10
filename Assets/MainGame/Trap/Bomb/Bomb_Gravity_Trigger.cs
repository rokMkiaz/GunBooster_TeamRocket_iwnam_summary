using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Gravity_Trigger : MonoBehaviour
{
    public List<GameObject> Bomb;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag=="PlayerCenter")
        {
            for(int i=0; i<Bomb.Count;i++)
            {
                if (Bomb[i] != null)
                {
                    Bomb[i].GetComponent<Rigidbody>().useGravity = true;
                    Bomb[i].GetComponent<SphereCollider>().isTrigger = false;
                }
            }
        }
    }
}
