using System;
using System.Collections.Generic;
using UnityEngine;

public class XylophoneEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalNote = 4;
    public event Action OnLevelEnd;

    public void IncreaseNoteCount()
    {
        clickCount++;
        if (clickCount == totalNote)
        {
            OnLevelEnd?.Invoke();
        }
    }
}

