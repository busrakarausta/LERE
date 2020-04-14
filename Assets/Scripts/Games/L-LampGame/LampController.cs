using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LampController : MonoBehaviour, IPointerDownHandler
{
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(OpenLamb());
    }

    IEnumerator OpenLamb()
    {
        source.Play();
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
    }
}
