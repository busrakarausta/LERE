using UnityEngine;
using System.Collections;

public class BroccoliGameEnder : MonoBehaviour
{
    private int broccoliCount = 0;
    private int totalCount = 3;

    public void IncreaseCount()
    {
        broccoliCount++;
        if (broccoliCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
