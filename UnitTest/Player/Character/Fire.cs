using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    public GameObject bullet=null;

    private Transform firePos=null;
    private GameObject target=null;
    public float reboundForce = 5.0f;

    private Rigidbody rigidbody=null;

    void Awake()
    {
        target = GameObject.Find("Target");
        firePos = GameObject.Find("Gun").transform;
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)) Debug.DrawLine(firePos.position, target.transform.position,Color.red);
        if (Input.GetMouseButtonUp(0))
        {
            //Fire
            Vector2 v2 = target.transform.localPosition - firePos.localPosition;
            float z = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
            Instantiate(bullet,firePos.position,new Quaternion(0.0f,0.0f,0.0f, 0.0f));

            //Rebound
            Vector3 v3 = firePos.position-target.transform.position;
            v3.z = 0.0f;
            rigidbody.AddForce(v3*reboundForce, ForceMode.Impulse);
            rigidbody.velocity = Vector3.zero;


        }

        //out ranger Camera
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f; 
        if (pos.x > 1f) pos.x = 0.9f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 0.9f; 
        this.transform.position = Camera.main.ViewportToWorldPoint(pos);
    


    }
}
