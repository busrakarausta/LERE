using System;
using System.Collections.Generic;
using UnityEngine;

public class EggEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 2;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
