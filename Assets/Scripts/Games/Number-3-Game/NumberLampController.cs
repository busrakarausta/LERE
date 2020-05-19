using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NumberLampController : MonoBehaviour, IPointerDownHandler
{
    public GameObject lampOpen;
    public NumberLampEnder numberLampEnder;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(OpenLamp());
    }

    public IEnumerator OpenLamp()
    {
        Vector3 lastScale = transform.localScale;
        Vector3 finalScale = lastScale * 1.3f;


        gameObject.SetActive(false);
        lampOpen.SetActive(true);

        while (lampOpen.transform.localScale.magnitude <= finalScale.magnitude)
        {
            lampOpen.transform.localScale = transform.localScale * 1.1f;
            yield return new WaitForSeconds(0.2f);
        }
        numberLampEnder.IncreaseClickCount();
    }



}
