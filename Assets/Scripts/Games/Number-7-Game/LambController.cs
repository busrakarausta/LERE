﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LambController : MonoBehaviour, IDragHandler
{

    private bool flag = false;
    public LambEnder lambEnder;

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
        if (other.gameObject.name == "River")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.6f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }

            flag = true;
            lambEnder.IncreaseCount();

        }
    }
}
