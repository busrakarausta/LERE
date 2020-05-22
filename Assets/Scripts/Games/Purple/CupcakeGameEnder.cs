using UnityEngine;
using System.Collections;

public class CupcakeGameEnder : MonoBehaviour
{
    private int cupcakeCount = 0;
    private int totalCount = 3;

    public void IncreaseCount()
    {
        cupcakeCount++;
        if (cupcakeCount == totalCount)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
