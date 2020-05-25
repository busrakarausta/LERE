using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private UIManager uiManager;

    [Header("UI Element References")]
    [SerializeField]
    private GameObject[] buttons;
    [SerializeField]
    private Sprite[] colorImages;

    private Text[] textOfButtons;


    private int[] colorsListForText;
    private int _activeGameCount;
    private int _currentActiveColorButtonIndex;
    void Awake()
    {
        Debug.Log("NumbersMenuController/Awake");

        _activeGameCount = DataManager.instance.GetRemainingActiveColorGameCount();

        colorsListForText = new int[_activeGameCount];

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

        uiManager.OnChangeColorList += OnColorCompleted;

        InstantiateColorMenu();

    }

    private void InstantiateColorMenu()
    {
        Debug.Log("LetersMenuController/InstantiateLetterMenu");

        colorsListForText = DataManager.instance.GetActiveColorList();
        int length = colorsListForText.Length;
        Debug.Log(colorsListForText[0]);
        for (int i = 0; i < length; i++)
        {
            textOfButtons[i].text = colorsListForText[i].ToString();
            Image colorImage = buttons[i].GetComponent<Image>();
            colorImage.sprite = colorImages[(colorsListForText[i] - 1)];
        }
    }

    private void OnColorCompleted(int activeIndex)
    {
        Debug.Log("LetersMenuController/OnColorCompleted");

        _currentActiveColorButtonIndex = activeIndex;

        buttons[activeIndex].SetActive(false);
    }


}
