using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField] private Transform Target = null;


    private Ray ray; 
    private Vector3 direction; 
    private float distance=0.0f;

    //Player only
    public LayerMask layerMask;
    
    
    void Update()
    {
        direction = Target.position - this.transform.position;
        distance = Vector3.Distance(Target.position, this.transform.position);
        ray = new Ray(this.transform.position, direction);

        //RaycastHit hit
        if (Physics.Raycast(ray,distance,layerMask, QueryTriggerInteraction.Collide)) //out, Trigger no
        {
     
           // if(hit.collider.gameObject != Target.gameObject)
           // {
           //    
           // }

        }
    }

    //private void OnDrawGizmos() //Gizmo
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(ray.origin, direction.normalized*distance); 
    //}
}
