using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] letters;
    [SerializeField]
    private GameObject[] numbers;
    [SerializeField]
    private GameObject[] colors;

    [SerializeField]
    private GameObject games;

    [SerializeField]
    private LevelController levelController;

    private char currentLetter = 'A';
    private int currentNumber = 1;
    private int currentColor = 1;
    private GameObject currentGame;

    public event Action OnGameEnd;

    private void Awake()
    {
        Debug.Log("GameController/Awake");

        levelController.OnGameEnd += GameEnd;
    }
    public void InActiveGame()
    {
        Debug.Log("GameController/InActiveGame");

        Destroy(currentGame);
        games.SetActive(false);
    }

    private void GameEnd()
    {
        Debug.Log("GameController/GameEnd");

        OnGameEnd?.Invoke();
    }
    public void StartLetterGame(char letter)
    {
        Debug.Log("GameController/StartLetterGame");

        games.SetActive(true);
        currentLetter = letter;

        currentGame=GameObject.Instantiate(letters[letter - 'A'], games.transform);

    }
    public void StartNumberGame(int number)
    {
        Debug.Log("GameController/StartNumberGame");

        games.SetActive(true);
        currentNumber = number;

        currentGame = GameObject.Instantiate(numbers[number-1], games.transform);

    }
    public void StartColorGame(int color = 1)
    {
        Debug.Log("GameController/StartColorGame");

        games.SetActive(true);
        currentColor = color;

        currentGame = GameObject.Instantiate(colors[color-1], games.transform);

    }
}
