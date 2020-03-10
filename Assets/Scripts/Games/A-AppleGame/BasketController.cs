using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameObject basket;
    public AppleManager appleManager;
    private Transform newPosForChild;
    private int childIndex=0;
    
    private void Update()
    {
        Vector3 newPos= appleManager.GetCurrentApplePos();
        if(newPos!=transform.position)
        {
            transform.position = newPos;
            newPosForChild = transform.GetChild(childIndex);
            newPosForChild.position = new Vector3((newPosForChild.position.x - 30 + childIndex*20), newPosForChild.position.y, newPosForChild.position.z-50f);
            childIndex++;
        }
    }
}
