using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class InputController : MonoBehaviour , IPointerDownHandler
{
    public RectTransform basket;
    public bool flag= false;
    public Vector3 applePos;
    public AppleManager appleManager;
    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }

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
        if(thisRect.anchoredPosition.y> basket.anchoredPosition.y)
              flag = true;
    }

    private void FallObject()
    {
        if (thisRect.anchoredPosition.y <= basket.anchoredPosition.y)
        {
            flag = false;
            applePos = basket.anchoredPosition;
            appleManager.SetCurrentApplePos(thisRect.anchoredPosition);
            transform.SetParent(basket);
            thisRect.anchoredPosition = Vector3.zero;
            return;
        }
        transform.Translate(Vector3.down*0.07f);          
    }
 



}
