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
    private GameObject _correctObject;
    private float originalWidth, originalHeight;
    private float originalPosX;

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
        {
            _correctObject = currentObj.gameObject;
            EndOfTheTest();
            OnTestEnd?.Invoke();
        }
           
    }

    public void InActiveTest()
    {
        StopCoroutine(AnimateCorrectLetter());

        RefreshTest();

        testLetterObject.SetActive(false);
    }

    private void RefreshTest()
    {
        for (int i = 0; i < shownTestLetters.Length; i++)
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

        Debug.Log("Test Refresh");
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
        for (int i = 0; i < shownTestLetters.Length; i++)
        {
            selectionImages[i].gameObject.SetActive(false);
        }

        _correctObject.SetActive(true);

        StartCoroutine(AnimateCorrectLetter());

    }

    IEnumerator AnimateCorrectLetter()
    {
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
