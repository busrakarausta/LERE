using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawController : MonoBehaviour, IDragHandler
{
    private AudioSource source;
    public GameObject zebra1, zebra2, zebraAfter1, zebraAfter2;
    private int count=0;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        gameObject.transform.position = pos;
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        source.Play();

        if (other.gameObject.name == "Zebra1")
        {
            yield return new WaitForSeconds(0.2f);
            zebra1.SetActive(false);
            zebraAfter1.SetActive(true);
            count++;
            gameObject.transform.localPosition = new Vector3(0, 450, 0);
        }
        else if (other.gameObject.name == "Zebra2")
        {
            yield return new WaitForSeconds(0.2f);
            zebra2.SetActive(false);
            zebraAfter2.SetActive(true);
            count++;
            gameObject.transform.localPosition = new Vector3(0, 450, 0);
        }

        if (count == 2)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
    
}
