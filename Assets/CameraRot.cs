using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    Quaternion Q;
 
    void Update()
    {

        this.transform.Rotate(new Vector3(0, 3.0f * Time.deltaTime, 0));
    }
}
