using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandPaintingController : MonoBehaviour, IPointerDownHandler
{
    public HandGameEnder handGameEnder;
    private int clickCount = 0;
    public GameObject one, two, three, four, five;

   

    public void OnPointerDown(PointerEventData eventData)
    {
        clickCount++;
        Paint(clickCount);
    }

    public void Paint(int click)
    {

        switch (click)
        {
            case 1:
                one.SetActive(true);
                break;

            case 2:
                two.SetActive(true);
                break;

            case 3:
                three.SetActive(true);
                break;

            case 4:
                four.SetActive(true);
                break;
            case 5:
                five.SetActive(true);
                break;

        }
         handGameEnder.GetClickCount(click);
    }



}
