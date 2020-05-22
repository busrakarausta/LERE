using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    private string letter="A";
    private Text _text;

    [SerializeField]
    private string[] colorText;

    private int num = 1;
    private Text numberText;

    public void SetLetter(string letterString)
    {
        _text = this.GetComponent<Text>();
        _text.text = letterString;
    }

    public void SetColor(int index)
    {
        _text = this.GetComponent<Text>();
        _text.text = colorText[index - 1];
    }
    
}
