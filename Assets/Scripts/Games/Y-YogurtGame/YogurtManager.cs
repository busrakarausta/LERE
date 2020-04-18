using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class YogurtManager : MonoBehaviour, IDragHandler
{
    public GameObject yogurt;
    public GameObject yogurtChild;
    private AudioSource source;
    public event Action OnLevelEnd;


    void Awake()
    {
        source = yogurtChild.GetComponent<AudioSource>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Child")
        {
            yield return new WaitForSeconds(0.1f);
            yogurtChild.SetActive(true);
            source.Play();
            OnLevelEnd?.Invoke();
        }
        yogurt.SetActive(false);
    }

}
