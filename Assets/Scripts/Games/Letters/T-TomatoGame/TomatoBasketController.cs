using System;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBasketController : MonoBehaviour
{
    public int tomatoCount = 0;
    public int totalTomatoCount = 3;

    public void IncreaseTomatoCount()
    {
        tomatoCount++;
        if (tomatoCount == totalTomatoCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
