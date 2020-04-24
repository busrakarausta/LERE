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
        DontDestroyOnLoad(this);
        instance = this;

        //GameManager._instance.OnLetterComplete += SetIndexOfLastIncompleteLetter;
    }

    public void OnLetterCompleted()
    {
        _remainingActiveLetterGameCount--;
        _indexOfLastIncompleteLetter++;
    }

    public void SetActiveLetterList()
    {
        if (_activeDailyLetterList == null)
            _activeDailyLetterList = new char[_activeGameCount];

        int nextLetter = _indexOfLastIncompleteLetter;

        for (int i = 0; i < _activeGameCount; i++)
        {
            if(i< _indexOfLastIncompleteLetter)
            {
                _activeDailyLetterList[i] = '/';
            }
            else
            {
                _activeDailyLetterList[i] = letters[nextLetter];
            }
            nextLetter++;
        }
    }

    public char[] GetActiveLetterList()
    {
        SetActiveLetterList();

        return _activeDailyLetterList;
    }

    public void SetRemainingActiveLetterGameCount(int count)
    {
        _remainingActiveLetterGameCount = count;
    }

    public void SetIndexOfLastIncompleteLetter()
    {
        if (_indexOfLastIncompleteLetter >= _activeGameCount)
            return;

        _indexOfLastIncompleteLetter++;
        PlayerPrefs.SetInt(inCompleteLetterIndexKey, _indexOfLastIncompleteLetter);
    }

    public int GetIndexOfLastIncompleteLetter()
    {
        int indexOfLastIncompleteLetter= PlayerPrefs.GetInt(inCompleteLetterIndexKey);

        return indexOfLastIncompleteLetter;
    }

    public void SetActiveGameCount(int value=1)
    {
        _activeGameCount = value;
        PlayerPrefs.SetInt(activeGameKey, _activeGameCount);
    }

    public int GetActiveGameCount()
    {
        int activeGameCount = PlayerPrefs.GetInt(activeGameKey);

        return activeGameCount;
    }

}
