using UnityEngine;
using System.Collections;

public class HandGameEnder : MonoBehaviour
{
    private int totalClick = 5;

    public void GetClickCount(int clickCount)
    {
        if (clickCount == totalClick)
        {
            LevelController.instance.OnLevelEnd();
        }
    }
}
