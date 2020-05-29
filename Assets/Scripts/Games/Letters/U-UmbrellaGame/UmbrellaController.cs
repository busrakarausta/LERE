using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UmbrellaController : MonoBehaviour, IPointerDownHandler
{
    public GameObject openedUmbrella;
    public GameObject closedUmbrella;
    private AudioSource source;
    public UmbrellaEnder umbrellaEnder;
    public int clickCount = 1;


    void Awake()
    {
        source = openedUmbrella.GetComponent<AudioSource>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OpenUmbrella();
        if (clickCount == 2)
        {
            source.Play();
            umbrellaEnder.IncreaseClickCount();
        }
    }

    private void OpenUmbrella()
    {
        closedUmbrella.SetActive(false);
        openedUmbrella.SetActive(true);
        clickCount++;
    }
}
