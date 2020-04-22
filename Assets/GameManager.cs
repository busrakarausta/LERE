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

    public event Action OnStepDone;
    public event Action OnWholeLevelDone;
    private void Awake()
    {
        _instance = this;

        _educationController.OnLetterEducationEnd += OnLetterEducationDone;
        _gameController.OnGameEnd += OnLetterGameDone;
        _testController.OnTestEnd += OnLetterTestDone;
    }

    public void EndCurrentState()
    {
        if (isEducationTurn)
            _educationController.InActiveEducation();

        else if (isGameTurn)
            _gameController.InActiveGame();


        else if (isTestTurn)
            _testController.InActiveTest();
    }

    private void OnLetterGameDone()
    {
        OnStepDone?.Invoke();

        isEducationTurn = false;
        isGameTurn = false;
        isTestTurn = true;
    }

    private void OnLetterEducationDone()
    {
        OnStepDone?.Invoke();

        isEducationTurn = false;
        isGameTurn = true;
        isTestTurn = false;
    }

    private void OnLetterTestDone()
    {
        OnStepDone?.Invoke();

        isEducationTurn = true;
        isGameTurn = false;
        isTestTurn = false;
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

        isEducationTurn = true;
        isGameTurn = false;
        isTestTurn = false;

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
            InstantiateLetterGame();

       else if (isTestTurn)
            InstantiateLetterTest();

        else
        {
            _testController.InActiveTest();
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
