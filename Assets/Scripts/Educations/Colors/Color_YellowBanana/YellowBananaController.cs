using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YellowBananaController : MonoBehaviour, IPointerDownHandler
{
    public GameObject yellowBanana;
    public YellowBananaEnder yellowBananaEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;
    public void OnPointerDown(PointerEventData eventData)
    {
        MakeYellow();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }

    public void MakeYellow()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = yellowBanana.transform.position;
        starParticle.Play();
        yellowBanana.SetActive(true);
        yellowBananaEnder.IncreaseClickCount(totalTouch);
    }



}
