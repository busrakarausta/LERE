using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedAppleController : MonoBehaviour, IPointerDownHandler
{
    public GameObject redApple;
    public RedAppleEnder redAppleEnder;
    public int totalTouch = 0;
    public ParticleSystem starParticle;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        MakeRed();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            totalTouch++;
        }
    }

    public void MakeRed()
    {
        gameObject.SetActive(false);
        starParticle.transform.position = redApple.transform.position;
        starParticle.Play();
        redApple.SetActive(true);
        redAppleEnder.IncreaseClickCount(totalTouch);
    }



}
