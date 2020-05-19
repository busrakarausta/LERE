using UnityEngine;
using System.Collections;

public class StarGameEnder : MonoBehaviour
{

    private int clickCount = 0;
    private int totalClick = 8;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
