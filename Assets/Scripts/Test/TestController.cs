using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{
    public string testObject;

    public void TestClickedObject(string objChar, GameObject obj)
    {
        if (testObject == objChar)
        {
            Debug.Log("congrats");
        }
        else
        {
            Debug.Log("wrong");
        }
    }
}
