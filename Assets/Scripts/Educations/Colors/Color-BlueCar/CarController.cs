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

    public void OnPointerDown(PointerEventData eventData)
    {
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
        blueCar.SetActive(true);
        carEnder.IncreaseClickCount(totalTouch);
    }



}
