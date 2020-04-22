using System;
using System.Collections.Generic;
using UnityEngine;

public class CarEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 2;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            Debug.Log("END");
            LevelController.instance.OnLevelEnd();
        }
    }
}
