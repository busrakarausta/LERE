using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;

public class IceCreamManager : MonoBehaviour,IDragHandler
{
    public RectTransform cone;
    private bool flag = true;
    public IceCreamEnder IceCreamEnder; 
    private float x_pos=-5f;
    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (flag)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            transform.position = pos;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Cone")
        {
            if (flag)
                TransformIcecream();
        }
    }

    private void TransformIcecream()
    {
        if (gameObject.name == "Icecream1")
        {
            IceCreamEnder.IncreaseClickCount();
            thisRect.anchoredPosition= new Vector3(-25, 55f, 0);
        }
        else if (gameObject.name == "Icecream2")
        {
            
            IceCreamEnder.IncreaseClickCount();
            thisRect.anchoredPosition = new Vector3(-25, 110f, 0);
        }
        else if (gameObject.name == "Icecream3")
        {
            IceCreamEnder.IncreaseClickCount();
            thisRect.anchoredPosition = new Vector3(-25, 400f, 0);
        }
        flag = false;

    }
}
