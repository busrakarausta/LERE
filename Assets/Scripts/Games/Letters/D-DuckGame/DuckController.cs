using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;

public class DuckController : MonoBehaviour,IDragHandler
{
    private int count = 0;
    public DuckEnder duckEnder;
    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        RectTransform otherRect = other.gameObject.GetComponent<RectTransform>();

        

        //otherRect.parent = transform;
        if (other.gameObject.name == "Child1")
        {
            other.gameObject.transform.parent = gameObject.transform;
            duckEnder.IncreaseChildCount();
            otherRect.localPosition= new Vector3(thisRect.anchoredPosition.x+320f, 0 , 0);
        }
        else if (other.gameObject.name == "Child2")
        {
            other.gameObject.transform.parent = gameObject.transform;
            duckEnder.IncreaseChildCount();
            otherRect.localPosition = new Vector3(thisRect.anchoredPosition.x + 590,  -200  ,0);
        }
        else if (other.gameObject.name == "Child3")
        {
            other.gameObject.transform.parent = gameObject.transform;
            duckEnder.IncreaseChildCount();
            otherRect.localPosition = new Vector3(thisRect.anchoredPosition.x + 730,  - 370, 0);
        }
        CountControl();
    }
        
        
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    void CountControl()
    {
        count++;
        if (count == 3)
        {
        EndOfTheLevel();
        }
    }
    private void EndOfTheLevel()
    {
        LevelController.instance.OnLevelEnd();
    }
}
