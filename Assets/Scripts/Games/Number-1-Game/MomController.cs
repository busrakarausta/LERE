using System;
using System.Collections.Generic;
using UnityEngine;

public class MomController : MonoBehaviour
{
    private int roseCount = 0;

    public void IncreaseRoseCount()
    {
        roseCount++;
        if (roseCount == 1)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
