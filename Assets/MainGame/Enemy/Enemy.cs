using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject searchAI;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        this.transform.position = searchAI.transform.position;
    }
}
