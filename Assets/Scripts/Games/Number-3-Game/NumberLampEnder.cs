using System;
using System.Collections.Generic;
using UnityEngine;

public class NumberLampEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 3;

    public void IncreaseClickCount()
    {
        clickCount++;
        Debug.Log("asdfghjkldfghj");
        if (clickCount == totalClick)
        {
            
            LevelController.instance.OnLevelEnd();
        }
    }
}
