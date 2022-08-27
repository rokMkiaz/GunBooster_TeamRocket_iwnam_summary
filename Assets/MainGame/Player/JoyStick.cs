using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
    , IPointerDownHandler
    , IDragHandler
    , IPointerUpHandler
{
    private RectTransform circleArea;
    private RectTransform handler;
    private Transform target; 

    private float circleRadius = 0.0f;
    private bool bTouch = false;
    private float speed = 500.0f;

    private bool touchON=false;

    Vector3 targetMove;

    void Start()
    {
        circleArea = GameObject.Find("CircleArea").GetComponent<RectTransform>();
        handler = GameObject.Find("Handler").GetComponent<RectTransform>();
        target = GameObject.Find("Target").transform;

        //Joysitcik Circle Radius
        circleRadius = circleArea.rect.width * 0.5f;
    }

    void FixedUpdate()
    {
        if (Camera.main != null)
        {

            if (Input.GetMouseButtonDown(0))
            {
                target.position = GameObject.Find("Target").transform.position;
                if(handler==null)handler = GameObject.Find("Handler").GetComponent<RectTransform>();
                if(circleArea==null)circleArea = GameObject.Find("CircleArea").GetComponent<RectTransform>();

                touchON = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchON = false;
            }
            if (bTouch)
            {


                //Joysitcik Circle Radius
                circleRadius = circleArea.rect.width * 0.5f;
                //Camera Out 
                Vector3 pos = GameObject.FindGameObjectWithTag("PlayerCenter").transform.position;

                //if (Vector3.Distance(pos, target.transform.position) < 5)
                //{
                //    target.position += targetMove;
                //}
                //else
                //{
                    target.position = pos+targetMove.normalized*5.0f;
                //}


            }
        }
    }



    void OnTouch(Vector2 vecTouch)
    {
        Vector2 v2 = new Vector2(vecTouch.x - circleArea.position.x, vecTouch.y - circleArea.position.y);
        //vec < circleRadius
        v2 = Vector2.ClampMagnitude(v2, circleRadius);
        handler.localPosition = v2;

        //JoyStick-Cicle Move(ratio)
        float fSqr = (circleArea.position - handler.position).sqrMagnitude / (circleRadius * circleRadius);

        Vector2 v2Normal = v2.normalized;
        targetMove = new Vector3(v2Normal.x * speed * Time.deltaTime * fSqr, v2Normal.y * speed  *Time.deltaTime * fSqr, 0.0f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (touchON == true)
        { 
            OnTouch(eventData.position);
            bTouch = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
      
         OnTouch(eventData.position);
         bTouch = true;
        GameObject.Find("User(Clone)").GetComponent<Fire>().SetBFire(true); //User Fire
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        handler.localPosition = Vector2.zero;
        bTouch = false;

        GameObject.Find("User(Clone)").GetComponent<Fire>().SetBFire(false);
    }


}
