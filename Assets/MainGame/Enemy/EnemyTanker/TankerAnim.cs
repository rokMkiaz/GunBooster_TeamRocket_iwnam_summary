using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemySearch;
    [SerializeField] private GameObject exp;
    [SerializeField] private GameObject shieldEffect;
    [SerializeField] private GameObject shield_bullet;

    [SerializeField] private GameObject arm_Aura1;
    [SerializeField] private GameObject arm_Aura2;
    [SerializeField] private GameObject myObject;
    [SerializeField] private GameObject myBrokenObject;

    private Animator animator;

    private int motion=0;
    private bool warMode = false;
    [SerializeField]private float cooldown=0.0f;
 

    void Start()
    {
        animator = this.GetComponent<Animator>();
        myBrokenObject.SetActive(false);
        StartCoroutine("DefendMotion");

    
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySearch.GetComponent<Search>().GetPlayerSearch() == false) warMode = false;
        if (enemySearch.GetComponent<Search>().GetHP() > 1)
        {
            if (enemySearch.GetComponent<Search>().GetPlayerSearch() == false && warMode==false)
            {
                //motion = 0;
                shieldEffect.SetActive(false);
                animator.SetBool("Defend", false);
                animator.SetBool("Run", false);

                if (enemySearch.GetComponent<Search>().GetMove() == true) animator.SetBool("Walk", true);
                else if(enemySearch.GetComponent<Search>().GetMove() ==false)
                {
                    animator.SetBool("Walk", false);
                   
                    enemySearch.GetComponent<Search>().SetMove(true);
                }
            }
            if(enemySearch.GetComponent<Search>().GetPlayerSearch() == true)
            {
                if(warMode==false)warMode = true;
                animator.SetBool("Walk", false);
                if (motion == 0)
                {
                    if (enemySearch.GetComponent<Search>().GetPlayerSearch() == true) enemySearch.GetComponent<Search>().SetMove(true);
                    animator.SetBool("Defend", false);
                    animator.SetBool("Run", true);
                    shieldEffect.SetActive(false);
                }
                if (motion == 1)
                {
                    //Debug.Log("Defend");
                    if(enemySearch.GetComponent<Search>().GetPlayerSearch() == true)enemySearch.GetComponent<Search>().SetMove(false);
                    animator.SetBool("Run", false);
                    animator.SetBool("Defend", true);
                    shieldEffect.SetActive(true);
                }
            }
        }
        else if (enemySearch.GetComponent<Search>().GetHP() < 1)
        {
            enemySearch.GetComponent<Search>().SetMove(false);
            animator.SetBool("Run", false);
            animator.SetBool("Defend", false);
            animator.SetBool("Walk", false);
            shieldEffect.SetActive(false);

            arm_Aura1.SetActive(false);
            arm_Aura2.SetActive(false);


            Invoke("MyDestroy", 0.1f);
            Invoke("Explosion", 0.1f);
          

            animator.SetTrigger("Die");
            Destroy(this, 1.5f);
        }
    }

    void MyDestroy()
    {
        myObject.SetActive(false);
        myBrokenObject.SetActive(true);
    }
    void Explosion()
    {

        exp.SetActive(true);
    }

    IEnumerator DefendMotion()
    {
      
        motion = Random.Range(0, 2);
     
        yield return new WaitForSeconds(cooldown);
        StartCoroutine("DefendMotion");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerBullet" && enemySearch.GetComponent<Search>().GetPlayerSearch()==true)
        {
            if (motion == 1)
            {

                shield_bullet.SetActive(true);
                Destroy(other.gameObject);
                Invoke("ShieldEffect_RE", 0.1f);
            }
           
        }
    }

    private void ShieldEffect_RE()
    {
        shield_bullet.SetActive(false);
    }

}
