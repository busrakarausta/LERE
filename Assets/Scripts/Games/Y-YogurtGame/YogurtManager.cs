using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class YogurtManager : MonoBehaviour, IDragHandler
{
    public GameObject yogurt;
    public GameObject yogurtWithOnion;
    private AudioSource source;

    void Awake()
    {
        source = yogurtWithOnion.GetComponent<AudioSource>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }
    
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.name == "Yogurt")
        {
            yield return new WaitForSeconds(0.7f);
            yogurt.SetActive(false);
            yogurtWithOnion.SetActive(true);
            source.Play();
        }
        gameObject.SetActive(false);
    }

}
