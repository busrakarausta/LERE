using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private char letter='A';

    public char get()
    {
        return letter;
    }

    public void set(char letter)
    {
        this.letter = letter;
    }
}
