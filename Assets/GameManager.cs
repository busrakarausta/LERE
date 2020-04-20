using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private bool _isLetter=false;
    private bool _isNumber=false;
    private bool _isColor=false;

    private char _currentLetter = 'A';
    private int _currentNumber = 1;
    private Color _currentColor = Color.red;

    private void Awake()
    {
        _instance = this;
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
