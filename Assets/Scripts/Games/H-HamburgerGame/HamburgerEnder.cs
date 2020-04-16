using System;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalMeal = 3;
    public event Action OnLevelEnd;

    public void IncreaseMealCount()
    {
        clickCount++;
        if (clickCount == totalMeal)
        {
            OnLevelEnd?.Invoke();
        }
    }
}

