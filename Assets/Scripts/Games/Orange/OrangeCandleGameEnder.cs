using UnityEngine;
using System.Collections;

public class OrangeCandleGameEnder : MonoBehaviour
{
    private int candleCount = 0;
    private int totalCount = 3;

    public void IncreaseCount()
    {
        candleCount++;
        if (candleCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
