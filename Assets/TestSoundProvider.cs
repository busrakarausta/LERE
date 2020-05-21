using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundProvider : MonoBehaviour
{
    public AudioClip[] letterTestSoundArray;
    public AudioClip[] numberTestSoundArray;
    private AudioSource aSource;

    public void TestSoundPlayer(int status,int index)
    {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }

        if (status == 0)
        {
            aSource.clip = letterTestSoundArray[index];
        }
        else if (status == 1)
        {
            aSource.clip = letterTestSoundArray[index];
        }
        aSource.Play();
    }
}
