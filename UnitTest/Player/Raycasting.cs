using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public Transform Target = null;


    private Ray ray; 
    private Vector3 direction; 
    private float distance=0.0f; 
  
   
    
    void Update()
    {
        direction = Target.position - this.transform.position;
        distance = Vector3.Distance(Target.position, this.transform.position);
        ray = new Ray(this.transform.position, direction);

        RaycastHit hit; //Raycast 
        if (Physics.Raycast(ray.origin, ray.direction.normalized, out hit, distance)) //out
        { 
            if(hit.collider.gameObject != this.gameObject)
            {

            }
            else
            {

            }
        }
    }

    //private void OnDrawGizmos() //Gizmo
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(ray.origin, direction.normalized*distance); 
    //}
}
