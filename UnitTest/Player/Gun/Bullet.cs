using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject startPoint;
    private GameObject target;

    [SerializeField] private float bulletSpeed = 10.0f;
    private Vector2 v2;
    private Vector2 vDir;
    private void Awake()
    {
        startPoint = GameObject.Find("Gun");
        target = GameObject.Find("Target");

        v2 = target.transform.position - startPoint.transform.position;
        vDir = v2.normalized;
    }
   
    void Update()
    {
        
        this.transform.Translate(new Vector3(vDir.x, vDir.y, 0.0f) * Time.deltaTime* bulletSpeed);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) Destroy(this.gameObject);
        if (pos.x > 1f) Destroy(this.gameObject);
        if (pos.y < 0f) Destroy(this.gameObject);
        if (pos.y > 1f) Destroy(this.gameObject);

    }


 
    private void OnCollisionEnter(Collision coll)
    {
   
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("HitEnemy");
            Destroy(this.gameObject);


        }


    }
    private void OnTriggerEnter(Collider coll)
    {

        //Debug.Log("ONColl");
        if (coll.tag == "BaseWall")
        {
            Debug.Log("DestroyBullet");
            Destroy(this.gameObject);
        }
    }




}
