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
    [SerializeField]
    private GameObject todayScene;
    [SerializeField]
    private GameObject lastWeekScene;
    [SerializeField]
    private GameObject settingsScene;

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
    public void OnClickSettings()
    {
        Debug.Log("ParentUIManager/OnClickSettings");
        settingsScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClickToday()
    {
        Debug.Log("ParentUIManager/OnClickToday");
        todayScene.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnClickLastWeek()
    {
        Debug.Log("ParentUIManager/OnClickLastWeek");
        lastWeekScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClickBackParent()
    {
        Debug.Log("ParentUIManager/OnClickBackParent");
        gameObject.SetActive(true);
        todayScene.SetActive(false);
        lastWeekScene.SetActive(false);
        settingsScene.SetActive(false);
    }



}
