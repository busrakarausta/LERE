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

    private GameObject _currentActivePanel;
    //Click Events
    private void Awake()
    {

    }

    //////////
    public void OnClickStartGameElement(int index)
    {
        _currentActivePanel.SetActive(false);
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
        ControlCategoriesMenu(false);
        lettersMenu.SetActive(true);
        _currentActivePanel = lettersMenu;
        GameManager._instance.ChangeGameStatus(0);
    }

    public void OnClickNumbersButton()
    {
        ControlCategoriesMenu(false);
        numbersMenu.SetActive(true);
        _currentActivePanel = numbersMenu;
        GameManager._instance.ChangeGameStatus(1);
    }

    public void OnClickColorsButton()
    {
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
