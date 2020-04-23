using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YellowBananaController : MonoBehaviour, IPointerDownHandler
{
    public GameObject yellowBanana;
    public YellowBananaEnder yellowBananaEnder;

    public void OnPointerDown(PointerEventData eventData)
    {
        MakeYellow();
    }

    public void MakeYellow()
    {
        gameObject.SetActive(false);
        yellowBanana.SetActive(true);
        yellowBananaEnder.IncreaseClickCount();
    }



}
