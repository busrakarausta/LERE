using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrangePumpkinController : MonoBehaviour, IPointerDownHandler
{
    public GameObject orangePumpkin;
    public OrangePumpkinEnder orangePumpkinEnder;

    public void OnPointerDown(PointerEventData eventData)
    {
        MakeOrange();
    }

    public void MakeOrange()
    {
        gameObject.SetActive(false);
        orangePumpkin.SetActive(true);
        orangePumpkinEnder.IncreaseClickCount();
    }



}
