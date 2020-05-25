using System;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleanerEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalDirt = 4;

    public void IncreaseDirtCount()
    {
        clickCount++;
        if (clickCount == totalDirt)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
