using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultAnim    : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemySearch;
    [SerializeField] private GameObject exp;
    [SerializeField] private GameObject eyeEffect;

    [SerializeField] private GameObject myObject;
    [SerializeField] private GameObject myBrokenObject;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        myBrokenObject.SetActive(false);
        animator = this.GetComponent<Animator>();
        animator.SetBool("Battle Move Forward", true);
    }
    void Update()
    {
   
        if (enemySearch.GetComponent<Search>().GetHP() < 1)
        {
            enemySearch.GetComponent<Search>().SetMove(false);
        
            animator.SetBool("Battle Move Forward", false);
            animator.SetTrigger("Battle Die");
            Invoke("Explosion", 0.1f);
            Invoke("MyDestroy", 0.1f);
            Destroy(this, 1.5f);
        }
        else
        {
            enemySearch.GetComponent<Search>().SetMove(true);
            animator.SetBool("Battle Move Forward", true);
        }
    }
    void Explosion()
    {

        exp.SetActive(true);
    }
    void MyDestroy()
    {
        myObject.SetActive(false);
        myBrokenObject.SetActive(true);
    }
}
