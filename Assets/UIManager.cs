using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("References")]

    [SerializeField]
    private GameManager gameManager;

    [Header("Canvas Elements")]

    [SerializeField]
    private GameObject mainCanvas;
    [SerializeField]
    private GameObject categoriesMenu;
    [SerializeField]
    private GameObject lettersMenu;
    [SerializeField]
    private GameObject numbersMenu;
    [SerializeField]
    private GameObject colorsMenu;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject backToElements;
    [SerializeField]
    private GameObject backToCategories;

    private GameObject _currentActivePanel;
    private int _activeButtonIndex;

    public event Action<int> OnChangeLetterList;
    //Click Events

    private void Awake()
    {
        Debug.Log("UIManager/Awake");
        if(gameManager)
        {
            GameManager._instance.OnStepDone += NextButton;
            GameManager._instance.OnWholeLevelDone += BackToElementsMenu;
            GameManager._instance.OnLetterComplete += OnLetterCompleted;
        }
    }

    private void OnLetterCompleted()
    {
        Debug.Log("UIManager/OnLetterCompleted");
        OnChangeLetterList?.Invoke(_activeButtonIndex);
    }

    private void NextButton()
    {
        Debug.Log("UIManager/NextButton");
        nextButton.SetActive(true);
    }

    public void BackToElementsMenu()
    {
        Debug.Log("UIManager/BackToElementsMenu");

        nextButton.SetActive(false);
        _currentActivePanel.SetActive(true);

        backToElements.SetActive(false);
        backToCategories.SetActive(true);
    }

    public void BackToHome()
    {
        Debug.Log("UIManager/BackToHome");

        ApplicationManager.instance.LoadHomeScene();
    }

    public void BackToCategories()
    {
        Debug.Log("UIManager/BackToCategories");
        _currentActivePanel.SetActive(false);
        categoriesMenu.SetActive(true);

        backToCategories.SetActive(false);
    }

    public void OnClickNextButton()
    {
        Debug.Log("UIManager/OnClickNextButton");
        nextButton.SetActive(false);
        GameManager._instance.StartGame(_activeButtonIndex);
    }

    //////////
    public void OnClickStartGameElement(int index) // index = butonun indexi
    {
        Debug.Log("UIManager/OnClickStartGameElement");
        _activeButtonIndex = index;
        _currentActivePanel.SetActive(false);

        backToCategories.SetActive(false);
        backToElements.SetActive(true);

        GameManager._instance.StartGame(index);

    }

    ///////////
    private void ControlCategoriesMenu(bool isSetActive)
    {
        Debug.Log("UIManager/ControlCategoriesMenu");
        categoriesMenu.SetActive(isSetActive);
    }

    ////////////
    public void OnClickAlphabetButton()
    {
        Debug.Log("UIManager/OnClickAlphabetButton");
        backToCategories.SetActive(true);
        backToElements.SetActive(false);

        ControlCategoriesMenu(false);
        lettersMenu.SetActive(true);

        _currentActivePanel = lettersMenu;
        GameManager._instance.ChangeGameStatus(0);
    }

    public void OnClickNumbersButton()
    {
        Debug.Log("UIManager/OnClickNumbersButton");
        backToCategories.SetActive(true);
        backToElements.SetActive(false);

        ControlCategoriesMenu(false);
        numbersMenu.SetActive(true);
        _currentActivePanel = numbersMenu;
        GameManager._instance.ChangeGameStatus(1);
    }

    public void OnClickColorsButton()
    {
        Debug.Log("UIManager/OnClickColorsButton");
        backToCategories.SetActive(true);
        backToElements.SetActive(false);

        ControlCategoriesMenu(false);
        colorsMenu.SetActive(true);
        _currentActivePanel = colorsMenu;
        GameManager._instance.ChangeGameStatus(2);
    }

    /////////////
    public void OnClickParentControl()
    {
        Debug.Log("UIManager/OnClickParentControl");
        ApplicationManager.instance.LoadParentControlScene();
    }

    public void OnClickChildGames()
    {
        Debug.Log("UIManager/OnClickChildGames");
        ApplicationManager.instance.LoadGamesScene();
    }



}
