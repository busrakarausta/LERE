using System;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalJellyfish = 3;
    public event Action OnLevelEnd;

    public void IncreaseJellyfishCount()
    {
        clickCount++;
        if (clickCount == totalJellyfish)
        {
            OnLevelEnd?.Invoke();
        }
    }
}

