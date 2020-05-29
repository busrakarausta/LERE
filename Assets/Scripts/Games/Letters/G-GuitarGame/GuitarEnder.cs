using System;
using System.Collections.Generic;
using UnityEngine;

public class GuitarEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalNote = 3;

    public void IncreaseNoteCount()
    {
        clickCount++;
        if (clickCount == totalNote)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}

