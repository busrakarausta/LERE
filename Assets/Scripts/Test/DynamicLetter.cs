using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLetter : MonoBehaviour
{

    public string letter;
    Text letterText;

    void Start()
    {
        letterText = GetComponent<Text>();
        letterText.text = letter;
    }
}
