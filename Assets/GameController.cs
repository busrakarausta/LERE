using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] letters;

    [SerializeField]
    private GameObject lettersGame;

    [SerializeField]
    private LevelController levelController;

    private char currentLetter = 'A';
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
        lettersGame.SetActive(false);
    }

    private void GameEnd()
    {
        Debug.Log("GameController/GameEnd");

        OnGameEnd?.Invoke();
    }
    public void StartLetterGame(char letter)
    {
        Debug.Log("GameController/StartLetterGame");

        lettersGame.SetActive(true);
        currentLetter = letter;

        currentGame=GameObject.Instantiate(letters[letter - 'A'], lettersGame.transform);

    }
}
