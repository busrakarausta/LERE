using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PurpleGrapesController : MonoBehaviour, IPointerDownHandler
{
    public GameObject purpleGrapes;
    public PurpleGrapesEnder purpleGrapesEnder;
    public int totalTouch = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        MakePurple();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }
    public void MakePurple()
    {
        gameObject.SetActive(false);
        purpleGrapes.SetActive(true);
        purpleGrapesEnder.IncreaseClickCount(totalTouch);
    }



}
