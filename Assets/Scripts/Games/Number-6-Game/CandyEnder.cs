using UnityEngine;
using System.Collections;

public class CandyEnder : MonoBehaviour
{
    private int candyCount = 0;
    private int totalCount = 6;

    public void IncreaseCount()
    {
        candyCount++;
        if (candyCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
