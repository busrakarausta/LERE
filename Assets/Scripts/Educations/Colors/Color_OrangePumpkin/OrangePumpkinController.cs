using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrangePumpkinController : MonoBehaviour, IPointerDownHandler
{
    public GameObject orangePumpkin;
    public OrangePumpkinEnder orangePumpkinEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;
    public void OnPointerDown(PointerEventData eventData)
    {
        MakeOrange();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }

    public void MakeOrange()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = orangePumpkin.transform.position;
        starParticle.Play();
        orangePumpkin.SetActive(true);
        orangePumpkinEnder.IncreaseClickCount(totalTouch);
    }



}
