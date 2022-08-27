using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FacebookTest : MonoBehaviour
{

    void Awake()
    {
        FB.Init(InitCallback, OnHideUnity);
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            Debug.Log("Facebook SDK initialized");

            FB.ActivateApp();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
    }
}
