using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private UIManager uiManager;

    [Header("UI Element References")]
    [SerializeField]
    private GameObject[] buttons;

    private Text[] textOfButtons;

    private char[] letterListForText;
    private int _activeGameCount;
    private int _currentActiveLetterButtonIndex;
    void Awake()
    {
        Debug.Log("LetersMenuController/Awake");

        _activeGameCount = DataManager.instance.GetRemainingActiveLetterGameCount();

        letterListForText = new char[_activeGameCount];

        textOfButtons = new Text[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            textOfButtons[i] = buttons[i].transform.GetChild(0).GetComponent<Text>();
        }

        if (_activeGameCount<buttons.Length)
        {
            for (int i = _activeGameCount; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
        }

        uiManager.OnChangeLetterList += OnLetterCompleted;

        InstantiateLetterMenu();

    }

    private void InstantiateLetterMenu()
    {
        Debug.Log("LetersMenuController/InstantiateLetterMenu");

        letterListForText = DataManager.instance.GetActiveLetterList();
        int length = letterListForText.Length;

        for (int i = 0; i < length; i++)
        {
            textOfButtons[i].text = letterListForText[i].ToString();
        }
    }

    private void OnLetterCompleted(int activeIndex)
    {
        Debug.Log("LetersMenuController/OnLetterCompleted");

        _currentActiveLetterButtonIndex = activeIndex;

        buttons[activeIndex].SetActive(false);

        /*Button currentButton=buttons[activeIndex].GetComponent<Button>();
        currentButton.interactable = false;*/
    }


}
