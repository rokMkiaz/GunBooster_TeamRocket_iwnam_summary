using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aiming : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target =null;
    private GameObject centerPosition =null;
    public GameObject gun = null;




    private Vector3 rot;
    private Vector3 velocity;
    private float turnSpeed = 180.0f;


    private void Start()
    {
      
        target = GameObject.Find("Target").transform;
         centerPosition = GameObject.Find("PlayerCenter");
    }

    void Update()
    {
        
        //Rotate
        velocity = target.position - this.transform.position;
        velocity.y = 0;
        velocity.Normalize();
        //Debug.Log(velocity);

        rot = this.transform.InverseTransformDirection(velocity);
        float turnYAmount = Mathf.Atan2(rot.x, rot.z);
        this.transform.Rotate(0, turnYAmount * Time.deltaTime * turnSpeed, 0);




        //Anim
        //Vector2 v2 = centerPosition.transform.localPosition - target.localPosition;
        //z = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        // y = 90.0f;
        // animator.SetFloat('y',y);
        // animator.SetFloat('z', z);

    }



 




}
