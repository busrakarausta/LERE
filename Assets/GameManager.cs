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

    private bool isEducationTurn=true;
    private bool isGameTurn=false;
    private bool isTestTurn=false;

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
        public GeneralStateData letterStateData;
    }
    struct ColorState
    {
        public Color color;
        public GeneralStateData colorStateData;
    }
    struct NumberState
    {
        public int number;
        public GeneralStateData numberStateData;
    }
    struct GeneralStateData
    {
        public bool isEducationDone;
        public bool isGameDone;
        public bool isTestDone;
        public bool isCompleted;

        GeneralStateData(bool defaultValue = false)
        {
            isEducationDone = isGameDone= isTestDone= isCompleted= defaultValue;
        }
    }

    private void Awake()
    {
        _instance = this;

        _educationController.OnLetterEducationEnd += OnLetterEducationDone;
        _gameController.OnGameEnd += OnLetterGameDone;
        _testController.OnTestEnd += OnLetterTestDone;

        _listedLetters = DataManager.instance.GetActiveLetterList();

        InitializeStateData();
    }

    private void InitializeStateData()
    {
        _activeGameCount = DataManager.instance.GetActiveGameCount();

        _activeLetters = new LetterState[_activeGameCount];

        for (int i = 0; i < _activeGameCount; i++)
        {
            _activeLetters[i].letter = _listedLetters[i];
        }
    }

    public void EndCurrentState()
    {
        Debug.Log(isTestTurn);

        if (isEducationTurn)
        {
            _educationController.InActiveEducation();
            isEducationTurn = false;
            isGameTurn = true;
            _activeLetters[currentElementIndex].letterStateData.isEducationDone = true;
        }
        else if (isGameTurn)
        {
            _gameController.InActiveGame();
            isGameTurn = false;
            isTestTurn = true;
            _activeLetters[currentElementIndex].letterStateData.isGameDone = true;

        }
        else if (isTestTurn)
        {
            _testController.InActiveTest();
            isTestTurn = false;
            isEducationTurn = true;
            
        }
    }

    private void ChangeStatusOfCompletedLetter()
    {
        _activeLetters[currentElementIndex].letterStateData.isTestDone = true;
        _activeLetters[currentElementIndex].letterStateData.isCompleted = true;

        currentElementIndex++;

        OnLetterComplete?.Invoke();

        DataManager.instance.OnLetterCompleted();
    }

    private void OnLetterGameDone()
    {
        isEducationTurn = false;
        isGameTurn = false;
        isTestTurn = true;

        OnStepDone?.Invoke();
    }

    private void OnLetterEducationDone()
    {
        isEducationTurn = false;
        isGameTurn = true;
        isTestTurn = false;

        OnStepDone?.Invoke();
    }

    private void OnLetterTestDone()
    {
        isEducationTurn = true;
        isGameTurn = false;
        isTestTurn = false;

        OnStepDone?.Invoke();
    }

    public void InstantiateLetterGame()
    {
        _educationController.InActiveEducation();
        _gameController.StartLetterGame(_currentLetter);
    }

    public void InstantiateLetterTest()
    {
        _gameController.InActiveGame();
        _testController.StartLetterTest(_currentLetter);
    }

    public void InstantiateLetterEducation(int index)
    {
        _currentLetter = _listedLetters[index];
        _educationController.StartLetterEducation(_currentLetter);
    }

    public void InstantiateColorEducation(int index)
    {
        _currentColor = _listedColors[index];
    }
    public void InstantiateNumberEducation(int index)
    {
        _currentNumber = _listedNumbers[index];
    }

    public void StartGame(int index)
    {
        if (_isLetter)
            InstantiateLetterEducation(index);

        else if (_isNumber)
            InstantiateNumberEducation(index);

        else if (_isColor)
            InstantiateColorEducation(index);
    }

    public void StartNextStep()
    {
        if (isGameTurn)
        {
            InstantiateLetterGame();
        }
        else if (isTestTurn)
        {
            InstantiateLetterTest();
        }
        else
        {
            _testController.InActiveTest();
            ChangeStatusOfCompletedLetter();
            OnWholeLevelDone?.Invoke();
        }
       
    }

    public void ChangeGameStatus(int stateIndex)
    {
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
        _isLetter = letter;
        _isNumber = number;
        _isColor = color;
    }


}
