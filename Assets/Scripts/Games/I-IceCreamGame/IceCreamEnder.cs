using System;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 3;
    public event Action OnLevelEnd;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            OnLevelEnd?.Invoke();
        }
    }
}
