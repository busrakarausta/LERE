using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TodayParentUI : MonoBehaviour
{
    // action kullan ach. managerden invoke atıcak 
    //update uı la güncelle

    [SerializeField]
    private GameObject letterPanel;
    [SerializeField]
    private GameObject numberPanel;
    [SerializeField]
    private GameObject colorPanel;
    [SerializeField]
    private GameObject displayBox;
    [SerializeField]
    private string[] colorNames;

    private GameObject[] letterObjectBoxes;
    private GameObject[] numberObjectBoxes;
    private GameObject[] colorObjectBoxes;

    private char[] activeLetterList;
    private int[] activeNumberList;
    private int[] activeColorList;

    private int[] xAlignment = { -510, 0, 510 };

    private void Awake()
    {
        InitializeLetterPanel();
        InitializeNumberPanel();
        InitializeColorPanel();
    }

    private void InitializeLetterPanel()
    {
        activeLetterList = DataManager.instance.GetActiveLetterList();
        letterObjectBoxes = new GameObject[activeLetterList.Length];

        for (int i = 0; i < activeLetterList.Length; i++)
        {
            letterObjectBoxes[i] = GameObject.Instantiate(displayBox, letterPanel.transform, false);
            RectTransform rt = letterObjectBoxes[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(xAlignment[i], 0, 0);
        }
        InitializeDisplayBox(0);

    }
    private void InitializeNumberPanel()
    {
        activeNumberList = DataManager.instance.GetActiveNumberList();
        numberObjectBoxes = new GameObject[activeNumberList.Length];

        for (int i = 0; i < activeNumberList.Length; i++)
        {
            numberObjectBoxes[i] = GameObject.Instantiate(displayBox, numberPanel.transform, false);
            RectTransform rt = numberObjectBoxes[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(xAlignment[i], 0, 0);
        }
        InitializeDisplayBox(1);

    }

    private void InitializeColorPanel()
    {
        activeColorList = DataManager.instance.GetActiveColorList();
        colorObjectBoxes = new GameObject[activeColorList.Length];

        for (int i = 0; i < activeColorList.Length; i++)
        {
            colorObjectBoxes[i] = GameObject.Instantiate(displayBox, colorPanel.transform, false);
            RectTransform rt = colorObjectBoxes[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(xAlignment[i], 0, 0);
        }
        InitializeDisplayBox(2);
    }

    private void InitializeDisplayBox(int status = 0)
    {
        if (status == 0)
        {
            int letterLenght = activeLetterList.Length;
            for (int i = 0; i < letterLenght; i++)
            {
                Text displayedText = letterObjectBoxes[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                displayedText.text = activeLetterList[i].ToString();

                Text displayedEducationRate = letterObjectBoxes[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
                displayedEducationRate.text = AchivementManager.instance.GetEducationRate(status, i).ToString();

                Text displayedTestRate = letterObjectBoxes[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
                displayedTestRate.text = AchivementManager.instance.GetTestRate(status, i).ToString();

            }
        }
        else if (status == 1)
        {
            int numberLenght = activeNumberList.Length;
            for (int i = 0; i < numberLenght; i++)
            {
                Text displayedText = numberObjectBoxes[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                displayedText.text = activeNumberList[i].ToString();

                Text displayedEducationRate = numberObjectBoxes[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
                displayedEducationRate.text = AchivementManager.instance.GetEducationRate(status, i).ToString();

                Text displayedTestRate = numberObjectBoxes[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
                displayedTestRate.text = AchivementManager.instance.GetTestRate(status, i).ToString();
            }
        }
        else if (status == 2)
        {
            int colorLenght = activeColorList.Length;
            for (int i = 0; i < colorLenght; i++)
            {
                Text displayedText = colorObjectBoxes[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                displayedText.text = colorNames[activeColorList[i]-1];

                Text displayedEducationRate = colorObjectBoxes[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
                displayedEducationRate.text = AchivementManager.instance.GetEducationRate(status, i).ToString();

                Text displayedTestRate = colorObjectBoxes[i].transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
                displayedTestRate.text = AchivementManager.instance.GetTestRate(status, i).ToString();
            }

        }

    }

   
}
