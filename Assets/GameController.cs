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

    public event Action OnGameEnd;

    private void Awake()
    {
        levelController.OnGameEnd += GameEnd;
    }
    public void InActiveGame()
    {
        letters[currentLetter - 'A'].SetActive(false);
        lettersGame.SetActive(false);
    }

    private void GameEnd()
    {
        OnGameEnd?.Invoke();
    }
    public void StartLetterGame(char letter)
    {
        lettersGame.SetActive(true);
        currentLetter = letter;
        letters[letter - 'A'].SetActive(true);
    }
}
