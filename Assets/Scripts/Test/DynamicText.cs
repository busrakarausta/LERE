using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    private string letter="A";
    private Text letterText;

    public void SetLetter(string letterString)
    {
        letterText = this.GetComponent<Text>();
        letterText.text = letterString;
    }


}
