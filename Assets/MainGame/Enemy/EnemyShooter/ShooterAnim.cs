using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAnim : MonoBehaviour
{
    [SerializeField]private GameObject enemySearch;
    [SerializeField] private GameObject exp;
    private Animator animator;

    [SerializeField] private GameObject myObject;
    [SerializeField] private GameObject myBrokenObject;

    [SerializeField] private GameObject eye_Gas;
    [SerializeField] private GameObject arm_Gas1;
    [SerializeField] private GameObject arm_Gas2;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
        myBrokenObject.SetActive(false);
    }

  
    void Update()
    {
        if (enemySearch.GetComponent<Search>().GetHP() > 0)
        {
            if (enemySearch.GetComponent<Search>().GetPlayerSearch() == true)
            {
                animator.SetFloat("Forward", 0);
                animator.SetBool("Right Aim", true);
            }
            else if (enemySearch.GetComponent<Search>().GetPlayerSearch() == false && enemySearch.GetComponent<Search>().GetMove()==true)
            {

                animator.SetFloat("Forward", 1);
                animator.SetBool("Right Aim", false);
            }
            else if(enemySearch.GetComponent<Search>().GetPlayerSearch() == false && enemySearch.GetComponent<Search>().GetMove() == false)
            {

                animator.SetFloat("Forward", 0);
                animator.SetBool("Right Aim", false);
            }
        }
        else if(enemySearch.GetComponent<Search>().GetHP()<1)
        {
            enemySearch.GetComponent<Search>().SetMove(false);
            animator.SetBool("Right Aim", false);
            animator.SetFloat("Forward", 0);
            animator.SetTrigger("Die");

            eye_Gas.SetActive(false);
            arm_Gas1.SetActive(false);
            arm_Gas2.SetActive(false);


            Invoke("Explosion", 0.1f);
            Invoke("MyDestroy", 0.1f);
            Destroy(this, 1.5f);
            
        }
    }

    private void MyDestroy()
    {
        myObject.SetActive(false);
        myBrokenObject.SetActive(true);
    }
    private void Explosion()
    {
        //this.gameObject.SetActive(false);
        exp.SetActive(true);
    }
}
