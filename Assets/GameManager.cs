using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private char currentLetter = 'A';

    public char GetCurrentLetter()
    {
        return currentLetter;
    }
}
