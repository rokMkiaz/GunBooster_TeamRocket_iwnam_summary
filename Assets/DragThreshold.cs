using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragThreshold : MonoBehaviour
{
    private const float inchToCm = 2.54f;
    private EventSystem eventSystem = null;

    private readonly float dragThresholdCM = 1.5f;

    private void SetDragThreshold()
    {
        if (eventSystem != null)
        {
            eventSystem.pixelDragThreshold = (int)(dragThresholdCM * Screen.dpi / inchToCm);
        }
    }

    void Awake()
    {
        SetDragThreshold();
    }
 
}
