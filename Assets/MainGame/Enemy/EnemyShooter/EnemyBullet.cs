using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bulletEffect;

    [SerializeField] private float bulletSpeed = 5.0f;
    private Vector2 v2;
    private Vector2 vDir;
    private bool fly=true;
    private void Awake()
    {
        v2 = target.transform.position - startPoint.transform.position;
        vDir = v2.normalized;
    }
    void Update()
    {
        if(fly==true)this.transform.Translate(new Vector3(vDir.x, vDir.y, 0.0f) * Time.deltaTime * bulletSpeed);

        //if (this.transform.position.z > 10.0f) Destroy(this.gameObject);

    }

    private void OnTriggerEnter(Collider coll)
    {

        //Debug.Log("ONColl");
        if (coll.tag == "BaseWall")
        {
            //Debug.Log("DestroyBullet");
            bulletEffect.SetActive(true);
            fly = false;
            Destroy(this.gameObject,0.2f);
        }

        if (coll.gameObject.tag == "PlayerCenter")
        {
            bulletEffect.SetActive(true);
            fly = false;
            Debug.Log("Player Hit");
            Destroy(this.gameObject,0.2f);
        }
    }
}
