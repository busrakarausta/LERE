using UnityEngine;
using System.Collections;

public class RedFlagGameEnder : MonoBehaviour
{
    private int flagCount = 0;
    private int totalCount = 2;

    public void IncreaseCount()
    {
        flagCount++;
        if (flagCount == totalCount)
        {
            ColorEducation.instance.OnColorEducationEnd();
        }
    }
}
