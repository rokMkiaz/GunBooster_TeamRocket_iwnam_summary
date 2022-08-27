using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Search : MonoBehaviour
{
    
    //Public
    public float searchRange;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float patrolTime = 2.0f;
    [SerializeField] private bool PatrolX = true;
    [SerializeField] private bool PatrolY = true;
    [SerializeField] private float searchRangeMultiply =2.5f;
    [SerializeField] private float dieDelay = 0.0f;
    [SerializeField] private GameObject searchEffect;
    [SerializeField] private float PatrolRange=1.0f;

    //State
    [SerializeField] private int hp=1;
    [SerializeField] private bool playerSearch = false;
    [SerializeField] private bool moving = true;
    [SerializeField] private int damage = 1;
    public bool GetMove() { return moving; }
    public void SetMove(bool moving) { this.moving = moving; }
    public int GetDamage() { return damage; }
    public bool GetPlayerSearch() { return playerSearch; }
    public float GetSearchRange() { return searchRange; }
    public int GetHP() { return hp; }



    private  Vector3 myStartLocation;
    private int patrolMin=0;
    private int patrolMax=5;
    private int movementFlag =0;
    //Hitbox
    private Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    //Searchrange
    private SphereCollider searchComponent;


    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        capsuleCollider = this.gameObject.GetComponent<CapsuleCollider>();
        searchComponent = this.gameObject.GetComponent<SphereCollider>();
        searchRange = searchComponent.radius;

        if (PatrolY == false && PatrolX == true)
        {
            patrolMin = 0;
            patrolMax = 3;
        }
        if (PatrolX == false && PatrolY ==true)
        {
            patrolMin = 3;
            patrolMax = 6;
        }
        if(PatrolY== false && PatrolX==false)
        {
            patrolMax = 1;
        }
        StartCoroutine("ChangeMovement");
    }
    private void Start()
    {


        myStartLocation = this.transform.position;
    }

    void Update()
    {
        if (hp<=0)
        {
            //rigidbody.useGravity = false;
            float time = 0.0f;
            time += Time.deltaTime;
            if(time>1.0f)capsuleCollider.enabled = false;
            searchEffect.SetActive(false);
            //Debug.Log("Destroy");
            Destroy(this.gameObject, dieDelay);
            //Patrol: EnemyClass Set Moving
        }else if(moving==true && playerSearch==false)Patrol();
     

    }



    private void OnCollisionEnter(Collision damage) 
    {
        if (damage.gameObject.tag == "PlayerBullet")
        {
            hp--;

            if (playerSearch == false)
            {
                searchRange *= searchRangeMultiply;
                searchComponent.radius = searchRange;
                playerSearch = true;
            }
        }
        if (damage.collider.tag == "TrapFire")
        {
            this.hp = 0;
            Debug.Log("Fire");
        }
  
    }

    private void OnTriggerStay(Collider search)
    {
        if(search.tag=="TrapFire") //Enemy-Trap Fire Hit
        {
            search.GetComponent<BoxCollider>().isTrigger = false;
            Invoke("MonsterKillTime",0.1f);
        }

        if (hp > 0)
        {
            if (search.tag == "Player")
            {
               

                //Debug.Log("Search");
                Vector3 direction = search.transform.position - this.transform.position;
                direction.z = 0.0f;
                if (rigidbody.useGravity == true) direction.y = 0.0f;
                if (moving == true) this.transform.Translate(speed * direction.normalized * Time.deltaTime);


                Vector3 moveVelocity = Vector3.zero;
                if (direction.x < 0.0f)
                {
                    moveVelocity = Vector3.left;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (direction.x > 0.0f)
                {
                    moveVelocity = Vector3.right;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                transform.position += moveVelocity * 0.01f * Time.deltaTime;


                float distance = Vector3.Distance(search.transform.position, this.transform.position);

                //Trigger
                if (playerSearch == false && distance < searchRange * searchRangeMultiply)
                {
                    searchRange *= searchRangeMultiply;
                    searchComponent.radius = searchRange;
                    playerSearch = true;
                    searchEffect.SetActive(true);
                }

            }
        }

    }
    private void MonsterKillTime() 
    { 
        GameObject.FindGameObjectWithTag("TrapFire").GetComponent<BoxCollider>().isTrigger = true;
    }


    private void OnTriggerExit(Collider search)
    {

      
        if (playerSearch == true )
        {
            searchEffect.SetActive(false);
            searchRange /= searchRangeMultiply;
            searchComponent.radius = searchRange;
            moving = true;
            playerSearch = false;
        }
        
    }
    

    void Patrol()
    {
        float startToMy=Vector3.Distance(this.transform.position, myStartLocation);
        //Debug.Log(startToMy);
        //Debug.Log(myStartLocation);
        Vector3 moveVelocity = Vector3.zero;
        if (movementFlag == 0)
        {
            moving = false;
        }
        if (movementFlag == 1)
        {
            moving = true;
            moveVelocity = Vector3.left ;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (movementFlag == 2)
        {
            moving = true;
            moveVelocity =  Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (movementFlag == 3)
        {
            moving = true;
            moveVelocity = Vector3.up;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (movementFlag == 4)
        {
            moving = true;
            moveVelocity = Vector3.down;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (movementFlag == 5)
        {
            moving = false;
            moveVelocity = Vector3.zero;
        }

        if (startToMy > PatrolRange + 0.1) Invoke("MyPosition",0.1f);
        if (startToMy > PatrolRange && (movementFlag==1 || movementFlag == 2) )
        {
            movementFlag = movementFlag == 1 ?  2 :  1;
        }
        if (startToMy > PatrolRange && (movementFlag == 3 || movementFlag == 4))
        {
            movementFlag = movementFlag == 3 ? 4 : 3;
        }
        if (startToMy < PatrolRange) transform.position += moveVelocity * speed / 2 * Time.deltaTime;
        else transform.position -= moveVelocity * speed  * Time.deltaTime;

      

    }
    void MyPosition()
    {
        this.transform.position = myStartLocation;
      
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(patrolMin, patrolMax);

        yield return new WaitForSeconds(patrolTime);

        StartCoroutine("ChangeMovement");
    }
}
