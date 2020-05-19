﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoseManager : MonoBehaviour, IDragHandler
{
    public Transform mom;
    private bool flag = false;
    public MomController momController;

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        if (flag)
        {
            transform.position = mom.transform.position;
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Mom")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.5f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }
            flag = true;
            momController.IncreaseRoseCount();

        }
    }
}
