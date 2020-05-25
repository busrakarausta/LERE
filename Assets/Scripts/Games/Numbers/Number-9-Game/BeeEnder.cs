using UnityEngine;
using System.Collections;

public class BeeEnder : MonoBehaviour
{
    private int clickCount = 0;
    private int totalClick = 9;

    public void IncreaseClickCount()
    {
        clickCount++;
        if (clickCount == totalClick)
        {
            Debug.Log("OK");
            LevelController.instance.OnLevelEnd();
        }
    }
}
