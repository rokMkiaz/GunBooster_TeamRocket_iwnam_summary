using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserState : MonoBehaviour
{

    private int userHp = 1;
    [SerializeField] private float invincibleTime=1.0f;

    private CapsuleCollider capsuleCollider;

    private void Start()
    {
        capsuleCollider = this.GetComponent<CapsuleCollider>();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && userHp>=0)
        {
            if (collision.gameObject.GetComponent<Search>().GetHP() > 0)
            {
                userHp -= collision.gameObject.GetComponent<Search>().GetDamage();
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                Invoke("TriggerON", invincibleTime);
                Debug.Log(userHp);
            }
        }


    }
    
    private void OnTriggerStay(Collider other )
    {
        if (other.tag == "EnemyBullet" && userHp >= 0)
        {
            userHp -= 1;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Invoke("TriggerON", invincibleTime);
            Debug.Log(userHp);
        }
    }
    private void OnTriggerEnter(Collider other  )
    {
  

        if (other.tag == "TrapTrigger" && userHp >= 0)
        {
            userHp -= other.GetComponent<Trap>().damage;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("TriggerON", invincibleTime);
            Debug.Log(userHp);
        }

    }


    //Invincibility Time End
    void TriggerON()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }


    public int GetUserHP()
    {
        return userHp;
    }
}
