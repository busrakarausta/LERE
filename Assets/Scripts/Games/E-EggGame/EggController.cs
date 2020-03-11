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





    void Awake()
    {
       crushedEggRB = crushedEgg.GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine( CruchEgg());
    }

    public IEnumerator CruchEgg()
    {
        crushedEgg.SetActive(true);
        if(crushedEgg.transform.position.y >= panEmpty.transform.position.y )
        {
            crushedEggRB.velocity = new Vector2(0f, -90f);
        }
        yield return new WaitForSeconds(2f);

        crushedEgg.SetActive(false);
        panEmpty.SetActive(false);
        panEgg.SetActive(true);
        gameObject.SetActive(false);

        
    }

   
    
}
