using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HamburgerCreator : MonoBehaviour, IPointerDownHandler
{
    public RectTransform bottom;
    public float move=50f;
    public HamburgerEnder hamburgerEnder;
    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        AddToBurger();
    }

    private void AddToBurger()
    {
        if (gameObject.name == "Meat")
        {
            thisRect.anchoredPosition = new Vector3(bottom.anchoredPosition.x, bottom.anchoredPosition.y + move, 0);
            hamburgerEnder.IncreaseMealCount();
        }
        else if (gameObject.name == "Lettuce")
        {
            thisRect.anchoredPosition =  new Vector3(bottom.anchoredPosition.x, bottom.anchoredPosition.y + move+70f, 0);
            hamburgerEnder.IncreaseMealCount();
        }
        else if (gameObject.name == "Top")
        {
            thisRect.anchoredPosition =  new Vector3(bottom.anchoredPosition.x, bottom.anchoredPosition.y + move+150f, 0);
            hamburgerEnder.IncreaseMealCount();
        }
    }
    
}
