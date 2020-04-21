using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        _instance = this;
    }


    public void InstantiateLetterGame(int index)
    {
        _currentLetter = _listedLetters[index];

        isEducationTurn = true;
        isGameTurn = false;
        isTestTurn = false;

        //_educationController

    }



    public void InstantiateColorGame(int index)
    {
        _currentColor = _listedColors[index];
    }
    public void InstantiateNumberGame(int index)
    {
        _currentNumber = _listedNumbers[index];
    }

    public void StartGame(int index)
    {
        if (_isLetter)
            InstantiateLetterGame(index);

        else if (_isNumber)
            InstantiateNumberGame(index);

        else if (_isColor)
            InstantiateColorGame(index);
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
