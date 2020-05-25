using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Data Keys")]

    [SerializeField]
    private string activeGameKey = "ActiveGameCount";

    [SerializeField]
    private string inCompleteLetterIndexKey = "IndexOfLastIncompleteLetter";
    [SerializeField]
    private string inCompleteNumberIndexKey = "IndexOfLastIncompleteNumber";
    [SerializeField]
    private string inCompleteColorIndexKey = "IndexOfLastIncompleteColor";

    [SerializeField]
    private string remainLetterKey = "IndexOfRemainLetterCount";
    [SerializeField]
    private string remainNumberKey = "IndexOfRemainNumberCount";
    [SerializeField]
    private string remainColorKey = "IndexOfRemainColorCount";

    [SerializeField]
    private string letterStatus = "StatusOfTheLetter";
    [SerializeField]
    private string numberStatus = "StatusOfTheNumber";
    [SerializeField]
    private string colorStatus = "StatusOfTheColor";

    private string lastTimeHolder = "LastTimeUserExit";

    [Header("Application Elements")]
    [SerializeField]
    private char[] letters;
    [SerializeField]
    private int[] numbers;
    [SerializeField]
    private int[] colors;

    private int _activeGameCount=3;

    private DateTime lastTime;
    private DateTime currentTime;

    private int _remainingActiveLetterGameCount=3;
    private int _remainingActiveNumberGameCount = 3;
    private int _remainingActiveColorGameCount = 3;

    private int _indexOfLastIncompleteLetter=0;
    private int _indexOfLastIncompleteNumber = 0;
    private int _indexOfLastIncompleteColor = 0;


    private char[] _activeDailyLetterList;
    private int[] _activeDailyNumberList;
    private int[] _activeDailyColorList;

    private void Awake()
    {
        Debug.Log("DataManager/Awake");

        DontDestroyOnLoad(this);
        instance = this;

    }
    
    private void SetTime()
    {
        currentTime = DateTime.UtcNow;

        
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();

    }
    public void SetActiveLetterList()
    {
        Debug.Log("DataManager/SetActiveLetterList");
       
        if (_activeDailyLetterList == null)
            _activeDailyLetterList = new char[_remainingActiveLetterGameCount];

        int nextLetter = _indexOfLastIncompleteLetter;

        for (int i = 0; i < _remainingActiveLetterGameCount; i++)
        {
            for (int t = nextLetter; t < _activeGameCount+ _indexOfLastIncompleteLetter; t++)
            {
                int status = GetStatusOfTheLetter(letters[nextLetter]);
                if(status != 3)
                {
                    _activeDailyLetterList[i] = letters[nextLetter];
                    nextLetter++;
                    break;
                }
                nextLetter++;
            }

        }
    }

    public void SetActiveNumberList()
    {
        Debug.Log("DataManager/SetActiveNumberList");

        if (_activeDailyNumberList == null)
            _activeDailyNumberList = new int[_remainingActiveNumberGameCount];

        int nextNumber = _indexOfLastIncompleteNumber;

        for (int i = 0; i < _remainingActiveNumberGameCount; i++)
        {
            for (int t = nextNumber; t < _activeGameCount + _indexOfLastIncompleteNumber; t++)
            {
                int status = GetStatusOfTheNumber(numbers[nextNumber]);
                if (status != 3)
                {
                    _activeDailyNumberList[i] = (char)numbers[nextNumber];
                    nextNumber++;
                    break;
                }
                nextNumber++;
            }

        }
    }
    public void SetActiveColorList()
    {
        Debug.Log("DataManager/SetActiveColorList");

        if (_activeDailyColorList == null)
            _activeDailyColorList = new int[_remainingActiveColorGameCount];

        int nextNumber = _indexOfLastIncompleteColor;

        for (int i = 0; i < _remainingActiveColorGameCount; i++)
        {
            for (int t = nextNumber; t < _activeGameCount + _indexOfLastIncompleteColor; t++)
            {
                int status = GetStatusOfTheNumber(colors[nextNumber]);
                if (status != 3)
                {
                    _activeDailyColorList[i] = (char)colors[nextNumber];
                    nextNumber++;
                    break;
                }
                nextNumber++;
            }

        }
    }

    public char[] GetActiveLetterList()
    {
        Debug.Log("DataManager/GetActiveLetterList");

        if(_activeDailyLetterList == null)
            SetActiveLetterList();

        return _activeDailyLetterList;
    }

    public int[] GetActiveNumberList()
    {
        Debug.Log("DataManager/GetActiveNumberList");

        if (_activeDailyNumberList == null)
            SetActiveNumberList();

        return _activeDailyNumberList;
    }

    public int[] GetActiveColorList()
    {
        Debug.Log("DataManager/GetActiveColorList");

        if (_activeDailyColorList == null)
            SetActiveColorList();

        return _activeDailyColorList;
    }

    public int GetStatusOfTheLetter(char letter)
    {
        bool check = PlayerPrefs.HasKey(letterStatus);
        if (!check)
        {
            string status = "00000000000000000000000000";

            PlayerPrefs.SetString(letterStatus, status);
            return 0;
        }
        
        string allStatus = PlayerPrefs.GetString(letterStatus);
        return allStatus[letter - 'A']-'0';
    }

    public void SetStatusOfTheLetter(char letter='A', char status='0')
    {
        string s = PlayerPrefs.GetString(letterStatus);
        char[] allStatus = s.ToCharArray();

        allStatus[letter - 'A'] = status;

        string string_object = new string(allStatus);
        PlayerPrefs.SetString(letterStatus, string_object);

        if (status == '3')
        {
            _remainingActiveLetterGameCount--;
            if(letter - 'A' > 0)
            {
                int previousLetterStatus = GetStatusOfTheLetter(letters[letter - 'A'-1]);
                if (previousLetterStatus == 3)
                {
                    _indexOfLastIncompleteLetter++;
                }
            }
            else
                _indexOfLastIncompleteLetter++;

            if (_indexOfLastIncompleteLetter >= letters.Length)
                ReInitializeLetter();

            PlayerPrefs.SetInt(inCompleteLetterIndexKey, _indexOfLastIncompleteLetter);
            PlayerPrefs.SetInt(remainLetterKey, _remainingActiveLetterGameCount);
        }
    }


    /* */
    public int GetStatusOfTheNumber(int number)
    {
        bool check = PlayerPrefs.HasKey(numberStatus);
        if (!check)
        {
            string status = "000000000";

            PlayerPrefs.SetString(numberStatus, status);
            return 0;
        }

        string allStatus = PlayerPrefs.GetString(numberStatus);
        return allStatus[number-1] - '0';
    }

    public int GetStatusOfTheColor(int color)
    {
        bool check = PlayerPrefs.HasKey(colorStatus);
        if (!check)
        {
            string status = "000000";

            PlayerPrefs.SetString(colorStatus, status);
            return 0;
        }

        string allStatus = PlayerPrefs.GetString(colorStatus);
        return allStatus[color - 1] - '0';
    }

    public void SetStatusOfTheNumber(int number = 1, char status = '0')
    {
        string s = PlayerPrefs.GetString(numberStatus);
        char[] allStatus = s.ToCharArray();

        allStatus[number-1] = status;

        string string_object = new string(allStatus);
        PlayerPrefs.SetString(numberStatus, string_object);

        if (status == '3')
        {
            _remainingActiveNumberGameCount--;
            if (number > 1)
            {
                int previousNumberStatus = GetStatusOfTheNumber(numbers[number - 2]);
                if (previousNumberStatus == 3)
                {
                    _indexOfLastIncompleteNumber++;
                }
            }
            else
                _indexOfLastIncompleteNumber++;

            if (_indexOfLastIncompleteNumber >= numbers.Length)
                ReInitializeNumber();

            PlayerPrefs.SetInt(inCompleteNumberIndexKey, _indexOfLastIncompleteNumber);
            PlayerPrefs.SetInt(remainNumberKey, _remainingActiveNumberGameCount);
        }
    }

    public void SetStatusOfTheColor(int color = 1, char status = '0')
    {
        string s = PlayerPrefs.GetString(colorStatus);
        char[] allStatus = s.ToCharArray();

        allStatus[color - 1] = status;

        string string_object = new string(allStatus);
        PlayerPrefs.SetString(colorStatus, string_object);

        if (status == '3')
        {
            _remainingActiveColorGameCount--;
            if (color > 1)
            {
                int previousColorStatus = GetStatusOfTheColor(colors[color - 2]);
                if (previousColorStatus == 3)
                {
                    _indexOfLastIncompleteColor++;
                }
            }
            else
                _indexOfLastIncompleteColor++;

            if (_indexOfLastIncompleteColor >= colors.Length)
                ReInitializeColor();

            PlayerPrefs.SetInt(inCompleteColorIndexKey, _indexOfLastIncompleteColor);
            PlayerPrefs.SetInt(remainColorKey, _remainingActiveColorGameCount);
        }
    }

    private void ReInitializeNumber() //hangi elemanın kaç kere tamamlandığını tutabiliriz.
    {
        _indexOfLastIncompleteNumber = 0;
        _remainingActiveNumberGameCount = _activeGameCount;

        string s = "000000000";
        PlayerPrefs.SetString(numberStatus,s);

    }
    private void ReInitializeLetter() //hangi elemanın kaç kere tamamlandığını tutabiliriz.
    {
        _indexOfLastIncompleteLetter = 0;
        _remainingActiveLetterGameCount = _activeGameCount;

        string s = "00000000000000000000000000";
        PlayerPrefs.SetString(letterStatus, s);

    }
    private void ReInitializeColor() //hangi elemanın kaç kere tamamlandığını tutabiliriz.
    {
        _indexOfLastIncompleteColor = 0;
        _remainingActiveColorGameCount = _activeGameCount;

        string s = "000000";
        PlayerPrefs.SetString(colorStatus, s);

    }

    public void SetRemainingActiveLetterGameCount() //gunluk degiseceksin
    {
        Debug.Log("DataManager/SetRemainingActiveLetterGameCount");

        int count = PlayerPrefs.HasKey(remainLetterKey) ? PlayerPrefs.GetInt(remainLetterKey) : 0;

        _remainingActiveLetterGameCount = count == 0 ? _activeGameCount : count;

        if(_remainingActiveLetterGameCount >= 0)
        PlayerPrefs.SetInt(remainLetterKey, _remainingActiveLetterGameCount);

        Debug.Log("Remaining Letters" + _remainingActiveLetterGameCount);
    }

    public int GetRemainingActiveLetterGameCount()
    {
        Debug.Log("DataManager/GetRemainingActiveLetterGameCount");

        _remainingActiveLetterGameCount = PlayerPrefs.GetInt(remainLetterKey);

        return _remainingActiveLetterGameCount;
    }

    /* */

    public void SetRemainingActiveNumberGameCount() //gunluk degiseceksin
    {
        Debug.Log("DataManager/SetRemainingActiveLetterGameCount");

        int count = PlayerPrefs.HasKey(remainNumberKey) ? PlayerPrefs.GetInt(remainNumberKey) : 0;

        _remainingActiveNumberGameCount = count == 0 ? _activeGameCount : count;

        if (_remainingActiveNumberGameCount >= 0)
            PlayerPrefs.SetInt(remainNumberKey, _remainingActiveNumberGameCount);

        Debug.Log("Remaining Letters" + _remainingActiveNumberGameCount);
    }

    public int GetRemainingActiveNumberGameCount()
    {
        Debug.Log("DataManager/GetRemainingActiveNumberGameCount");

        _remainingActiveNumberGameCount = PlayerPrefs.GetInt(remainNumberKey);

        return _remainingActiveNumberGameCount;
    }

    public void SetRemainingActiveColorGameCount() //gunluk degiseceksin
    {
        Debug.Log("DataManager/SetRemainingActiveColorGameCount");

        int count = PlayerPrefs.HasKey(remainColorKey) ? PlayerPrefs.GetInt(remainColorKey) : 0;

        _remainingActiveColorGameCount = count == 0 ? _activeGameCount : count;

        if (_remainingActiveColorGameCount >= 0)
            PlayerPrefs.SetInt(remainColorKey, _remainingActiveColorGameCount);

        Debug.Log("Remaining Color" + _remainingActiveColorGameCount);
    }

    public int GetRemainingActiveColorGameCount()
    {
        Debug.Log("DataManager/SetRemainingActiveColorGameCount");

        _remainingActiveColorGameCount = PlayerPrefs.GetInt(remainColorKey);

        return _remainingActiveColorGameCount;
    }

    public void SetIndexOfLastIncompleteNumber()
    {
        Debug.Log("DataManager/SetIndexOfLastIncompleteNumber");

        _indexOfLastIncompleteNumber = PlayerPrefs.HasKey(inCompleteNumberIndexKey) ? PlayerPrefs.GetInt(inCompleteNumberIndexKey) : 0;

        PlayerPrefs.SetInt(inCompleteNumberIndexKey, _indexOfLastIncompleteNumber);
        Debug.Log("index Of Last Incomplete Number" + _indexOfLastIncompleteNumber);
    }

    public int GetIndexOfLastIncompleteNumber()
    {
        Debug.Log("DataManager/GetIndexOfLastIncompleteNumber");

        int _indexOfLastIncompleteNumber = PlayerPrefs.GetInt(inCompleteNumberIndexKey);

        return _indexOfLastIncompleteNumber;
    }
    //

    public void SetIndexOfLastIncompleteLetter()
    {
        Debug.Log("DataManager/SetIndexOfLastIncompleteLetter");

        _indexOfLastIncompleteLetter = PlayerPrefs.HasKey(inCompleteLetterIndexKey) ? PlayerPrefs.GetInt(inCompleteLetterIndexKey) : 0;

        PlayerPrefs.SetInt(inCompleteLetterIndexKey, _indexOfLastIncompleteLetter);
        Debug.Log("index Of Last Incomplete Letter" + _indexOfLastIncompleteLetter);
    }

    public int GetIndexOfLastIncompleteLetter()
    {
        Debug.Log("DataManager/GetIndexOfLastIncompleteLetter");

        int indexOfLastIncompleteLetter = PlayerPrefs.GetInt(inCompleteLetterIndexKey);

        return indexOfLastIncompleteLetter;
    }

    public void SetIndexOfLastIncompleteColor()
    {
        Debug.Log("DataManager/SetIndexOfLastIncompleteColor");

        _indexOfLastIncompleteColor = PlayerPrefs.HasKey(inCompleteColorIndexKey) ? PlayerPrefs.GetInt(inCompleteColorIndexKey) : 0;

        PlayerPrefs.SetInt(inCompleteColorIndexKey, _indexOfLastIncompleteColor);
        Debug.Log("index Of Last Incomplete Color" + _indexOfLastIncompleteColor);
    }

    public int GetIndexOfLastIncompleteColor()
    {
        Debug.Log("DataManager/GetIndexOfLastIncompleteColor");

        int indexOfLastIncompleteColor = PlayerPrefs.GetInt(inCompleteColorIndexKey);

        return indexOfLastIncompleteColor;
    }

    public void SetActiveGameCount(int value=1) //gunluk degisecek
    {
        Debug.Log("DataManager/SetActiveGameCount");

        int count = PlayerPrefs.HasKey(activeGameKey) ? PlayerPrefs.GetInt(activeGameKey) : value;

        _activeGameCount = count;

        PlayerPrefs.SetInt(activeGameKey, _activeGameCount);

        SetRemainingActiveLetterGameCount();
        SetIndexOfLastIncompleteLetter();

        SetRemainingActiveNumberGameCount();
        SetIndexOfLastIncompleteNumber();

        SetRemainingActiveColorGameCount();
        SetIndexOfLastIncompleteColor();
    }

    public int GetActiveGameCount()
    {
        Debug.Log("DataManager/GetActiveGameCount");

        int activeGameCount = PlayerPrefs.GetInt(activeGameKey);

        return activeGameCount;
    }

}
