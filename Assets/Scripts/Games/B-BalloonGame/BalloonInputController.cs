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
    private float destroyTime = 8f;
    private float waitTime = 4f;
    public BalloonEnder balloonEnder;
    public int clickCount = 0;

    public void Awake()
    {
        balloonRigidbody2D = balloon.GetComponent<Rigidbody2D>();
        rockRigidbody2D = rock.GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        Fly();

        StartCoroutine(WaitForLevelEnd());
        if (clickCount == 3)
        {
            balloonEnder.IncreaseClickCount();
        }
        StartCoroutine(WaitForDestroy());
    }

    private void Fly()
    {
        if (transform.position.y <= balloon.position.y)
        {
            balloonRigidbody2D.velocity = new Vector2(0f, 100f); 
            rockRigidbody2D.velocity = new Vector2(0f, -100f);
        }
        clickCount++;
    }
   
   private IEnumerator WaitForDestroy()
   {
       yield return new WaitForSeconds(destroyTime);
       Destroy(balloon.gameObject);
   }

    private IEnumerator WaitForLevelEnd()
    {
        yield return new WaitForSeconds(waitTime);

    }
}
