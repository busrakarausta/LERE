using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UmbrellaController : MonoBehaviour, IPointerDownHandler
{
    public GameObject openedUmbrella;
    public GameObject closedUmbrella;
    private AudioSource source;
    private int clickCount = 0;
    
    void Awake()
    {
        source = openedUmbrella.GetComponent<AudioSource>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(clickCount);
        if (clickCount <= 2)
        {
            OpenUmbrella();
        }
        else
        {
            Debug.Log("pass game.");
        }
    }

    private void OpenUmbrella()
    {
        clickCount++;
        closedUmbrella.SetActive(false);
        openedUmbrella.SetActive(true);
        source.Play();
    }
}
