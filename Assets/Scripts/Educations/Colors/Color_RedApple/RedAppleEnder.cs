using System;
using System.Collections.Generic;
using UnityEngine;

public class RedAppleEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 2;

    public void IncreaseClickCount(int totalTouch)
    {
        Debug.Log(clickCount);
        clickCount++;
        if (clickCount == totalClick)
        {
            ColorEducation.instance.OnColorEducationEnd(totalTouch);
        }
    }
}
