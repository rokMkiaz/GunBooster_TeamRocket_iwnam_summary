using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject playStart;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, playStart.transform.position, playStart.transform.rotation);
    }


}
