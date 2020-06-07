using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarController : MonoBehaviour, IPointerDownHandler
{
    public GameObject blueCar;
    public CarEnder carEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;
    public void OnPointerDown(PointerEventData eventData)
    {
        totalTouch++;
        MakeBlue();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }

    public void MakeBlue()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = blueCar.transform.position;
        starParticle.Play();
        blueCar.SetActive(true);
        carEnder.IncreaseClickCount(totalTouch);
    }



}
