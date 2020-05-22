using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundProvider : MonoBehaviour
{
    public AudioClip[] letterTestSoundArray;
    public AudioClip[] numberTestSoundArray;
    public AudioClip[] colorTestSoundArray;
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
            aSource.clip = numberTestSoundArray[index];
        }
      /*  else if (status == 2)
        {
            aSource.clip = colorTestSoundArray[index];
        }*/
        aSource.Play();
    }
}
