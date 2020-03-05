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
        // colorını color.white yapamadım
        // onun için iç içe 2 tane image koyup koyu renkli olanı setactive ini false yaptım.
        // arkadaki yanan ışıklı resim ortaya çıktı.
        gameObject.SetActive(false);
    }
}
