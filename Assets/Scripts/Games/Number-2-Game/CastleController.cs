using System;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    private int goalCount = 0;
    private int totalBallCount = 2;

    public void IncreaseGoalCount()
    {
        goalCount++;
        if (goalCount == totalBallCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
