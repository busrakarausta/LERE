using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnowmanCreator : MonoBehaviour,IDragHandler
{
    public RectTransform bottom;
    public Transform middle;
    public Transform head;
    public int up=150;

    private int siblingIndex;
    private float maxX,minX;
    private int flag = 2;

    void Awake()
    {
        siblingIndex = transform.GetSiblingIndex();
        minX = bottom.rect.xMin;
        maxX = bottom.rect.xMax;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(siblingIndex == 1)
        {

        }

        else if(siblingIndex==2)
        {

        }

    }


}