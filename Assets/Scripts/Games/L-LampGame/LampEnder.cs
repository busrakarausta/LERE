using System;
using System.Collections.Generic;
using UnityEngine;

public class LampEnder : MonoBehaviour
{
    public int lampCount = 0;
    public int totalLampCount = 4;

    public void IncreaseLampCount()
    {
        lampCount++;
        if (lampCount == totalLampCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
