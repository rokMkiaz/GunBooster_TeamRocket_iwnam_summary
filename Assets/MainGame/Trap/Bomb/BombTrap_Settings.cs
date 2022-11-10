using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap_Settings : MonoBehaviour
{
    [SerializeField] private float power = 2.0f;
    [SerializeField] private float effectTimer = 0.0f;



    [SerializeField] private GameObject trapBase;
    [SerializeField] private GameObject trapObj;
    [SerializeField] private GameObject trapEffect;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider player)
    {
        //if (player.gameObject.tag == "TrapFire")
        //{
        //    trapEffect.SetActive(true);
        //    trapObj.gameObject.SetActive(false);
        //    Destroy(trapBase, effectTimer);
        //}

        if (player.gameObject.tag == "PlayerCenter")
        {
            Debug.Log("Coll");

            Vector3 v3 = player.transform.position - trapObj.transform.position;
            v3.z = 0.0f;


            player.attachedRigidbody.AddForce(v3 * power, ForceMode.Impulse);
            player.attachedRigidbody.velocity = Vector3.zero;

            this.GetComponent<Trap>().SetDamage(0);
        }
        if (player.gameObject.tag == "PlayerBullet")
        {
            trapEffect.SetActive(true);
            trapObj.gameObject.SetActive(false);
            this.GetComponent<Trap>().SetDamage(0);
            Destroy(trapBase, effectTimer);
        }

    }
    private void OnTriggerExit(Collider player)
    {

        if (player.gameObject.tag == "PlayerCenter")
        {
            trapEffect.SetActive(true);
            trapObj.gameObject.SetActive(false);
            this.GetComponent<Trap>().SetDamage(0);
            Destroy(trapBase, effectTimer);
        }

    }

    private void OnCollisionEnter(Collision player)
    {

        if (player.gameObject.tag == "PlayerCenter")
        {
            trapEffect.SetActive(true);
            trapObj.gameObject.SetActive(false);
            Destroy(trapBase, effectTimer);
            //Debug.Log("Coll");

            Vector3 v3 = player.transform.position - trapObj.transform.position;
            v3.z = 0.0f;


            player.gameObject.GetComponent<Collider>().attachedRigidbody.AddForce(v3 * power, ForceMode.Impulse);
            player.gameObject.GetComponent<Collider>().attachedRigidbody.velocity = Vector3.zero;

        }

    }
}
