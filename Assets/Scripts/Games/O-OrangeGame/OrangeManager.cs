using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeManager : MonoBehaviour
{
    private Vector3 currentOrangePos;
    public Transform basketPos;
    [HideInInspector]
    public bool isOrangePosChanged=false;

    private void Start()
    {
        currentOrangePos = basketPos.position;
    }
    public Vector3 GetCurrentApplePos()
    {
        if (isOrangePosChanged)
        {
            isOrangePosChanged = false;
            return currentOrangePos;
        }
        else
            return basketPos.position;
    }
    public void SetCurrentApplePos(Vector3 pos)
    {
        currentOrangePos = pos;
        isOrangePosChanged = true;
    }
}
