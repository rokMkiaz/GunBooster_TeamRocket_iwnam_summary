using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    private Rigidbody[] rigibodies;
    private bool bRigid = false;
    void Awake()
    {
        GameObject skeleton = this.gameObject;
        rigibodies = skeleton.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigibodies)
        {
            rigidbody.isKinematic =true ;
            bRigid = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (Input.GetMouseButtonUp(0) && bRigid == true)
        {
           
            Debug.Log("MouseUp");
            foreach (Rigidbody rigidbody in rigibodies)
            {
                this.gameObject.GetComponent<Aiming>().enabled = false; //Aiming false 
                rigidbody.isKinematic = false;
                bRigid = false;
            }
        }
    }
}
