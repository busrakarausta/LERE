using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HamburgerCreator : MonoBehaviour, IPointerDownHandler
{
    public Transform bottom;
    public float move=50f;

    public void OnPointerDown(PointerEventData eventData)
    {
        AddToBurger();
    }

    private void AddToBurger()
    {
        if (gameObject.name == "Meat")
        {
            gameObject.transform.position = new Vector3(bottom.position.x, bottom.position.y + move, bottom.position.z);
        }
        else if (gameObject.name == "Lettuce")
        {
            gameObject.transform.position=  new Vector3(bottom.position.x, bottom.position.y + move+70f, bottom.position.z);
        }
        else if (gameObject.name == "Top")
        {
            gameObject.transform.position=  new Vector3(bottom.position.x, bottom.position.y + move+150f, bottom.position.z);
        }
    }
    
}
