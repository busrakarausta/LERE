using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EducationController : MonoBehaviour
{
    [SerializeField]
    private WritingHandler _writingHandler;

    [SerializeField]
    private GameObject letterEducation;

    

    public event Action OnLetterEducationEnd;

    public void InActiveEducation()
    {
        _writingHandler.InactiveCurrentLetter();
        letterEducation.SetActive(false);
    }

    private void Awake()
    {
        _writingHandler.OnLetterEnd += OnLetterEnd;

        //
    }
    public void StartLetterEducation(char letter)
    {
        int index = letter - 'A';
        // letter educationa bir script atip oraya sesleri ekleyin. O scripte public index alan bir fonksiyon ekleyin. Onu burada cagirirken siradaki letterin indexini yoillayin
        letterEducation.SetActive(true);
        _writingHandler.SetCurrentLetterIndex(index);
        _writingHandler.LoadLetter();
    }

    private void OnLetterEnd()
    {
        OnLetterEducationEnd?.Invoke();
    }

}
