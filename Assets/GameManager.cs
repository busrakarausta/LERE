using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private char currentLetter = 'A';

    private void Awake()
    {
        instance = this;
    }
    public char GetCurrentLetter()
    {
        return currentLetter;
    }
}
