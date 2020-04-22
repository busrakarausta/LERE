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
        levelController.OnGameEnd += GameEnd;
    }
    public void InActiveGame()
    {
        Destroy(currentGame);
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

        currentGame=GameObject.Instantiate(letters[letter - 'A'], lettersGame.transform);

    }
}
