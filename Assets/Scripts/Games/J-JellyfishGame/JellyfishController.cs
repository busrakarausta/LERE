using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JellyfishController : MonoBehaviour, IDragHandler
{
    private AudioSource source;
    public JellyfishEnder jellyfishEnder;

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
        if (other.gameObject.name == "Cave")
        {
            Vector3 lastScale = transform.localScale;
            Vector3 finalScale = lastScale * 0.1f;

            while (transform.localScale.magnitude >= finalScale.magnitude)
            {
                transform.localScale = transform.localScale * 0.9f;
                yield return new WaitForSeconds(0.1f);
            }
            gameObject.SetActive(false);
            source.Play();
            jellyfishEnder.IncreaseJellyfishCount();
        }
    }
}