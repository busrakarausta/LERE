using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TomatoManager : MonoBehaviour,IDragHandler
{
    public Transform basket;
    private bool flag = false;
    public TomatoBasketController basketController;
    public void OnDrag(PointerEventData eventData)     
    {
        gameObject.transform.position = Input.mousePosition;
        if (transform.position.x >= basket.position.x && flag)
        {
            transform.position = basket.transform.position;
        }
    }
   
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "ChildBasket")
        {
            basketController.IncreaseTomatoCount();
            flag = true;
        }
    }
}
