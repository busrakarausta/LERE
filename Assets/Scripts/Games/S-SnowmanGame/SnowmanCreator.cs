using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnowmanCreator : MonoBehaviour,IDragHandler
{
    public Transform bottom;
    public Transform middle;
    public Transform head;
    private int flag = 2;
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        if (transform.position.x >= bottom.position.x && transform.position.y >= bottom.position.y && flag == 0)
        {
            /*
            // transparan
            transform.position= new Vector3(bottom.transform.position.x+318f, bottom.transform.position.y+205f, bottom.transform.position.z);
            */
            transform.position= new Vector3(bottom.transform.position.x, bottom.transform.position.y+110f, bottom.transform.position.z);

        }
        else if (transform.position.x >= middle.position.x &&  transform.position.y >= middle.position.y && flag == 1)
        {
            /*
             //transparan
            transform.position= new Vector3(middle.transform.position.x, middle.transform.position.y+95f, middle.transform.position.z);
            */
            transform.position= new Vector3(middle.transform.position.x, middle.transform.position.y+100f, middle.transform.position.z);

        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (gameObject.name == "Middle" && other.gameObject.name == "Bottom")
        {
            flag = 0;
        }
        else if (gameObject.name == "Head" && other.gameObject.name == "Middle")
        {
            flag = 1;
        }
    }
}