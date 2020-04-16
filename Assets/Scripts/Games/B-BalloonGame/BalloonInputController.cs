using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

public class BalloonInputController : MonoBehaviour, IPointerDownHandler
{
    public Transform balloon;      
    public Transform rock;
    private Rigidbody2D balloonRigidbody2D;
    private Rigidbody2D rockRigidbody2D;
    private float destroyTime = 13f;

    public void Awake()
    {
        balloonRigidbody2D = balloon.GetComponent<Rigidbody2D>();
        rockRigidbody2D = rock.GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        Fly();
        StartCoroutine(WaitForDestroy());
    }

   private void Fly()
    {
        if (transform.position.y <= balloon.position.y)
        {
            Debug.Log(balloon.name + " flying..");
            balloonRigidbody2D.velocity = new Vector2(0f, 75f); // Balloon flying.
            rockRigidbody2D.velocity = new Vector2(0f, -90f); // Rock falling.
        }
    }
   
   private IEnumerator WaitForDestroy()
   {
       yield return new WaitForSeconds(destroyTime);
       Destroy(balloon.gameObject);
   }
}
