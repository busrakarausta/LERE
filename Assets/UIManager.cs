using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

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
    
    //Click Events
    private void Awake()
    {
        GameManager._instance.OnStepDone += NextButton;
        GameManager._instance.OnWholeLevelDone += BackToElementsMenu;
    }

    private void NextButton()
    {
        nextButton.SetActive(true);
    }

    public void BackToElementsMenu()
    {
        nextButton.SetActive(false);
        _currentActivePanel.SetActive(true);

        GameManager._instance.EndCurrentState();

        backToElements.SetActive(false);
        backToCategories.SetActive(true);

    }

    public void BackToCategories()
    {
        _currentActivePanel.SetActive(false);
        categoriesMenu.SetActive(true);

        backToCategories.SetActive(false);
    }

    public void OnClickNextButton()
    {
        nextButton.SetActive(false);
        GameManager._instance.StartNextStep();
    }

    //////////
    public void OnClickStartGameElement(int index)
    {

        _currentActivePanel.SetActive(false);

        backToCategories.SetActive(false);
        backToElements.SetActive(true);

        GameManager._instance.StartGame(index);

    }

    ///////////
    private void ControlCategoriesMenu(bool isSetActive)
    {
        categoriesMenu.SetActive(isSetActive);
    }

    ////////////
    public void OnClickAlphabetButton()
    {
        backToCategories.SetActive(true);
        backToElements.SetActive(false);

        ControlCategoriesMenu(false);
        lettersMenu.SetActive(true);

        _currentActivePanel = lettersMenu;
        GameManager._instance.ChangeGameStatus(0);
    }

    public void OnClickNumbersButton()
    {
        backToCategories.SetActive(true);
        backToElements.SetActive(false);

        ControlCategoriesMenu(false);
        numbersMenu.SetActive(true);
        _currentActivePanel = numbersMenu;
        GameManager._instance.ChangeGameStatus(1);
    }

    public void OnClickColorsButton()
    {
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
        ApplicationManager.instance.LoadParentControlScene();
    }

    public void OnClickChildGames()
    {
        ApplicationManager.instance.LoadGamesScene();
    }



}
