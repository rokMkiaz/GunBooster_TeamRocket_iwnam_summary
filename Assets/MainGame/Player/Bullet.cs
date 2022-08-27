using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private GameObject bulletEffect;
    [SerializeField] private float bulletSpeed = 10.0f;
    private GameObject startPoint;
    private GameObject target;

    private SphereCollider sphereCollider;

    private Vector2 v2;
    private Vector2 vDir;
    private bool fly=true;
    private void Awake()
    {
        startPoint = GameObject.Find("Gun");
        target = GameObject.Find("Target");

        v2 = target.transform.position - startPoint.transform.position;
        vDir = v2.normalized;
        sphereCollider = this.GetComponent<SphereCollider>();
    }
    void Update()
    {
        
       
        if(fly ==true)this.transform.Translate(new Vector3(vDir.x, vDir.y, 0.0f) * Time.deltaTime* bulletSpeed);
        //Camera Out Destroy
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //if (pos.x < 0f) Destroy(this.gameObject);
        //if (pos.x > 1f) Destroy(this.gameObject);
        //if (pos.y < 0f) Destroy(this.gameObject);
        //if (pos.y > 1f) Destroy(this.gameObject);

    }
 
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //Debug.Log("HitEnemy");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject, 0.2f);

        }

        if (coll.gameObject.tag == "BaseWall")
        {
            //Debug.Log("DestroyBullet");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject, 0.2f);
        }

    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "BaseWall")
        {
            //Debug.Log("DestroyBullet");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject, 0.2f);
        }
    }
    private void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Enemy")
        {
            //Debug.Log("HitEnemy");
            sphereCollider.isTrigger = false;
        

        }
       
        if (coll.tag == "BaseWall")
        {
            //Debug.Log("DestroyBullet");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject,0.2f);
        }
        if (coll.gameObject.tag == "TrapTrigger")
        {
            //Debug.Log("HitEnemy");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject, 0.2f);

        }
    }
    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "BaseWall")
        {
            //Debug.Log("DestroyBullet");
            fly = false;
            bulletEffect.SetActive(true);
            Destroy(this.gameObject, 0.2f);
        }
    }




}
