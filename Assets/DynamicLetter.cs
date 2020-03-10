using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLetter : MonoBehaviour
{
    public char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W','X','Y', 'Z'};
    public string letter;
    Text letterText;

    void Start()
    {
        letterText = GetComponent<Text>();
        letterText.text = letter;
    }
}
