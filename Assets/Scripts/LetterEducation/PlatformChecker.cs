using UnityEngine;
using System.Collections;

/// <summary>
/// Platform checker.
/// [check the current platform]
/// </summary>
public class PlatformChecker : MonoBehaviour
{
    public static bool IsAndroid()
    {
        return Application.platform == RuntimePlatform.Android;
    }

    public static bool IsIOS()
    {
        return Application.platform == RuntimePlatform.IPhonePlayer;
    }

    public static bool IsWindowsEditor()
    {
        return Application.platform == RuntimePlatform.WindowsEditor;
    }
}