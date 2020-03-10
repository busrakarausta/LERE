using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LampController : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
         OpenLamb();
    }

    public void OpenLamb()
    {
        gameObject.SetActive(false);
    }
}
