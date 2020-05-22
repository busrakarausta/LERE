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
    private int _currentColor = 1;

    private int shownGameCount = 3;

    private char[] _listedLetters = { 'A', 'B', 'C' };
    private int[] _listedNumbers = { 1, 2, 3 };
    private int[] _listedColors = { 1,2,3 };

    private LetterState[] _activeLetters;
    private NumberState[] _activeNumbers;
    private ColorState[] _activeColors;

    private int currentElementIndex = 0;

    //From Data Manager
    [HideInInspector]
    public int _activeGameCount;

    public event Action OnStepDone;
    public event Action OnWholeLevelDone;
    public event Action OnLetterComplete;
    public event Action OnNumberComplete;
    public event Action OnColorComplete;

    struct LetterState
    {
        public char letter;
        public int status;
    }
    struct ColorState
    {
        public int color;
        public int status;
    }
    struct NumberState
    {
        public int number;
        public int status;
    }

    private void Awake()
    {
        Debug.Log("GameManager/Awake");

        _instance = this;

        _educationController.OnLetterEducationEnd += OnEducationDone;
        _gameController.OnGameEnd += OnGameDone;
        _testController.OnTestEnd += OnTestDone;

        _listedLetters = DataManager.instance.GetActiveLetterList();
        _listedNumbers = DataManager.instance.GetActiveNumberList();
        _listedColors = DataManager.instance.GetActiveColorList();

        InitializeLetterStateData();
        InitializeNumberStateData();
        InitializeColorStateData();
    }

    private void InitializeLetterStateData()
    {
        Debug.Log("GameManager/InitializeStateData");

        _activeGameCount = DataManager.instance.GetRemainingActiveLetterGameCount();

        _activeLetters = new LetterState[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            char letter = _listedLetters[i];

            _activeLetters[i].letter = letter;
            _activeLetters[i].status = DataManager.instance.GetStatusOfTheLetter(letter);      
        }
    }

    private void InitializeNumberStateData()
    {
        Debug.Log("GameManager/InitializeNumberStateData");

        _activeGameCount = DataManager.instance.GetRemainingActiveNumberGameCount();
        _activeNumbers = new NumberState[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            int number = _listedNumbers[i];

            _activeNumbers[i].number = number;
            _activeNumbers[i].status = DataManager.instance.GetStatusOfTheNumber(number);
        }
    }

    private void InitializeColorStateData()
    {
        Debug.Log("GameManager/InitializeColorStateData");

        _activeGameCount = DataManager.instance.GetRemainingActiveColorGameCount();
        _activeColors = new ColorState[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            int color = _listedColors[i];

            _activeColors[i].color = color;
            _activeColors[i].status = DataManager.instance.GetStatusOfTheColor(color);
        }
    }

    private void OnGameDone()
    {
        Debug.Log("GameManager/OnLetterGameDone");

        if (_isLetter)
        {
            char letter = _activeLetters[currentElementIndex].letter;
            _activeLetters[currentElementIndex].status = 2;
            DataManager.instance.SetStatusOfTheLetter(_currentLetter, '2');
        }
        else if (_isNumber)
        {
            int number = _activeNumbers[currentElementIndex].number;
            _activeNumbers[currentElementIndex].status = 2;
            DataManager.instance.SetStatusOfTheNumber(_currentNumber, '2');
        }
        else if (_isColor)
        {
            int color = _activeColors[currentElementIndex].color;
            _activeColors[currentElementIndex].status = 2;
            DataManager.instance.SetStatusOfTheColor(_currentColor, '2');
        }

        OnStepDone?.Invoke();
    }

    private void OnEducationDone()
    {
        Debug.Log("GameManager/OnEducationDone");
        if(_isLetter)
        {
            char letter = _activeLetters[currentElementIndex].letter;
            _activeLetters[currentElementIndex].status = 1;
            DataManager.instance.SetStatusOfTheLetter(_currentLetter, '1');
        }
        else if (_isNumber)
        {
            int number = _activeNumbers[currentElementIndex].number;
            _activeNumbers[currentElementIndex].status = 1;
            DataManager.instance.SetStatusOfTheNumber(_currentNumber, '1');
        }
        else if (_isColor)
        {
            int color = _activeColors[currentElementIndex].color;
            _activeColors[currentElementIndex].status = 1;
            DataManager.instance.SetStatusOfTheColor(_currentColor, '1');
        }
       
        OnStepDone?.Invoke();
    }

    private void OnTestDone()
    {
        Debug.Log("GameManager/OnLetterTestDone");

        if (_isLetter)
        {
            char letter = _activeLetters[currentElementIndex].letter;
            _activeLetters[currentElementIndex].status = 3;
            DataManager.instance.SetStatusOfTheLetter(_currentLetter, '3');
        }
        else if (_isNumber)
        {
            int number = _activeNumbers[currentElementIndex].number;
            _activeNumbers[currentElementIndex].status = 3;
            DataManager.instance.SetStatusOfTheNumber(_currentNumber, '3');
        }
        else if (_isColor)
        {
            int color = _activeColors[currentElementIndex].color;
            _activeColors[currentElementIndex].status = 3;
            DataManager.instance.SetStatusOfTheColor(_currentColor, '3');
        }

        OnStepDone?.Invoke();
    }

    public void InstantiateGame()
    {
        Debug.Log("GameManager/InstantiateLetterGame");

        _educationController?.InActiveEducation();

        if (_isLetter)
            _gameController.StartLetterGame(_currentLetter);
        else if (_isNumber)
            _gameController.StartNumberGame(_currentNumber);
        else if (_isColor)
            _gameController.StartColorGame(_currentColor);
    }

    private void InstantiateTest()
    {
        _gameController.InActiveGame();
        if (_isLetter)
            _testController.StartLetterTest(_currentLetter);
        else if (_isNumber)
            _testController.StartNumberTest(_currentNumber);
        else if (_isColor)
            _testController.StartColorTest(_currentColor);

    }

    public void InstantiateEducation()
    {
        Debug.Log("GameManager/InstantiateLetterEducation");

        if(_isLetter)
         _educationController.StartEducation(0,_currentLetter); //ilki color number letter mi , ikinci deger
        else if (_isNumber)
            _educationController.StartEducation(1, (char)(_currentNumber+'0'));
        else if (_isColor)
            _educationController.StartEducation(2, (char)(_currentColor + '0'));
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
        {
            _currentNumber = _listedNumbers[currentElementIndex];
            int status = _activeNumbers[currentElementIndex].status;
            StartNextStep(status);
        }

        else if (_isColor)
        {
            _currentColor = _listedColors[currentElementIndex];
            int status = _activeColors[currentElementIndex].status;
            StartNextStep(status);
        }
    }

    public void StartNextStep(int status)
    {
        Debug.Log("GameManager/StartNextStep");

        if (status == 0)
        {
            InstantiateEducation();
        }
        else if (status == 1)
        {
            InstantiateGame();
        }
        else if(status == 2)
        {
            InstantiateTest();
        }
        else
        {
            _testController.InActiveTest();
            if (_isLetter)
            {
                OnLetterComplete?.Invoke();
            }
            else if(_isNumber)
            {
                OnNumberComplete?.Invoke();
            }
            else if (_isColor)
            {
                OnColorComplete?.Invoke();
            }
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
