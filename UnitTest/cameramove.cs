using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public float cameraOffset=6.0f;
    public float cameraSpeed = 5.0f;

    private GameObject player;


    private void Update()
    {
        if (player == null) player = GameObject.Find("User(Clone)");

        Vector3 dir = player.transform.position - this.transform.position;
        dir.y += cameraOffset;
        //dir.x = 0.0f;
        Vector3 moveVector = new Vector3(dir.x* cameraSpeed* Time.deltaTime,  dir.y * cameraSpeed * Time.deltaTime  , 0.0f);
        this.transform.Translate(moveVector);
    }
}
