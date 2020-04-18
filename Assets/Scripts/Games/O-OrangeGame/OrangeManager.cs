using System;
using System.Collections.Generic;
using UnityEngine;

public class OrangeManager : MonoBehaviour
{

    [HideInInspector]
    public bool isOrangePosChanged=false;

    private Vector3 currentOrangePos;
    public Transform basketPos;
    private int totalOrangeCount = 4;
    private int currentOrangeCount = 0;
    public event Action OnLevelEnd;

    private void Start()
    {
        currentOrangePos = basketPos.position;
    }


    public Vector3 GetCurrentOrangePos()
    {
        if (isOrangePosChanged)
        {
            isOrangePosChanged = false;
            return currentOrangePos;
        }
        else
            return basketPos.position;
    }



    public void SetCurrentOrangePos(Vector3 pos)
    {
        currentOrangePos = pos;
        isOrangePosChanged = true;
    }

    public void SetCurrentOrangeCount()
    {
        currentOrangeCount++;
        if (currentOrangeCount == totalOrangeCount)
        {
            Debug.Log(currentOrangeCount);
            EndOfTheLevel();
        }
    }

    private void EndOfTheLevel()
    {
        OnLevelEnd?.Invoke();
    }
}
