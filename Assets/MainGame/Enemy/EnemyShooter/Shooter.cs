using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject mySearch;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown =1.0f;
    [SerializeField] private Transform firePos;



    private AudioSource audioSource;
    private bool myFire=false;

    private void Start()
    {
        
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mySearch.GetComponent<Search>().GetHP() > 0)
        {
            State();
        }

     

    }
    private void State()
    {
        if (mySearch.GetComponent<Search>().GetPlayerSearch() == false)
        {
            mySearch.GetComponent<Search>().SetMove(true);
            if (myFire == true) StopCoroutine("Fire");
            myFire = false;
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (mySearch.GetComponent<Search>().GetHP() > 0)
        {
            if (other.tag == "Player")
            {
                mySearch.GetComponent<Search>().SetMove(false);

                if(myFire==false)StartCoroutine("Fire");
                myFire = true;
                
            }
        }
       
    }
    IEnumerator Fire()
    {
        if (mySearch.GetComponent<Search>().GetPlayerSearch() == true && myFire == true && mySearch.GetComponent<Search>().GetHP()>0)
        {

            Vector3 v3 = firePos.position;
            v3.z = this.transform.position.z;
            if (Time.timeScale != 0) audioSource.Play();
            Instantiate(bullet, v3, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));


        
        }
         yield return new WaitForSeconds(coolDown);
         StartCoroutine("Fire");
        

    }


}
