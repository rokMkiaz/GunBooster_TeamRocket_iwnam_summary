using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Search : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int hp=1;
    [SerializeField] private float patrolTime = 2.0f;
    private int movementFlag =0;

    private void Awake()
    {
        StartCoroutine("ChangeMovement");
    }

    void Update()
    {
      
        if(hp<=0)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }

        //Patrol
        Vector3 moveVelocity = Vector3.zero;
        if(movementFlag==1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (movementFlag == 3)
        {
            moveVelocity = Vector3.up;
            transform.localScale = new Vector3(1, -1, 1);
        }
        if (movementFlag == 4)
        {
            moveVelocity = Vector3.down;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * speed/2 * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision damage)
    {
        if (damage.gameObject.tag == "PlayerBullet")
        {
            hp--;
        }
   
    }


    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            Debug.Log("Search");
            Vector3 direction = player.transform.position-this.transform.position;
            direction.z = 0.0f;
            this.transform.Translate(speed * direction.normalized * Time.deltaTime );

        }

    }


    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 5);


        yield return new WaitForSeconds(patrolTime);

        StartCoroutine("ChangeMovement");
    }
}
