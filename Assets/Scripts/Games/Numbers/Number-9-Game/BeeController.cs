using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BeeController : MonoBehaviour, IDragHandler
{
    public GameObject hive;
    private bool flag = false;
    public BeeEnder beeEnder;

   
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;

        if (flag)
        {
            transform.position = gameObject.transform.position;
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Hive")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.6f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }

            flag = true;
            beeEnder.IncreaseClickCount();

        }
    }
}
