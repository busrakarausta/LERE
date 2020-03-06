using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IceCreamManager : MonoBehaviour,IDragHandler
{
    public Transform cone;
    private bool flag = false;
    private float up=10;
    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("draggggiinnggg..");
        gameObject.transform.position = Input.mousePosition;
        if (transform.position.x >= cone.position.x && flag)
        {
            TransformIcecream();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Cone")
        {
            Debug.Log( gameObject.name +" perceive..");
            flag = true;
        }
    }

    private void TransformIcecream()
    {
        up += 10;
        Debug.Log(gameObject.name + " accepted..");
        transform.position= new Vector3(cone.transform.position.x, cone.transform.position.y+up, cone.transform.position.z);
    }
}
