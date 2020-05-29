using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrownController : MonoBehaviour,IDragHandler
{
    public Transform queen;
    private bool flag = false;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;
        if (transform.position.x >= queen.position.x && flag)
        {
            transform.position= new Vector3(queen.transform.position.x-8f, queen.transform.position.y+290f, queen.transform.position.z);
            source.Play();
            LevelController.instance.OnLevelEnd();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Girl")
        {
            flag = true;
        }
    }
}
