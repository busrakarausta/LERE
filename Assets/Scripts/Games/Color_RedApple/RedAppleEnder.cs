using System;
using System.Collections.Generic;
using UnityEngine;

public class RedAppleEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 2;

    public void IncreaseClickCount()
    {
        Debug.Log(clickCount);
        clickCount++;
        if (clickCount == totalClick)
        {
            ColorEducation.instance.OnColorEducationEnd();
        }
    }
}
