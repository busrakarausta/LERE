using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VacuumCleanerController : MonoBehaviour,IDragHandler
{
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.name == "Dirt")
        {
            source.Play();
            other.gameObject.transform.position= new Vector3(other.transform.position.x, other.transform.position.y+20f, other.gameObject.transform.position.z);
            yield return new WaitForSeconds(0.2f);
            other.gameObject.SetActive(false);
        }
    }
}
