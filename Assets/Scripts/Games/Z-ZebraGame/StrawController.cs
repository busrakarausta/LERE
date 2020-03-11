using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawController : MonoBehaviour, IDragHandler
{
    public GameObject zebra1, zebra2, zebraAfter1, zebraAfter2;
    
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Zebra1")
        {
            yield return new WaitForSeconds(0.2f);
            zebra1.SetActive(false);
            zebraAfter1.SetActive(true);
        }
       else if (other.gameObject.name == "Zebra2")
        {
            yield return new WaitForSeconds(0.2f);
            zebra2.SetActive(false);
            zebraAfter2.SetActive(true);
        }
        gameObject.transform.localPosition= new Vector3(0, 450,0);

    }
    
}
