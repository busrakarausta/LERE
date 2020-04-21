using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarController : MonoBehaviour
{
    private AudioSource source;
    public CarEnder carEnder;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        carEnder.IncreaseClickCount();
        StartCoroutine(MakeBlue());
    }

    IEnumerator MakeBlue()
    {
        source.Play();
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
    }
}
