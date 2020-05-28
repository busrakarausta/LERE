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

    [SerializeField]
    private string letterEduRate = "RateOfEduLetter";
    [SerializeField]
    private string numberEduRate = "RateOfEduNumber";
    [SerializeField]
    private string colorEduRate = "RateOfEduColor";

    [SerializeField]
    private string letterTestRate = "RateOfTestLetter";
    [SerializeField]
    private string numberTestRate = "RateOfTestNumber";
    [SerializeField]
    private string colorTestRate = "RateOfTestColor";

    [SerializeField]
    private string dailyLetterList = "DailyListOfLetter";
    [SerializeField]
    private string dailyNumberList = "DailyListOfNumber";
    [SerializeField]
    private string dailyColorList = "DailyListOfColor";

    [SerializeField]
    private string lastTimeHolder = "LastTimeUserLaunch";

    [Header("Application Elements")]
    [SerializeField]
    private char[] letters;
    [SerializeField]
    private int[] numbers;
    [SerializeField]
    private int[] colors;

    private int _activeGameCount=3;

    private TimeSpan timeDifference;
    private DateTime currentTime;
    private DateTime lastTime;

    private bool isReset = true;
    private bool isInitializing = true;

    private int _remainingActiveLetterGameCount=3;
    private int _remainingActiveNumberGameCount = 3;
    private int _remainingActiveColorGameCount = 3;

    private int _indexOfLastIncompleteLetter=0;
    private int _indexOfLastIncompleteNumber = 0;
    private int _indexOfLastIncompleteColor = 0;

    private char[] _activeLetterList;
    private int[] _activeNumberList;
    private int[] _activeColorList;

    private char[] _activeDailyLetterList;
    private int[] _activeDailyNumberList;
    private int[] _activeDailyColorList;

    private void Awake()
    {
        Debug.Log("DataManager/Awake");

        DontDestroyOnLoad(this);
        instance = this;

        SetTime();
    }
    
    private void SetTime()
    {
        currentTime = DateTime.Now;
        string savedTimeAsString = PlayerPrefs.HasKey(lastTimeHolder) ? PlayerPrefs.GetString(lastTimeHolder) : currentTime.ToString();
        DateTime.TryParse(savedTimeAsString, out lastTime);
        PlayerPrefs.SetString(lastTimeHolder, currentTime.ToString());
        timeDifference = currentTime - lastTime;

        DateTime comp1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, currentTime.Second, 0);
        DateTime comp2 = new DateTime(lastTime.Year, lastTime.Month, lastTime.Day, lastTime.Hour, lastTime.Minute, lastTime.Second, 0);

        if (timeDifference.Days >= 1 || (DateTime.Compare(comp1, comp2) == 0) )
        {
            isReset = true;
        }
        else
            isReset = false;
    }

    public void DeleteAll()
    {
        Debug.Log("DataManager/DeleteAll");

        PlayerPrefs.DeleteAll();
    }

    private void SetDailyList(string listKey, string listElement)
    {
        PlayerPrefs.SetString(listKey, listElement);
    }

    private string GetDailyList(string listKey)
    {
        string listElement;
        listElement = PlayerPrefs.GetString(listKey);

        return listElement;
    }
    private void SetActiveLetterList()
    {
        Debug.Log("DataManager/SetActiveLetterList");
       
        if (_activeLetterList == null)
            _activeLetterList = new char[_remainingActiveLetterGameCount];

        int nextLetter = _indexOfLastIncompleteLetter;

        for (int i = 0; i < _remainingActiveLetterGameCount; i++)
        {
            for (int t = nextLetter; t < _activeGameCount+ _indexOfLastIncompleteLetter; t++)
            {
                int status = GetStatusOfTheLetter(letters[nextLetter]);
                if(status != 3)
                {
                    _activeLetterList[i] = letters[nextLetter];
                    nextLetter++;
                    break;
                }
                nextLetter++;
            }
        }

        if(isReset)
        {
            _activeDailyLetterList = _activeLetterList;
            string string_object = new string(_activeLetterList);
            SetDailyList(dailyLetterList, string_object);
        }
        else
        {
            string s = GetDailyList(dailyLetterList);
            _activeDailyLetterList = s.ToCharArray();
        }
    }

    private void SetActiveNumberList()
    {
        Debug.Log("DataManager/SetActiveNumberList");

        if (_activeNumberList == null)
            _activeNumberList = new int[_remainingActiveNumberGameCount];

        int nextNumber = _indexOfLastIncompleteNumber;

        for (int i = 0; i < _remainingActiveNumberGameCount; i++)
        {
            for (int t = nextNumber; t < _activeGameCount + _indexOfLastIncompleteNumber; t++)
            {
                int status = GetStatusOfTheNumber(numbers[nextNumber]);
                if (status != 3)
                {
                    _activeNumberList[i] = (char)numbers[nextNumber];
                    nextNumber++;
                    break;
                }
                nextNumber++;
            }

        }

        if (isReset)
        {
            Debug.Log("DataManager/GetDailyNumberList");
            _activeDailyNumberList = _activeNumberList;
            char[] charTypeOfList = new char[_activeNumberList.Length];
            for (int i = 0; i < _activeNumberList.Length; i++)
            {
                charTypeOfList[i] = (char)(_activeNumberList[i] + '0');
            }
            string string_object = new string(charTypeOfList);
            SetDailyList(dailyNumberList, string_object);
        }
        else
        {
            string s = GetDailyList(dailyNumberList);
            char[] charTypeOfList = s.ToCharArray();
            _activeDailyNumberList = new int[charTypeOfList.Length];
            for (int i = 0; i < charTypeOfList.Length; i++)
            {
                _activeDailyNumberList[i] = (int)(charTypeOfList[i] - '0');
            }
        }
    }
    private void SetActiveColorList()
    {
        Debug.Log("DataManager/SetActiveColorList");

        if (_activeColorList == null)
            _activeColorList = new int[_remainingActiveColorGameCount];

        int nextNumber = _indexOfLastIncompleteColor;

        for (int i = 0; i < _remainingActiveColorGameCount; i++)
        {
            for (int t = nextNumber; t < _activeGameCount + _indexOfLastIncompleteColor; t++)
            {
                int status = GetStatusOfTheColor(colors[nextNumber]);
                if (status != 3)
                {
                    _activeColorList[i] = (char)colors[nextNumber];
                    nextNumber++;
                    break;
                }
                nextNumber++;
            }

        }
        if (isReset)
        {
            _activeDailyColorList = _activeColorList;
            char[] charTypeOfList = new char[_activeColorList.Length];
            for (int i = 0; i < _activeColorList.Length; i++)
            {
                charTypeOfList[i] = (char)(_activeColorList[i] + '0');
            }
            string string_object = new string(charTypeOfList);
            SetDailyList(dailyColorList, string_object);
        }
        else
        {
            string s = GetDailyList(dailyColorList);
            char[] charTypeOfList = s.ToCharArray();
            _activeDailyColorList = new int[charTypeOfList.Length];
            for (int i = 0; i < charTypeOfList.Length; i++)
            {
                _activeDailyColorList[i] = (int)(charTypeOfList[i] - '0');
            }
        }
    }

    public char[] GetActiveLetterList()
    {
        Debug.Log("DataManager/GetActiveLetterList");

        if(_activeLetterList == null)
            SetActiveLetterList();

        return _activeLetterList;
    }

    public int[] GetActiveNumberList()
    {
        Debug.Log("DataManager/GetActiveNumberList");

        if (_activeNumberList == null)
            SetActiveNumberList();

        return _activeNumberList;
    }

    public int[] GetActiveColorList()
    {
        Debug.Log("DataManager/GetActiveColorList");

        if (_activeColorList == null)
            SetActiveColorList();

        return _activeColorList;
    }

    public char[] GetDailyLetterList()
    {
        Debug.Log("DataManager/GetDailyLetterList");

        if (_activeDailyLetterList == null)
            SetActiveLetterList();

        return _activeDailyLetterList;
    }
    public int[] GetDailyNumberList()
    {
        Debug.Log("DataManager/GetDailyNumberList");

        if (_activeDailyNumberList == null)
            SetActiveNumberList();

        return _activeDailyNumberList;
    }
    public int[] GetDailyColorList()
    {
        Debug.Log("DataManager/GetDailyColorList");

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

        int count = PlayerPrefs.HasKey(remainLetterKey) ? PlayerPrefs.GetInt(remainLetterKey) : _activeGameCount;

        _remainingActiveLetterGameCount = isReset ? _activeGameCount : count;

        if(_remainingActiveLetterGameCount >= 0)
        PlayerPrefs.SetInt(remainLetterKey, _remainingActiveLetterGameCount);

        Debug.Log("Remaining Letters" + _remainingActiveLetterGameCount);
    }

    public int GetRemainingActiveLetterGameCount()
    {
        Debug.Log("DataManager/GetRemainingActiveLetterGameCount");

        _remainingActiveLetterGameCount = PlayerPrefs.HasKey(remainLetterKey)?PlayerPrefs.GetInt(remainLetterKey):_activeGameCount;

        return _remainingActiveLetterGameCount;
    }

    /* */

    public void SetRemainingActiveNumberGameCount() //gunluk degiseceksin
    {
        Debug.Log("DataManager/SetRemainingActiveLetterGameCount");

        int count = PlayerPrefs.HasKey(remainNumberKey) ? PlayerPrefs.GetInt(remainNumberKey) : _activeGameCount;

        _remainingActiveNumberGameCount = isReset ? _activeGameCount : count;

        if (_remainingActiveNumberGameCount >= 0)
            PlayerPrefs.SetInt(remainNumberKey, _remainingActiveNumberGameCount);

        Debug.Log("Remaining Letters" + _remainingActiveNumberGameCount);
    }

    public int GetRemainingActiveNumberGameCount()
    {
        Debug.Log("DataManager/GetRemainingActiveNumberGameCount");

        _remainingActiveNumberGameCount = PlayerPrefs.HasKey(remainNumberKey) ? PlayerPrefs.GetInt(remainNumberKey) : _activeGameCount;
        
        return _remainingActiveNumberGameCount;
    }

    public void SetRemainingActiveColorGameCount() //gunluk degiseceksin
    {
        Debug.Log("DataManager/SetRemainingActiveColorGameCount");

        int count = PlayerPrefs.HasKey(remainColorKey) ? PlayerPrefs.GetInt(remainColorKey) : _activeGameCount;

        _remainingActiveColorGameCount = isReset ? _activeGameCount : count;

        if (_remainingActiveColorGameCount >= 0)
            PlayerPrefs.SetInt(remainColorKey, _remainingActiveColorGameCount);

        Debug.Log("Remaining Color" + _remainingActiveColorGameCount);
    }

    public int GetRemainingActiveColorGameCount()
    {
        Debug.Log("DataManager/SetRemainingActiveColorGameCount");

        _remainingActiveColorGameCount = PlayerPrefs.HasKey(remainColorKey) ? PlayerPrefs.GetInt(remainColorKey) : _activeGameCount;
        
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

    public void SetEducationRate(int status, int index,int rate)
    {
        Debug.Log("DataManager/SetEducationRate");

        string relativeKey;
        string initialValue;
        if (status == 0)
        {
            relativeKey = letterEduRate;
            initialValue = "00000000000000000000000000";
        }
        else if (status == 1)
        {
            relativeKey = numberEduRate;
            initialValue = "000000000";
        }
        else
        {
            relativeKey = colorEduRate;
            initialValue = "000000";
        }

        Debug.Log(status);
        Debug.Log(index);
        Debug.Log(rate);

        string rateString = (PlayerPrefs.HasKey(relativeKey) ? PlayerPrefs.GetString(relativeKey) : initialValue);
        char[] allLettersRate = rateString.ToCharArray();

        allLettersRate[index] = (char)('0' + rate);

        string string_object = new string(allLettersRate);
        PlayerPrefs.SetString(relativeKey, string_object);
    }

    public int GetEducationRate(int status,int index)
    {
        Debug.Log("DataManager/GetTestRate");

        string relativeKey;

        if (status == 0)
            relativeKey = letterEduRate;
        else if (status == 1)
            relativeKey = numberEduRate;
        else
            relativeKey = colorEduRate;
        
        string rateString = PlayerPrefs.HasKey(relativeKey) ? PlayerPrefs.GetString(relativeKey) : "00000000000000000000000000";
        char[] allLettersRate = rateString.ToCharArray();

        int rate = (int)(allLettersRate[index] - '0');
        return rate;
    }

    public void SetTestRate(int status, int index, int rate)
    {
        Debug.Log("DataManager/SetTestRate");

        string relativeKey;
        string initialValue;
        if (status == 0)
        {
            relativeKey = letterTestRate;
            initialValue = "00000000000000000000000000";
        }
        else if (status == 1)
        {
            relativeKey = numberTestRate;
            initialValue = "000000000";
        }
        else
        {
            relativeKey = colorTestRate;
            initialValue = "000000";
        }

        string rateString = (PlayerPrefs.HasKey(relativeKey) ? PlayerPrefs.GetString(relativeKey) : initialValue);
        char[] allElementRate = rateString.ToCharArray();

        allElementRate[index] = (char)('0' + rate);

        string string_object = new string(allElementRate);
        PlayerPrefs.SetString(relativeKey, string_object);
    }

    public int GetTestRate(int status, int index)
    {
        Debug.Log("DataManager/GetTestRate");

        string relativeKey;

        if (status == 0)
            relativeKey = letterTestRate;
        else if (status == 1)
            relativeKey = numberTestRate;
        else
            relativeKey = colorTestRate;

        string rateString = PlayerPrefs.HasKey(relativeKey) ? PlayerPrefs.GetString(relativeKey) : "00000000000000000000000000";
        char[] allLettersRate = rateString.ToCharArray();

        int rate = (int)(allLettersRate[index] - '0');
        return rate;
    }

}
