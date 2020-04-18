using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class OrangeInputController : MonoBehaviour , IPointerDownHandler
{
    public Transform basket;
    public bool flag= false;
    public Vector3 orangePos;
    public OrangeManager orangeManager;


    void Update()
    {
        if (flag)
        {
            FallObject();
        }          
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        orangeManager.SetCurrentOrangeCount();
        if (transform.position.y > basket.position.y)
              flag = true;
    }

    private void FallObject()
    {
        if (transform.position.y <= basket.position.y)
        {
            flag = false;
            orangePos = basket.transform.position;
            orangeManager.SetCurrentOrangePos(transform.position);
            transform.SetParent(basket);
            transform.localPosition = Vector3.zero;
            return;
        }
        transform.Translate(Vector3.down* 2);          
    }
 



}
