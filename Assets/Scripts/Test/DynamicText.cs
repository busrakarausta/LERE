using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    private string letter="A";
    private Text letterText;

    private int num = 1;
    private Text numberText;

    public void SetLetter(string letterString)
    {
        letterText = this.GetComponent<Text>();
        letterText.text = letterString;
    }

   
    public void SetNumber(int number)
    {
        numberText = this.GetComponent<Text>();
        numberText.text = number.ToString();
    }
    
}
