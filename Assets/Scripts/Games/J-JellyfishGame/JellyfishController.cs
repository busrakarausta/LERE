using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JellyfishController : MonoBehaviour,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Cave")
        {
            yield return new WaitForSeconds(0.5f);
           gameObject.SetActive(false);
        }
    }
}
