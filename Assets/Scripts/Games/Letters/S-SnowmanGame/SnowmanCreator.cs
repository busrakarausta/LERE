using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnowmanCreator : MonoBehaviour, IDragHandler
{
    private static int fixedSiblingCount=0;

    public RectTransform bottom;
    public RectTransform middle;


    private int siblingIndex;
    private RectTransform thisRect;

    void Awake()
    {
        fixedSiblingCount = 0;
        siblingIndex = transform.GetSiblingIndex();
        thisRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        siblingIndex = transform.GetSiblingIndex();

        if(siblingIndex == 0 ) //head
        {
            thisRect.localPosition = new Vector2(bottom.localPosition.x, bottom.localPosition.y + bottom.sizeDelta.y/2 + middle.sizeDelta.y+ thisRect.sizeDelta.y/2-100);
            fixedSiblingCount++;

        }
        else 
        {
            thisRect.localPosition = new Vector2(bottom.localPosition.x, bottom.localPosition.y + bottom.sizeDelta.y / 2 + thisRect.sizeDelta.y / 2-100);
            fixedSiblingCount++;
        }

        if (fixedSiblingCount == 2)
        {
            LevelController.instance.OnLevelEnd();
        }

    }


}
