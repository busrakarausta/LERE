using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    private Vector3 currentApplePos;
    public Transform basketPos;
    [HideInInspector]
    public bool isApplePosChanged=false;

    private void Start()
    {
        currentApplePos = basketPos.position;
    }
    public Vector3 GetCurrentApplePos()
    {
        if (isApplePosChanged)
        {
            isApplePosChanged = false;
            return currentApplePos;
        }
        else
            return basketPos.position;
    }
    public void SetCurrentApplePos(Vector3 pos)
    {
        currentApplePos = pos;
        isApplePosChanged = true;
    }
}
