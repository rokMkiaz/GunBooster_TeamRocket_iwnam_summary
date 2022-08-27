using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public Slider hpbar;
    public GameObject target;
    private float maxHp=0.0f;
    private float currenthp=0.0f;

    public float GetMaxHP() { return maxHp; }
    public float GetCurrentHP() { return currenthp; }

    private void Awake()
    {
         maxHp = target.GetComponent<Search>().GetHP();
    }

    void Update()
    {
        if (hpbar != null)
        {
            currenthp = target.GetComponent<Search>().GetHP();

            hpbar.value = currenthp / maxHp;
            //Start Hpbar Hide
            if (hpbar.value == 1.0f) hpbar.gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(-100.0f, -100.0f, -1.0f));
        }
    }
}
