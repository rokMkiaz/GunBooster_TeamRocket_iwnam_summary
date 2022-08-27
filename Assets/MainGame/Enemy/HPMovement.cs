using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPMovement : MonoBehaviour
{
    [SerializeField]private GameObject hp_bar;
    [SerializeField]private float Yoffset=0.8f;
    [SerializeField] GameObject canvas;

    // Start is called before the first frame update
    private void Start()
    {
        hp_bar.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

        if (hp_bar.GetComponent<MonsterHP>().GetMaxHP() > hp_bar.GetComponent<MonsterHP>().GetCurrentHP())
        {
            canvas.SetActive(true);
            hp_bar.SetActive(true);
            hp_bar.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0, Yoffset, 0));
        }

    }
}
