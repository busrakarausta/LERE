using UnityEngine;
using System.Collections;

public class LambEnder : MonoBehaviour
{
    private int lambCount = 0;
    private int totalCount = 7;

    public void IncreaseCount()
    {
        lambCount++;
        if (lambCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
