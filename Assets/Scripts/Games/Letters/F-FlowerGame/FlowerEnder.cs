using System;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 6;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
