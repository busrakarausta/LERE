using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JellyfishController : MonoBehaviour,IDragHandler
{
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Cave")
        {
            source.Play();
            yield return new WaitForSeconds(0.35f);
           gameObject.SetActive(false);
        }
    }
}
