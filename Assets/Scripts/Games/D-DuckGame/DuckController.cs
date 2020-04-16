using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;

public class DuckController : MonoBehaviour,IDragHandler
{
    private int count = 0;
    public DuckEnder duckEnder;

    void OnTriggerEnter2D(Collider2D other) 
    {
        other.gameObject.transform.parent = gameObject.transform;

        if (other.gameObject.name == "Child1")
        {
            duckEnder.IncreaseChildCount();
            other.gameObject.transform.position= new Vector3(gameObject.transform.position.x+210f,gameObject.transform.position.y-30f , gameObject.transform.position.z);
        }
        else if (other.gameObject.name == "Child2")
        {
            duckEnder.IncreaseChildCount();
            other.gameObject.transform.position= new Vector3(gameObject.transform.position.x+340f,gameObject.transform.position.y-20f  , gameObject.transform.position.z);
        }
        else if (other.gameObject.name == "Child3")
        {
            duckEnder.IncreaseChildCount();
            other.gameObject.transform.position= new Vector3(gameObject.transform.position.x+470f,gameObject.transform.position.y-10f  , gameObject.transform.position.z);
        }
        CountControl();
    }
        
        
        public void OnDrag(PointerEventData eventData)
        {
            gameObject.transform.position = Input.mousePosition;
        }

        void CountControl()
        {
            count++;
            if (count == 3)
            {
                Debug.Log("PASS GAME");
            }
        }
}
