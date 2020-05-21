using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationSoundsProvider : MonoBehaviour
{
    public AudioClip[] letterSoundArray;
    public AudioClip[] numberSoundArray;
    public AudioClip[] colorSoundArray;
    private AudioSource aSource;

    public void EducationSoundPlayer(int status,int index) {

        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }

        if(status == 0)
            aSource.clip = letterSoundArray[index];

        else if (status == 1)
            aSource.clip = numberSoundArray[index];

        else if (status == 2)
            aSource.clip = colorSoundArray[index];

        aSource.Play();    
    }
}
