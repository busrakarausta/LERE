using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentUIManager : MonoBehaviour
{
    [SerializeField]
    private Slider gameCountSlider;
    [SerializeField]
    private Text sliderShownValue;

    private int gameCountValue;

    private void Awake()
    {
        ChangeGameCount();
    }

    public void ChangeGameCount()
    {
        gameCountValue = (int)gameCountSlider.value;
        sliderShownValue.text = gameCountValue.ToString();

        DataManager.instance?.SetActiveGameCount(gameCountValue);
    }

    public void BackToHome()
    {
        Debug.Log("ParentUIManager/BackToHome");
        ApplicationManager.instance.LoadHomeScene();
    }

    public void OnClickChildGames()
    {
        Debug.Log("ParentUIManager/OnClickChildGames");
        ApplicationManager.instance.LoadGamesScene();
    }

}
