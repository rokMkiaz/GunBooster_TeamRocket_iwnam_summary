using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controller : MonoBehaviour
{
    [SerializeField] private List<GameObject> laser;

    [SerializeField] private float delay=1.0f;
    [SerializeField] private float coolDown = 2.0f;
    private float timer=0.0f;
    private int count = 0;
    private int laserCount;

    private bool laserSwatch=true;
    private bool coolDownSwitch = false;
   

    private void Awake()
    {
        laserCount = laser.Count;
        for(int i=0;i<laser.Count;i++)
        {
            laser[i].SetActive(false);
        }
       
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (coolDownSwitch == false)
        {
            if (timer > delay)
            {
                if (count <= laserCount) count++;
              

                timer = 0.0f;
            }
        }
        else if(coolDownSwitch==true)
        {
            if(timer > coolDown)
            {
                timer = 0.0f;

                if (laserSwatch == true) laserSwatch = false;
                else if (laserSwatch == false) laserSwatch = true;

                coolDownSwitch = false;
                
            }
        }

        if (laserSwatch == true)
        {
            if (count != laserCount) laser[count].SetActive(laserSwatch);
            
            if (count == laserCount )
            {
                count = 0;
                coolDownSwitch = true;
            }
        }
        else if (laserSwatch == false)
        {
            if (count != laserCount) laser[count].SetActive(laserSwatch);

            if (count == laserCount)
            {
                
               count = 0;
               coolDownSwitch =true;
            }
        }


    }

}
