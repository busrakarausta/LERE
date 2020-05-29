using System;
using System.Collections.Generic;
using UnityEngine;

public class BalloonEnder : MonoBehaviour
{
    private int totalClick = 3;
    private int clickCount = 0;
    public event Action OnLevelEnd;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}