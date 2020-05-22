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
    private Sprite[] allNumberSprites;
    [SerializeField]
    private Sprite[] allColorSprites;
    [SerializeField]
    private Image[] selectionImages;
    [SerializeField]
    private DynamicText currentElement;

    [SerializeField]
    private GameObject testLetterObject;
    private TestSoundProvider testSoundProvider;

    public char testObject;

    private char currentChar;
    private Image currentImage;
    private char[] shownTestLetters;

    private char[] shownTestNumbers;
    private char[] shownTestColors;

    private GameObject _correctObject;
    private int status;
    private float originalWidth, originalHeight;
    private float originalPosX;

    public event Action OnTestEnd;
    private void Awake()
    {
        Debug.Log("TestController/Awake");
        testSoundProvider = testLetterObject.GetComponent<TestSoundProvider>();
        shownTestLetters = new char[3];
        shownTestNumbers = new char[3];
        shownTestColors = new char[3];
    }

    private void SetText(char txt)
    {
        Debug.Log("TestController/SetText");

        string text = txt.ToString();

        if (status != 2)
            currentElement.SetLetter(text);
        else
            currentElement.SetColor((int)(txt - '0'));
    }

    public void StartLetterTest(char letter)
    {
        Debug.Log("TestController/StartLetterTest");

        int index = letter - 'A';
        status = 0;

        testSoundProvider.TestSoundPlayer(0,index);

        testLetterObject.SetActive(true);

        testObject = letter;

        GenerateLetter();

        AssingImagesToLetterComponents();

        SetText(letter);
    }

    //number test
    public void StartNumberTest(int number)
    {
        Debug.Log("TestController/StartNumberTest");

        int index = number;
        status = 1;

        testSoundProvider.TestSoundPlayer(1,index);

        testLetterObject.SetActive(true);
        testObject = (char)('0'+number);

        GenerateNumber();

        AssingImagesToNumberComponents();
        SetText(testObject);
    }
    //

    public void StartColorTest(int color)
    {
        Debug.Log("TestController/StartColorTest");

        int index = color;
        status = 2;

        testSoundProvider.TestSoundPlayer(2, index);

        testLetterObject.SetActive(true);
        testObject = (char)('0' + color);

        GenerateColor();

        AssingImagesToColorComponents();
        SetText(testObject);
    }

    public void TestClickedObject(Image currentObj)
    {
        Debug.Log("TestController/TestClickedObject");

        currentChar = currentObj.gameObject.GetComponent<Letter>().get();

        if (currentChar != testObject)
        {
            currentImage = currentObj;
            StartCoroutine(FadeLetter());

        }
        else
        {
            _correctObject = currentObj.gameObject;  
            EndOfTheTest();
            // Burasi testin bitisi -- buraya yazabilirsiniz
            OnTestEnd?.Invoke();
        }      
    }

    public void InActiveTest()
    {
        Debug.Log("TestController/InActiveTest");

        StopCoroutine(AnimateCorrectObject());

        RefreshTest();

        testLetterObject.SetActive(false);
    }

    private void RefreshTest()
    {
        Debug.Log("TestController/RefreshTest");

        for (int i = 0; i < 3; i++)
        {
            Color originalColor = selectionImages[i].color;
            originalColor.a = 1;
            selectionImages[i].color = originalColor;
            selectionImages[i].gameObject.SetActive(true);
        }

        RectTransform currentTransform = _correctObject.GetComponent<RectTransform>();

        currentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalWidth);
        currentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalHeight);

        currentTransform.localPosition = new Vector2(originalPosX, 0);
    }

    void GenerateLetter()
    {
        Debug.Log("TestController/GenerateLetter");

        int originalLetterIndex = (int)(testObject - 'A');
        int firstRandomIndex = (originalLetterIndex+UnityEngine.Random.Range(0, 25))%25;
        int secondRandomIndex = (originalLetterIndex + firstRandomIndex+1)%25;

        shownTestLetters[0] = (char)('A' + originalLetterIndex);
        shownTestLetters[1] = (char)('A' + firstRandomIndex);
        shownTestLetters[2] = (char)('A' + secondRandomIndex );
    }


    /* */
    void GenerateNumber()
    {
        Debug.Log("TestController/GenerateNumber");
        Debug.Log(testObject);
        int originalNumberIndex = (int)(testObject - '0');
        int firstRandomIndex = (originalNumberIndex + UnityEngine.Random.Range(1, 8)) % 9;
        int secondRandomIndex = (originalNumberIndex + firstRandomIndex + 1) % 9;

        shownTestNumbers[0] = (char)('0'+ originalNumberIndex);
        shownTestNumbers[1] = (char)('0' + firstRandomIndex);
        shownTestNumbers[2] = (char)('0' + secondRandomIndex);
    }

    void GenerateColor()
    {
        Debug.Log("TestController/GenerateColor");

        int originalNumberIndex = (int)(testObject - '0');
        int firstRandomIndex = (originalNumberIndex + UnityEngine.Random.Range(1, 5)) % 6;
        int secondRandomIndex = (originalNumberIndex + firstRandomIndex + 1) % 6;

        shownTestColors[0] = (char)('0' + originalNumberIndex);
        shownTestColors[1] = (char)('0' + firstRandomIndex);
        shownTestColors[2] = (char)('0' + secondRandomIndex);
    }
    //
    void AssingImagesToLetterComponents()
    {
        Debug.Log("TestController/AssingImagesToLetterComponents");

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

     /* */ 
    void AssingImagesToNumberComponents()
    {
        Debug.Log("TestController/AssingImagesToNumberComponents");

        int randomFirstIndex = UnityEngine.Random.Range(0, 2);
        int randomSecondIndex = (3 - randomFirstIndex) % 2;
        int randomThirdIndex = 3 - (randomFirstIndex + randomSecondIndex);

        selectionImages[randomFirstIndex].sprite = allNumberSprites[(int)(shownTestNumbers[0] - '1')];
        selectionImages[randomFirstIndex].gameObject.GetComponent<Letter>().set(shownTestNumbers[0]);

        selectionImages[randomSecondIndex].sprite = allNumberSprites[(int)(shownTestNumbers[1] - '0')];
        selectionImages[randomSecondIndex].gameObject.GetComponent<Letter>().set(shownTestNumbers[1]);

        selectionImages[randomThirdIndex].sprite = allNumberSprites[(int)(shownTestNumbers[2] - '0')];
        selectionImages[randomThirdIndex].gameObject.GetComponent<Letter>().set(shownTestNumbers[2]);
    }

    void AssingImagesToColorComponents()
    {
        Debug.Log("TestController/AssingImagesToColorComponents");

        int randomFirstIndex = UnityEngine.Random.Range(0, 2);
        int randomSecondIndex = (3 - randomFirstIndex) % 2;
        int randomThirdIndex = 3 - (randomFirstIndex + randomSecondIndex);

        selectionImages[randomFirstIndex].sprite = allColorSprites[(int)(shownTestColors[0] - '1')];
        selectionImages[randomFirstIndex].gameObject.GetComponent<Letter>().set(shownTestColors[0]);

        selectionImages[randomSecondIndex].sprite = allColorSprites[(int)(shownTestColors[1] - '0')];
        selectionImages[randomSecondIndex].gameObject.GetComponent<Letter>().set(shownTestColors[1]);

        selectionImages[randomThirdIndex].sprite = allColorSprites[(int)(shownTestColors[2] - '0')];
        selectionImages[randomThirdIndex].gameObject.GetComponent<Letter>().set(shownTestColors[2]);
    }
    //


    IEnumerator FadeLetter()
    {
        Debug.Log("TestController/FadeLetter");

        float endAlpha = 0.3f;
        Color currentColor = currentImage.color;

        while (currentColor.a >= endAlpha)
        {
                currentColor.a = currentColor.a - 0.05f;
                currentImage.color = currentColor;
                yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(0);
    }

    private void EndOfTheTest()
    {
        Debug.Log("TestController/EndOfTheTest");

        for (int i = 0; i < 3;  i++)
        {
            selectionImages[i].gameObject.SetActive(false);
        }

        _correctObject.SetActive(true);

        StartCoroutine(AnimateCorrectObject());
    }

    IEnumerator AnimateCorrectObject()
    {
        Debug.Log("TestController/AnimateCorrectLetter");

        RectTransform currentTransform = _correctObject.GetComponent<RectTransform>();

        originalWidth = currentTransform.sizeDelta.x;
        originalHeight = currentTransform.sizeDelta.y;

        originalPosX = currentTransform.localPosition.x;

        float maxWidth = originalWidth * 3;
        float maxHeight = originalHeight * 3;

        float width = originalWidth;
        float height = originalHeight;

        while (width <= maxWidth && height <= maxHeight)
        {
            width = currentTransform.sizeDelta.x;
            height = currentTransform.sizeDelta.y;

            float posX = currentTransform.localPosition.x;

            currentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * 1.1f);
            currentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height * 1.1f);

            currentTransform.localPosition = new Vector2(posX * 0.5f,0);

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0);

    }


}
