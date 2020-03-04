using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class PianoController : MonoBehaviour, IPointerDownHandler
{
    public GameObject canvas;
    public GameObject notaObject;
    private GameObject insObj;
    public Transform nota;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        createSound(gameObject);
    }

    public void CreateNota()
    {
        notaObject.SetActive(true);
        insObj=Instantiate(notaObject, nota.position, Quaternion.identity);
        insObj.transform.SetParent(nota,true);
        insObj.transform.parent = canvas.transform;

        insObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 50f);
    }

    public void createSound(GameObject gObject)
    {
        if (gObject.name == "Key_1")
        {
            Debug.Log("sound1");
            CreateNota();
        }
        else if(gObject.name == "Key_2")
        {
            Debug.Log("sound2");
            CreateNota();
        }
    }
    
}















