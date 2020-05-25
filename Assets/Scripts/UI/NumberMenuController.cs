using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private UIManager uiManager;

    [Header("UI Element References")]
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private Sprite[] numberImages;

    private Text[] textOfButtons;


    private int[] numberListForText;
    private int _activeGameCount;
    private int _currentActiveNumberButtonIndex;
    void Awake()
    {
        Debug.Log("NumbersMenuController/Awake");

        _activeGameCount = DataManager.instance.GetRemainingActiveNumberGameCount();

        numberListForText = new int[_activeGameCount];

        textOfButtons = new Text[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            textOfButtons[i] = buttons[i].transform.GetChild(0).GetComponent<Text>();
        }

        if (_activeGameCount < buttons.Length)
        {
            for (int i = _activeGameCount; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
        }

        uiManager.OnChangeNumberList += OnNumberCompleted;

        InstantiateNumberMenu();

    }

    private void InstantiateNumberMenu()
    {
        Debug.Log("LetersMenuController/InstantiateLetterMenu");

        numberListForText = DataManager.instance.GetActiveNumberList();
        int length = numberListForText.Length;
        Debug.Log(numberListForText[0]);
        for (int i = 0; i < length; i++)
        {
            textOfButtons[i].text = numberListForText[i].ToString();
            Image letterImage = buttons[i].GetComponent<Image>();
            letterImage.sprite = numberImages[(numberListForText[i]-1)];
        }
    }

    private void OnNumberCompleted(int activeIndex)
    {
        Debug.Log("LetersMenuController/OnLetterCompleted");

        _currentActiveNumberButtonIndex = activeIndex;

        buttons[activeIndex].SetActive(false);
    }


}
