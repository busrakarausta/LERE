using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBasketController : MonoBehaviour
{
    public GameObject basket;
    public OrangeManager orangeManager;
    private RectTransform newPosForChild;
    private int childIndex=0;
    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 newPos= orangeManager.GetCurrentOrangePos();
        if(newPos!= thisRect.anchoredPosition)
        {
            thisRect.anchoredPosition = new Vector2(newPos.x, thisRect.anchoredPosition.y);
            newPosForChild = (RectTransform)transform.GetChild(childIndex);
            newPosForChild.anchoredPosition = new Vector2((newPosForChild.anchoredPosition.x - 30 + childIndex * 20), newPosForChild.anchoredPosition.y);
            childIndex++;
        }
    }
}
