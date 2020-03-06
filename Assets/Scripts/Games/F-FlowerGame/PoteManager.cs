using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoteManager : MonoBehaviour,IDragHandler
{
    public Transform basket;
    private bool flag = false;
    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging..");
        gameObject.transform.position = Input.mousePosition;
        if (transform.position.x >= basket.position.x && flag)
        {
            Debug.Log( gameObject.name +" accepted..");
            transform.position = basket.transform.position;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Basket")
        {
            Debug.Log( gameObject.name +" perceive..");
            flag = true;
        }
    }
}
