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

    //Click Events
    private void Awake()
    {

    }

    private void ControlCategoriesMenu(bool isSetActive)
    {
        categoriesMenu.SetActive(isSetActive);
    }
    public void OnClickAlphabetButton()
    {
        ControlCategoriesMenu(false);
        lettersMenu.SetActive(true);
        GameManager._instance.ChangeGameStatus(0);
    }

    public void OnClickNumbersButton()
    {
        ControlCategoriesMenu(false);
        numbersMenu.SetActive(true);
        GameManager._instance.ChangeGameStatus(1);
    }

    public void OnClickColorsButton()
    {
        ControlCategoriesMenu(false);
        colorsMenu.SetActive(true);
        GameManager._instance.ChangeGameStatus(2);
    }

    public void OnClickParentControl()
    {
        ApplicationManager.instance.LoadParentControlScene();
    }

    public void OnClickChildGames()
    {
        ApplicationManager.instance.LoadGamesScene();
    }



}
