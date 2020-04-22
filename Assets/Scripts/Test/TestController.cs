using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TestController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] allSprites;
    [SerializeField]
    private Image[] selectionImages;
    [SerializeField]
    private DynamicText currentElement;

    [SerializeField]
    private GameObject testLetterObject;

    public char testObject;

    private char currentChar;
    private Image currentImage;
    private char[] shownTestLetters;

    public event Action OnTestEnd;
    private void Awake()
    {
        shownTestLetters = new char[3];
    }

    private void SetText(char letter)
    {
        string text = letter.ToString();

        currentElement.SetLetter(text);
    }

    public void StartLetterTest(char letter)
    {
        testLetterObject.SetActive(true);

        testObject = letter;

        GenerateLetter();

        AssingImagesToLetterComponents();

        SetText(letter);
    }

    public void TestClickedObject(Image currentObj)
    {
        currentChar = currentObj.gameObject.GetComponent<Letter>().get();

        if (currentChar != testObject)
        {
            currentImage = currentObj;
            StartCoroutine(FadeLetter());

        }
        else
            OnTestEnd?.Invoke();
    }

    public void InActiveTest()
    {
        testLetterObject.SetActive(false);
    }

    void GenerateLetter()
    {
        int originalLetterIndex = (int)(testObject - 'A');
        int firstRandomIndex = (originalLetterIndex+UnityEngine.Random.Range(0, 25))%25;
        int secondRandomIndex = (originalLetterIndex + firstRandomIndex+1)%25;

        shownTestLetters[0] = (char)('A' + originalLetterIndex);
        shownTestLetters[1] = (char)('A' + firstRandomIndex);
        shownTestLetters[2] = (char)('A' + secondRandomIndex );
    }

    void AssingImagesToLetterComponents()
    {
        int randomFirstIndex = UnityEngine.Random.Range(0, 2);
        int randomSecondIndex = (3 - randomFirstIndex) % 2;
        int randomThirdIndex = 3 - (randomFirstIndex + randomSecondIndex);

        selectionImages[randomFirstIndex].sprite = allSprites[(int)(shownTestLetters[0]-'A')];
        selectionImages[randomFirstIndex].gameObject.GetComponent<Letter>().set(shownTestLetters[0]);

        selectionImages[randomSecondIndex].sprite = allSprites[(int)(shownTestLetters[1]-'A')];
        selectionImages[randomSecondIndex].gameObject.GetComponent<Letter>().set(shownTestLetters[1]);

        selectionImages[randomThirdIndex].sprite = allSprites[(int)(shownTestLetters[2]-'A')];
        selectionImages[randomThirdIndex].gameObject.GetComponent<Letter>().set(shownTestLetters[2]);
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
