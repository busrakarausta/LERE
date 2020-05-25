using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrayWaterlemonController : MonoBehaviour, IPointerDownHandler
{
    public GameObject greenWaterlemon;
    public GreenWaterlemonEnder greenEnder;

    public void OnPointerDown(PointerEventData eventData)
    {
        MakeGreen();
    }

    public void MakeGreen()
    {
        gameObject.SetActive(false);
        greenWaterlemon.SetActive(true);
        greenEnder.IncreaseClickCount();
    }



}
