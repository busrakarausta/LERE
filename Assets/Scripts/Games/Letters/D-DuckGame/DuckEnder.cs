using System;
using System.Collections.Generic;
using UnityEngine;

public class DuckEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalChid = 3;

    public void IncreaseChildCount()
    {
        clickCount++;
        if (clickCount == totalChid)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
