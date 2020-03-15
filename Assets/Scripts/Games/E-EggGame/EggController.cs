using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class EggController : MonoBehaviour, IPointerDownHandler
{
    public GameObject panEmpty;
    public GameObject crushedEgg;
    public GameObject panEgg;
    private Rigidbody2D crushedEggRB;
    private AudioSource source;


    void Awake()
    {
       crushedEggRB = crushedEgg.GetComponent<Rigidbody2D>();
       source = GetComponent<AudioSource>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        source.Play();
        StartCoroutine( CruchEgg());
    }

    public IEnumerator CruchEgg()
    {
        crushedEgg.SetActive(true);
        crushedEggRB.velocity = new Vector2(0f, -200f);

        yield return new WaitForSeconds(2f);

        crushedEgg.SetActive(false);
        panEmpty.SetActive(false);
        panEgg.SetActive(true);
        gameObject.SetActive(false);
    }
}
