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
    public EggEnder eggEnder;
    public int clickCount = 1;

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
        crushedEggRB.velocity = new Vector2(0f, -2f);

        yield return new WaitForSeconds(2f);
        Debug.Log(clickCount);
        gameObject.SetActive(false);
        crushedEgg.SetActive(false);
        panEmpty.SetActive(false);
        panEgg.SetActive(true);
        clickCount++;

        if (clickCount == 2)
        {
            eggEnder.IncreaseClickCount();
        }
    }
}
