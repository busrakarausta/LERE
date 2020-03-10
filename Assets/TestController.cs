﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{
    public char testObject;

    private char currentChar;
    private Image currentImage;
    private char[] shownTestLetters;
    

    [SerializeField]
    private Sprite[] allSprites;
    [SerializeField]
    private Image[] selectionImages; 

    private void Awake()
    {
        shownTestLetters = new char[3];

        GenerateLetter();

        AssingImagesToLetterComponents();
    }

    public void SetCurrentChar(string objChar)
    {
        currentChar = objChar[0];
    }

    public void TestClickedObject(Image currentObj)
    {
        if (currentChar != testObject)
        {
            currentImage = currentObj;
            StartCoroutine(FadeLetter());

        }
        else
            Debug.Log("congruts");
    }

    void GenerateLetter()
    {
        int originalLetterIndex = (int)(testObject - 'A');
        int firstRandomIndex = (originalLetterIndex+Random.Range(0, 25))%25;
        int secondRandomIndex = (originalLetterIndex + firstRandomIndex+1)%25;

        Debug.Log(firstRandomIndex);
        Debug.Log(secondRandomIndex);
        // int secondRandomIndex = ( (Mathf.Abs(originalLetterIndex - firstRandomIndex))+ Random.Range(0, 25)) % 24;





        shownTestLetters[0] = (char)('A' + originalLetterIndex);
        shownTestLetters[1] = (char)('A' + firstRandomIndex);
        shownTestLetters[2] = (char)('A' + secondRandomIndex );
    }

    void AssingImagesToLetterComponents()
    {
        int randomFirstIndex = Random.Range(0, 2);
        int randomSecondIndex = (3 - randomFirstIndex) % 2;
        int randomThirdIndex = 3 - (randomFirstIndex + randomSecondIndex);

        selectionImages[randomFirstIndex].sprite = allSprites[(int)(shownTestLetters[0]-'A')];
        selectionImages[randomSecondIndex].sprite = allSprites[(int)(shownTestLetters[1]-'A')];
        selectionImages[randomThirdIndex].sprite = allSprites[(int)(shownTestLetters[2]-'A')];
    }


    IEnumerator FadeLetter()
    {
        float endAlpha = 0.3f;

        while(true)
        {
            Color currentColor = currentImage.color;
            if (currentColor.a <= endAlpha)
                yield return 0;
            else
            {
                currentColor.a = currentColor.a - 0.05f;
                currentImage.color = currentColor;
                yield return new WaitForSeconds(0.02f);
            }
        }


    }
}
