using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PurpleGrapesController : MonoBehaviour, IPointerDownHandler
{
    public GameObject purpleGrapes;
    public PurpleGrapesEnder purpleGrapesEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;

    public void OnPointerDown(PointerEventData eventData)
    {
        MakePurple();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }
    public void MakePurple()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = purpleGrapes.transform.position;
        starParticle.Play();
        purpleGrapes.SetActive(true);
        purpleGrapesEnder.IncreaseClickCount(totalTouch);
    }



}
