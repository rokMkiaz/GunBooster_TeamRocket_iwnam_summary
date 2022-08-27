using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_JoyStick : MonoBehaviour
{
    //JoyStick Move& Active
    private GameObject joyStick;

    void Start()
    {
        joyStick = GameObject.Find("CircleArea");
        joyStick.SetActive(false);
    }


    void Update()
    {
        if (Camera.main != null)
        {
            Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                joyStick.SetActive(true);
                if (pos.y < 0.80f) joyStick.transform.position = Input.mousePosition;
                //Debug.Log(pos.y);
            }
            else if (Input.GetMouseButton(0))
            {

            }
            else if (Input.GetMouseButtonUp(0))
            {
                joyStick.SetActive(false);

            }
        }
 
    }
}
