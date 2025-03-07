﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    [HideInInspector]
    public bool isApplePosChanged=false;

    private Vector3 currentApplePos;
    public RectTransform basketPos;
    private int totalAppleCount=4;
    private int currentAppleCount=0;


    private void Start()
    {
        currentApplePos = basketPos.anchoredPosition;
    }
    public Vector3 GetCurrentApplePos()
    {
        if (isApplePosChanged)
        {
            isApplePosChanged = false;
            return currentApplePos;
        }
        else
            return basketPos.anchoredPosition;
    }
    public void SetCurrentApplePos(Vector3 pos)
    {
        currentApplePos = pos;
        isApplePosChanged = true;
    }

    public void SetCurrentAppleCount()
    {
        currentAppleCount++;
        if(currentAppleCount == totalAppleCount)
        {
            Debug.Log(currentAppleCount);
            EndOfTheLevel();
        }
    }

    private void EndOfTheLevel()
    {
        LevelController.instance.OnLevelEnd();
    }
}
