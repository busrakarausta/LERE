using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputController : MonoBehaviour , IPointerDownHandler
{
    public Transform basket;
    public bool flag= false;
    public Vector3 applePos;
    public AppleManager appleManager;


    void Update()
    {
        if (flag)
        {
            FallObject();
        }          
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        appleManager.SetCurrentAppleCount();
        if(transform.position.y > basket.position.y)
              flag = true;
    }

    private void FallObject()
    {
        if (transform.position.y <= basket.position.y)
        {
            flag = false;
            applePos = basket.transform.position;
            appleManager.SetCurrentApplePos(transform.position);
            transform.SetParent(basket);
            transform.localPosition = Vector3.zero;
            return;
        }
        transform.Translate(Vector3.down* 2);          
    }
 



}
