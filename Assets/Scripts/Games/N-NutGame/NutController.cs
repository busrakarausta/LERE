using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NutController : MonoBehaviour, IPointerDownHandler
{
    public GameObject cruchedNut;
    private AudioSource source;

     void Awake()
    {
        source = cruchedNut.GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CruchNut();
    }

    public void CruchNut()
    {
        gameObject.SetActive(false);
        cruchedNut.SetActive(true);
        source.Play();
    }

 
    
}
