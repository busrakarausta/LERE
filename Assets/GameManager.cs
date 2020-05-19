using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("References")]
    [SerializeField]
    private EducationController _educationController;

    [SerializeField]
    private TestController _testController;

    [SerializeField]
    private GameController _gameController;

    private bool _isLetter=false;
    private bool _isNumber=false;
    private bool _isColor=false;

    private char _currentLetter = 'A';
    private int _currentNumber = 1;
    private Color _currentColor = Color.red;

    private int shownGameCount = 3;

    private char[] _listedLetters = { 'A', 'B', 'C' };
    private int[] _listedNumbers = { 1, 2, 3 };
    private Color[] _listedColors = { Color.red, Color.blue, Color.green };

    private LetterState[] _activeLetters;
    private LetterState[] _activeNumbers;
    private LetterState[] _activeColors;

    private int currentElementIndex = 0;

    //From Data Manager
    [HideInInspector]
    public int _activeGameCount;

    public event Action OnStepDone;
    public event Action OnWholeLevelDone;
    public event Action OnLetterComplete;

    struct LetterState
    {
        public char letter;
        public int status;
    }
    struct ColorState
    {
        public Color color;
        public int colorStateData;
    }
    struct NumberState
    {
        public int number;
        public int numberStateData;
    }

    private void Awake()
    {
        Debug.Log("GameManager/Awake");

        _instance = this;

        _educationController.OnLetterEducationEnd += OnLetterEducationDone;
        _gameController.OnGameEnd += OnLetterGameDone;
        _testController.OnTestEnd += OnLetterTestDone;

        _listedLetters = DataManager.instance.GetActiveLetterList();

        InitializeStateData();
    }

    private void InitializeStateData()
    {
        Debug.Log("GameManager/InitializeStateData");

        _activeGameCount = DataManager.instance.GetRemainingActiveLetterGameCount();

        _activeLetters = new LetterState[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            char letter = _listedLetters[i];
            _activeLetters[i].letter = letter;
            _activeLetters[i].status = DataManager.instance.GetStatusOfTheLetter(letter);
            Debug.Log("bbbbbbbbbbbbbbbbb");
            Debug.Log(_activeLetters[i].status);
            
        }
    }

    public void EndCurrentState()
    {
        //silinecek
    }
    private void OnLetterGameDone()
    {
        Debug.Log("GameManager/OnLetterGameDone");
        char letter = _activeLetters[currentElementIndex].letter;
        _activeLetters[currentElementIndex].status = 2;
        DataManager.instance.SetStatusOfTheLetter(_currentLetter, '2');

        OnStepDone?.Invoke();
    }

    private void OnLetterEducationDone()
    {
        Debug.Log("GameManager/OnLetterEducationDone");

        char letter = _activeLetters[currentElementIndex].letter;
        _activeLetters[currentElementIndex].status = 1;
        DataManager.instance.SetStatusOfTheLetter(_currentLetter, '1');

        OnStepDone?.Invoke();
    }

    private void OnLetterTestDone()
    {
        Debug.Log("GameManager/OnLetterTestDone");

        char letter = _activeLetters[currentElementIndex].letter;
        _activeLetters[currentElementIndex].status = -1;
        DataManager.instance.SetStatusOfTheLetter(_currentLetter, '3');

        OnStepDone?.Invoke();
    }

    public void InstantiateLetterGame()
    {
        Debug.Log("GameManager/InstantiateLetterGame");

        _educationController?.InActiveEducation();
        _gameController.StartLetterGame(_currentLetter);
    }

    public void InstantiateLetterTest()
    {
        Debug.Log("GameManager/InstantiateLetterTest");

        _gameController.InActiveGame();
        _testController.StartLetterTest(_currentLetter);
    }

    public void InstantiateLetterEducation()
    {
        Debug.Log("GameManager/InstantiateLetterEducation");
        _educationController.StartLetterEducation(_currentLetter);
    }

    public void InstantiateColorEducation(int index)
    {
        Debug.Log("GameManager/InstantiateColorEducation");

        _currentColor = _listedColors[index];
    }
    public void InstantiateNumberEducation(int index)
    {
        Debug.Log("GameManager/InstantiateNumberEducation");

        _currentNumber = _listedNumbers[index];
    }

    public void StartGame(int index)
    {
        currentElementIndex = index;
        Debug.Log("GameManager/StartGame");

        if (_isLetter)
        {
            _currentLetter = _listedLetters[currentElementIndex];
            int status = _activeLetters[currentElementIndex].status;

            StartNextStep(status);
        }

        else if (_isNumber)
            InstantiateNumberEducation(currentElementIndex);

        else if (_isColor)
            InstantiateColorEducation(currentElementIndex);
    }

    public void StartNextStep(int status)
    {
        Debug.Log("GameManager/StartNextStep");

        if (status == 0)
        {
            InstantiateLetterEducation();
        }
        else if (status == 1)
            InstantiateLetterGame();
        else if(status == 2)
            InstantiateLetterTest();
        else
        {
            _testController.InActiveTest();
            OnLetterComplete?.Invoke();
            OnWholeLevelDone?.Invoke();
        }
    }

    public void ChangeGameStatus(int stateIndex) // alfabe number ya da renk mi yapiyorum belirle
    {
        Debug.Log("GameManager/ChangeGameStatus");

        switch (stateIndex)
        {
            case 0:
                {
                    SetGameState(true, false, false);
                    break;
                }
            case 1:
                {
                    SetGameState(false, true, false);
                    break;
                }
            case 2:
                {
                    SetGameState(false, false, true);
                    break;
                }

            default:
                break;
        }
    }

    private void SetGameState(bool letter,bool number,bool color)
    {
        Debug.Log("GameManager/SetGameState");

        _isLetter = letter;
        _isNumber = number;
        _isColor = color;
    }


}
