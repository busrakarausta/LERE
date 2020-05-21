using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CupcakeController : MonoBehaviour, IDragHandler
{
    private bool flag = false;
    public CupcakeGameEnder cupcakeGameEnder;


    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        if (flag)
        {
            transform.position = gameObject.transform.position;
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "CakePlate")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.7f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }

            flag = true;
            cupcakeGameEnder.IncreaseCount();

        }
    }
}
