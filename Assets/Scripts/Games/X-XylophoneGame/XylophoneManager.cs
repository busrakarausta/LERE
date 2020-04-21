using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XylophoneManager : MonoBehaviour,IPointerDownHandler
{
    private AudioSource source;
    private GameObject insObj;
    public XylophoneEnder xylophonEnder;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {  
        xylophonEnder.IncreaseNoteCount();
        source.Play();
    }
    

}
