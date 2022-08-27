using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    [SerializeField] private float cameraYOffset = 6.0f;
    [SerializeField] private float cameraXOffset = 1.0f;
    [SerializeField] private float cameraYSpeed = 5.0f;
    [SerializeField] private float cameraXSpeed = 0.5f;

    private GameObject target;
    private GameObject player;


    
    private void Update()
    {
        
    
        if (target == null) target = GameObject.Find("Target");
        if (player == null) player = GameObject.Find("User(Clone)");

        if (player != null)
        {
            float player_target = this.transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;


            Vector3 dir = player.transform.position - this.transform.position;

            //dir.x += player_target < 0.0f ? +cameraXOffset : -cameraXOffset;
            dir.y += cameraYOffset;

            Vector3 moveVector = new Vector3(dir.x * cameraXSpeed * Time.deltaTime, dir.y * cameraYSpeed * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
    }
}
