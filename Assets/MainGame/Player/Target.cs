using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{


    void Update()
    {//Input.GetMouseButton(0) || 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Camera-World
          
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            //Targetposition-> Raycastingposition Moveing
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
               
                //float z = this.transform.position.z;
                //this.transform.position = new Vector3(hit.point.x, hit.point.y, z);

                //Debug.Log("LayHit");
            }
            
            
            
        }

        
    }
}
