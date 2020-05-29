using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrayWaterlemonController : MonoBehaviour, IPointerDownHandler
{
    public GameObject greenWaterlemon;
    public GreenWaterlemonEnder greenEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;
    public void OnPointerDown(PointerEventData eventData)
    {
        MakeGreen();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }

    public void MakeGreen()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = greenWaterlemon.transform.position;
        starParticle.Play();
        greenWaterlemon.SetActive(true);
        greenEnder.IncreaseClickCount(totalTouch);
    }



}
