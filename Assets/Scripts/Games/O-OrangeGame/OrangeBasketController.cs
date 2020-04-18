using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBasketController : MonoBehaviour
{
    public GameObject basket;
    public OrangeManager orangeManager;
    private Transform newPosForChild;
    private int childIndex=0;
    private Vector3 startPos;
    
    private void Update()
    {
        Vector3 newPos= orangeManager.GetCurrentOrangePos();
        if(newPos!=transform.position)
        {
            transform.position = newPos;
            newPosForChild = transform.GetChild(childIndex);
            newPosForChild.position = new Vector3((newPosForChild.position.x - 30 + childIndex*20), newPosForChild.position.y, newPosForChild.position.z-30-childIndex*5f);
            childIndex++;
        }
    }
}
