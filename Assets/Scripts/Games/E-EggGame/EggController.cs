using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EggController : MonoBehaviour, IPointerDownHandler
{
    private float step;
    private float speed=5;
    public GameObject panEmpty;
    public GameObject crushedEgg;
    public GameObject panEgg;
    private bool arrived = false;



    void Awake()
    {
       // source = cruchedEgg.GetComponent<AudioSource>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      CruchEgg();
    }

    public void CruchEgg()
        {
        gameObject.SetActive(false);
        crushedEgg.SetActive(true);

        step = speed * Time.deltaTime;

        while (!arrived)
        {
            Debug.Log("testtt");
            
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            arrived = true;

        }

        crushedEgg.SetActive(false);
        panEmpty.SetActive(false);
        panEgg.SetActive(true);



    }
}
