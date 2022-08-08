using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float power = 2.0f;
    public GameObject trapBase;

  
    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "PlayerCenter")
        {
            Debug.Log("Coll");

            Vector3 v3 = player.transform.position - trapBase.transform.position;
            v3.z = 0.0f;


            player.attachedRigidbody.AddForce(v3 * power, ForceMode.Impulse);
            player.attachedRigidbody.velocity = Vector3.zero;
        }

    }
  

}
