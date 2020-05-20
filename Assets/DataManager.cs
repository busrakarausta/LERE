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
    private string remainLetterKey = "IndexOfRemainLetterCount";
    [SerializeField]
    private string letterStatus = "StatusOfTheLetter";

    [Header("Application Elements")]
    [SerializeField]
    private char[] letters;
    [SerializeField]
    private int[] numbers;
    [SerializeField]
    private Color[] colors;

    private int _activeGameCount=3;
    private int _remainingActiveLetterGameCount=3;
    private int _indexOfLastIncompleteLetter=0;

    private char[] _activeDailyLetterList;

    private void Awake()
    {
        Debug.Log("DataManager/Awake");

        DontDestroyOnLoad(this);
        instance = this;

        //PlayerPrefs.DeleteAll();
    }

    public void SetActiveLetterList()
    {
        Debug.Log("DataManager/SetActiveLetterList");
        Debug.Log(_indexOfLastIncompleteLetter);
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

    public char[] GetActiveLetterList()
    {
        Debug.Log("DataManager/GetActiveLetterList");

        if(_activeDailyLetterList == null)
            SetActiveLetterList();

        return _activeDailyLetterList;
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

            PlayerPrefs.SetInt(inCompleteLetterIndexKey, _indexOfLastIncompleteLetter);
            PlayerPrefs.SetInt(remainLetterKey, _remainingActiveLetterGameCount);
        }
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
    }

    public int GetActiveGameCount()
    {
        Debug.Log("DataManager/GetActiveGameCount");

        int activeGameCount = PlayerPrefs.GetInt(activeGameKey);

        return activeGameCount;
    }

}
