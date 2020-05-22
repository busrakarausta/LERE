using UnityEngine;
using System.Collections;

public class DaisyGameEnder : MonoBehaviour
{
    private int daisyCount = 0;
    private int totalCount = 3;

    public void IncreaseCount()
    {
        daisyCount++;
        if (daisyCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
