using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SocialPlatforms.Impl;

public class PianoController : MonoBehaviour, IPointerDownHandler
{
    public GameObject piano;
    public Transform nota;
    public PianoEnder pianoEnder;
    public GameObject notaObject;
    private GameObject insObj;
    private AudioSource source;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        pianoEnder.IncreaseNoteCount();
        createSound(gameObject);
    }

    public IEnumerator CreateNota()
    {
        insObj=Instantiate(notaObject, nota.position, Quaternion.identity);
        insObj.SetActive(true);
        insObj.transform.SetParent(nota,true);
        insObj.transform.parent = piano.transform;
        insObj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 200f);
        
        yield return new WaitForSeconds(1f);
        Destroy(insObj);
    }

    public void createSound(GameObject gObject)
    {     
        source.Play();
        Debug.Log("okey");
        StartCoroutine(CreateNota());
    }
}















