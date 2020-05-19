using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private int strawberryCount = 0;
    private int totalCount = 4;

    public void IncreaseCount()
    {
        strawberryCount++;
        if (strawberryCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
