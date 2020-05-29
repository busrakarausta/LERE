using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class OrangeInputController : MonoBehaviour , IPointerDownHandler
{
    public RectTransform basket;
    public bool flag= false;
    public Vector3 orangePos;
    public OrangeManager orangeManager;
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
        orangeManager.SetCurrentOrangeCount();
        if (thisRect.anchoredPosition.y > basket.anchoredPosition.y)
              flag = true;
    }

    private void FallObject()
    {
        if (thisRect.anchoredPosition.y <= basket.anchoredPosition.y)
        {
            flag = false;
            orangePos = basket.anchoredPosition;
            orangeManager.SetCurrentOrangePos(thisRect.anchoredPosition);
            transform.SetParent(basket);
            transform.localPosition = Vector3.zero;
            return;
        }
        transform.Translate(Vector3.down* 0.07f);          
    }
 



}
