using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrushController : MonoBehaviour, IDragHandler
{
    private bool flag = false;
    public BlueBrushGameEnder blueBrushGameEnder;
    public GameObject blueWall_1, blueWall_2;


    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        if (flag)
        {
            transform.position = gameObject.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.name)
        {
            case "GrayWall_1":
                blueWall_1.SetActive(true);
                blueBrushGameEnder.IncreaseCount();
                break;

            case "GrayWall_2":
                blueWall_2.SetActive(true);
                blueBrushGameEnder.IncreaseCount();
                break;

        }
    }
}
