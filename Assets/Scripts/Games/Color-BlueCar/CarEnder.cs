using System;
using System.Collections.Generic;
using UnityEngine;

public class CarEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 2;
    public event Action OnLevelEnd;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            Debug.Log("END");
            OnLevelEnd?.Invoke();
        }
    }
}
