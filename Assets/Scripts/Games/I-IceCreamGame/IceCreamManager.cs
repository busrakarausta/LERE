using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.PlayerLoop;

public class IceCreamManager : MonoBehaviour,IDragHandler
{
    public Transform cone;
    private bool flag = false;
    private float x_pos=-5f;
    
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
        if (transform.position.x >= cone.position.x && transform.position.y >= cone.position.y && flag)
        {
            TransformIcecream();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Cone")
        {
            flag = true;
        }
    }

    private void TransformIcecream()
    {
        if (gameObject.name == "Icecream1")
        {
            transform.position= new Vector3(cone.transform.position.x+x_pos, cone.transform.position.y+190f, cone.transform.position.z);
        }
        else if (gameObject.name == "Icecream2")
        {
            transform.position= new Vector3(cone.transform.position.x+x_pos, cone.transform.position.y+280f, cone.transform.position.z);
        }
        else if (gameObject.name == "Icecream3")
        {
            transform.position= new Vector3(cone.transform.position.x+x_pos, cone.transform.position.y+370f, cone.transform.position.z);
        }
    }
}
