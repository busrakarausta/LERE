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
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;
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
