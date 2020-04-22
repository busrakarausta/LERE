using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WatermelonManager : MonoBehaviour
{
    public GameObject knife;
    public GameObject watermelon;
    public GameObject watermelonCut;


    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }
    

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Watermelon")
        {
            yield return new WaitForSeconds(2f);
            other.gameObject.SetActive(false);
            watermelonCut.SetActive(true);
            
            knife.gameObject.SetActive(false);
        }
        LevelController.instance.OnLevelEnd();

    }
}
