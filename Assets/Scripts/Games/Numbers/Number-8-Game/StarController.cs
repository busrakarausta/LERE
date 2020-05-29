using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StarController : MonoBehaviour, IPointerDownHandler
{

    public StarGameEnder starGameEnder;

    public void OnPointerDown(PointerEventData eventData)
    {
        CollectStar();
    }

    public void CollectStar()
    {
        Vector3 lastScale = transform.localScale;
        Vector3 finalScale = lastScale * 1.3f;

        gameObject.SetActive(false);

        starGameEnder.IncreaseClickCount();
    }



}
