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
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.0001f;
          
           while(transform.localScale.magnitude >= finalScale.magnitude)
           {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }
           // source.Play();
            yield return new WaitForSeconds(2f);
           gameObject.SetActive(false);
        }
    }
}
