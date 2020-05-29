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


    void Awake()
    {
        source = yogurtChild.GetComponent<AudioSource>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Child")
        {
            yogurt.SetActive(false);
            yogurtChild.SetActive(true);
            source.Play();
            LevelController.instance.OnLevelEnd();
        }
    }

}
