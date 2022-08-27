using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour
  
{

    [SerializeField] private GameObject bullet = null;
    [SerializeField] private float reboundForce = 5.0f;

    private Transform firePos = null;
    private GameObject target = null;
    private AudioSource audioSource;

    private Rigidbody rigidBody;

    private float timer = 0.0f;
    [SerializeField] private float fireDelay = 0.5f;


    //Fire  Trigger
    private bool bFire = false;
    public bool SetBFire(bool bfire) { return this.bFire = bfire; }

    void Awake()
    {
        target = GameObject.Find("Target");
        firePos = GameObject.FindGameObjectWithTag("PlayerCenter").transform;
        rigidBody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) Debug.DrawLine(firePos.position, target.transform.position, Color.red);
        //if (Input.GetMouseButtonDown(0)) if (timer != 0.0f) GunFire();
        //if (Input.GetMouseButton(0))
        //{
        //    timer += Time.deltaTime;
        //    if (timer > fireDelay) GunFire();
        //}


        if (bFire)
        {
            timer += Time.deltaTime;
            if (timer > fireDelay) GunFire();
        }


    }

    private void GunFire()
    {
        if (Time.timeScale != 0) audioSource.Play();

        //Fire
        Vector2 v2 = target.transform.localPosition - firePos.localPosition;
        float z = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
        Instantiate(bullet, firePos.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

        //Rebound
        Vector3 v3 = firePos.position - target.transform.position;
        //v3 = v3.normalized;
        v3.z = 0.0f;

        //this.transform.position += reboundForce * v3;
       
        rigidBody.AddForce(v3 * reboundForce, ForceMode.Impulse);
        rigidBody.velocity = Vector3.zero;
        timer = 0.0f;
    }







}
