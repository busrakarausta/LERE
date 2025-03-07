﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class OrangeManager : MonoBehaviour
{

    [HideInInspector]
    public bool isOrangePosChanged=false;

    private Vector3 currentOrangePos;
    public RectTransform basketPos;
    private int totalOrangeCount = 4;
    private int currentOrangeCount = 0;

    private void Start()
    {
        currentOrangePos = basketPos.anchoredPosition;
    }


    public Vector3 GetCurrentOrangePos()
    {
        if (isOrangePosChanged)
        {
            isOrangePosChanged = false;
            return currentOrangePos;
        }
        else
            return basketPos.anchoredPosition;
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
        LevelController.instance.OnLevelEnd();
    }
}
