using UnityEngine;
using System.Collections;

public class BlueBrushGameEnder : MonoBehaviour
{
    private int wallCount = 0;
    private int totalCount = 2;

    public void IncreaseCount()
    {
        wallCount++;
        if (wallCount == totalCount)
        {
            ColorEducation.instance.OnColorEducationEnd();
        }
    }
}
