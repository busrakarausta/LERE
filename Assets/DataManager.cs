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
    private string remainLetterKey = "IndexOfRemainLetterCount";
    [SerializeField]
    private string remainNumberKey = "IndexOfRemainNumberCount";
    [SerializeField]
    private string letterStatus = "StatusOfTheLetter";

    [SerializeField]
    private string numberStatus = "StatusOfTheNumber";

    [Header("Application Elements")]
    [SerializeField]
    private char[] letters;
    [SerializeField]
    private int[] numbers;
    [SerializeField]
    private Color[] colors;

    private int _activeGameCount=3;

    private int _remainingActiveLetterGameCount=3;
    private int _remainingActiveNumberGameCount = 3;

    private int _indexOfLastIncompleteLetter=0;
    private int _indexOfLastIncompleteNumber = 0;


    private char[] _activeDailyLetterList;
    private int[] _activeDailyNumberList;

    private void Awake()
    {
        Debug.Log("DataManager/Awake");

        DontDestroyOnLoad(this);
        instance = this;

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

    public char[] GetActiveLetterList()
    {
        Debug.Log("DataManager/GetActiveLetterList");

        if(_activeDailyLetterList == null)
            SetActiveLetterList();

        return _activeDailyLetterList;
    }

    public int[] GetActiveNumberList()
    {
        Debug.Log("DataManager/GetActiveLetterList");

        if (_activeDailyNumberList == null)
            SetActiveNumberList();

        return _activeDailyNumberList;
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
    }

    public int GetActiveGameCount()
    {
        Debug.Log("DataManager/GetActiveGameCount");

        int activeGameCount = PlayerPrefs.GetInt(activeGameKey);

        return activeGameCount;
    }

}
